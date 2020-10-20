using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace XMLInspector.LOGGING
{
    class DoublesList
    {
        public int DoublesFound = 0;
        private string CSVStrings;
        public DoublesList()
        {
            CSVStrings = "ИМЯ;№ В/Д;ФАЙЛ";
        }

        public void AddEntry(string Name, string VPL,string FileName)
        {
            CSVStrings = string.Join("\n",CSVStrings, string.Join(";", Name, VPL, FileName));
            DoublesFound++;
        }
        private string TimeStamp(bool GiveDate = false, bool IsForFile = false)
        {
            if (GiveDate == true) return string.Format("[{0}]", DateTime.Now.ToString("dd.MM.yyyy"));
            if (IsForFile == true) return string.Format("{0}", DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss"));


            return string.Format("[{0}]", DateTime.Now.ToString("HH:mm:ss"));
        }
        public void SaveFIle(string Folder = null)
        {
            if (Folder == null) Folder = Application.StartupPath;
            string FileToSave = null;
            if (DoublesFound > 0)
            {
                try
                {
                    FileToSave = Path.Combine(Folder, string.Format("Двойники {0}.csv", TimeStamp(IsForFile: true)));
                    File.WriteAllText(FileToSave, CSVStrings, Encoding.GetEncoding(1251));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("Ошибка сохранения {0}", ex.Message.ToString()));

                }
                
            }
           
        }
    }
}
