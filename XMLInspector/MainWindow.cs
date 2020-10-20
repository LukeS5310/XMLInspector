using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XMLInspector.IN;
using System.IO;
using XMLInspector.LOGGING;
using XMLInspector.PROCESSING;
using System.Xml.Linq;
using System.Xml.XPath;

namespace XMLInspector
{
    public partial class MainWindow : Form
    {
        
        SysNumbersCheck SysChecker = new SysNumbersCheck();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            LBL_Path.Text = Properties.Settings.Default.WorkFolder;
            LBL_LastReportName.Text = Properties.Settings.Default.LastReport;
            string stmp = "";
            SysChecker.ResolveConnection(ref stmp);
            LBL_CONNSTAT.Text = stmp.Split(',')[0];
            LBL_SYSNUMSTOTAL.Text = stmp.Split(',')[1];
        }

        private void BTN_SelectFolder_Click(object sender, EventArgs e)
        {
            FBD_Sel.ShowDialog();
            Properties.Settings.Default.WorkFolder = FBD_Sel.SelectedPath;
            Properties.Settings.Default.Save();
            LBL_Path.Text = Properties.Settings.Default.WorkFolder;
        }

        private void BTN_OpenReportFolder_Click(object sender, EventArgs e)
        {
            //TODO - Make Separate folder for repors MAYBE
            System.Diagnostics.Process.Start("explorer.exe", Application.StartupPath);
        }

        private void BTN_OpenLastReport_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.LastReport != "")
            {
                try
                {
                    System.Diagnostics.Process.Start(Properties.Settings.Default.LastReport);
                }
                catch (Exception)
                {

                    MessageBox.Show("Невозможно открыть файл!");
                }
               
            }
            
        }

        private void BTN_Start_Click(object sender, EventArgs e)
        {
            BTN_Start.Enabled = false;
            BW_Process.RunWorkerAsync();
        }

        private void BW_Process_DoWork(object sender, DoWorkEventArgs e)
        {
            FileInfo[] XMLFiles;
            try
            {
                XMLFiles = new DirectoryInfo(Properties.Settings.Default.WorkFolder).GetFiles("*.xml");
            }
            catch (Exception)
            {

                MessageBox.Show("Выбранная папка не может быть открыта!");
                return;
            }
           
            Logger Logger = new Logger();
            DoublesList DList = new DoublesList();
            int FileCount = 0;
            XMLCheckProcess Checker = new XMLCheckProcess(BW_Process);
            DB.DB_ENGINE DB = new DB.DB_ENGINE();
            string SpisPath = "";
            DB.Open();
           
                foreach  (FileInfo XMLFile in XMLFiles)
                {
                    FileCount++;
                    if (XMLFile.Name.IndexOf("-OPP")!=-1) //ОПИСЬ, пропускаем
                    {
                        continue;
                    }
                    BW_Process.ReportProgress(-1, XMLFile.Name);
                    Logger.LogStartNewFile(XMLFile.Name);
                    try
                    {
                        if (SysChecker.IsDBAvailable == true) //check against db of sysnumbers
                        {
                            SysChecker.CheckSysDouble(XElement.Load(XMLFile.FullName).XPathSelectElement("ПачкаВходящихДокументов/ВХОДЯЩАЯ_ОПИСЬ/СистемныйНомерМассива")?.Value.ToString() ?? "", Logger, XMLFile.Name);
                        }
                        Checker.CheckTarget(XElement.Load(XMLFile.FullName,LoadOptions.SetLineInfo), XMLTypeResolver.Resolve(XMLFile.Name), Logger);
                        SpisPath = XMLTypeResolver.ResolveSpisPath(XMLFile.Name);
                        if (SpisPath != null)
                        {
                            AdditionalChecks.CheckVPLDouble(DB.Conn, XElement.Load(XMLFile.FullName).XPathSelectElement(SpisPath),DList,XMLFile.Name);
                            BW_Process.ReportProgress(-2, DList.DoublesFound);
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        Logger.WriteLogMsg(string.Format("Критическая ошибка при загрузке файла: {0}", ex.Message), true);
                        
                    }
              
                BW_Process.ReportProgress(FileCount,Logger.ErrsFound);
                }
          
            string LastReport = Logger.SaveLogFile();
            DList.SaveFIle();
            if (LastReport != null)
            {
                Properties.Settings.Default.LastReport = LastReport;
                Properties.Settings.Default.Save();
            }
            DB.Close();
        }

        private void BW_Process_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                default:
                    LBL_FilesChecked.Text = e.ProgressPercentage.ToString();
                    LBL_ERRS_FOUND.Text = e.UserState.ToString();
                    break;
                case -1: //Pass the name of file
                    LBL_FileName.Text = e.UserState.ToString();
                    break;
                case -2: //Pass the Doubles
                    LBL_DOUBLES_FOUND.Text = e.UserState.ToString();
                    break;
            }
           
        }

        private void BW_Process_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BTN_Start.Enabled = true;
            LBL_FileName.Text = "Проверка Завершена";
            LBL_LastReportName.Text = Properties.Settings.Default.LastReport;
        }
    }
}
