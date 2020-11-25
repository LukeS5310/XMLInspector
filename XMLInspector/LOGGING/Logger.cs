using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace XMLInspector.LOGGING
{
    class Logger
    {
        private StringBuilder LogString = new StringBuilder();
        public int ErrsFound = 0;
        private string PrePend = "";
        public void LogStartNewFile(string FileName) //fullname with path only
        {
            LogString.AppendLine(string.Format("----------------------------------------\r\n{0} {1} Начата проверка файла: {2}", TimeStamp(true), TimeStamp(), FileName));
            string Version;
            try
            {
               Version = UTILS.XMLVersionResolver.ResolveXMLVersion(FileName);
                
            }
            catch (Exception)
            {

                Version = "Ошибка определения, путь файла некорректен?";
            }
            LogString.AppendLine(string.Format("Версия формата обмена: {0}", Version));
        }
        public void WriteLogMsg(string message, bool IsError = false,bool UsePrePend = false)
        {
            if (IsError == true)
            {
                ErrsFound++;
            }
            if (UsePrePend == true)
            {
                message = string.Join("\r\n", PrePend, message);
            }
            message = string.Format("{0} {1}", TimeStamp(), message);
            //LogString = string.Join("\r\n", LogString, message);
            LogString.AppendLine(message);
            //LogString = string.Format("{0} \r\n {1}", LogString, message);
            PrePend = "";
        }
        public void AddPrePend(string _PrePend)
        {
            PrePend = _PrePend;
        }
        private string TimeStamp(bool GiveDate = false,bool IsForFile=false)
        {
            if (GiveDate == true) return string.Format("[{0}]", DateTime.Now.ToString("dd.MM.yyyy"));
            if (IsForFile == true) return string.Format("{0}", DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss"));
           

            return string.Format("[{0}]", DateTime.Now.ToString("HH:mm:ss"));
        }
        public string SaveLogFile(string Folder=null)
        {
            if (Folder==null) Folder = Application.StartupPath;
            string FileToSave = null;
            if (ErrsFound>0)
            {
                try
                {
                    FileToSave = Path.Combine(Folder, string.Format("Проверка {0}.txt", TimeStamp(IsForFile: true)));
                    File.WriteAllText(FileToSave, LogString.ToString());
                }
                catch (Exception ex)
                {

                    MessageBox.Show(String.Format("Ошибка сохранения {0}", ex.Message.ToString()));
                }
                
            }
            return FileToSave; // Null if no errs present
        }
           
    }
}
