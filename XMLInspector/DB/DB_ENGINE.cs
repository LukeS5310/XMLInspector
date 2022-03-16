using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;

namespace XMLInspector.DB
{
    class DB_ENGINE
    {
        #region TABLE_GENERATE
        static readonly string IMPORT_TABLE = @"
CREATE TABLE IF NOT EXISTS IMPORT (
    FILENAME   TEXT (128),
    REFNAME    TEXT (128),
    NPERS      TEXT (128),
    NVPL       TEXT (16),
    PWVID      TEXT (16),
    QUANTITY   TEXT (16)
);
";
        #endregion

        #region "SETTINGS" 
        static readonly string FilePath = Application.StartupPath + "\\TEMP.db"; // USING RAM ONLY
        static readonly string ConnString = "Data Source=" + FilePath;
        public readonly SQLiteConnection Conn = new SQLiteConnection();
        private bool IsTemporary;
        #endregion

        public SQLiteConnection Open(string _ConnString = null)
        {
            bool NeedInit = false;
            try
            {
                if (_ConnString == null)
                {
                    NeedInit = true;
                    IsTemporary = true;
                    _ConnString = ConnString;
                }
                Conn.ConnectionString = _ConnString;
                Conn.Open();
                if (NeedInit == true)
                {
                    Init();
                }
               
                return Conn;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Ошибка БД: {0} {1}", ex.Message.ToString(),Conn.ConnectionString));
                return null;
            }

        }
        public void Close()
        {
            try
            {
                Conn.Close();
                if (IsTemporary == true)
                {
                    Conn.Dispose();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    File.Delete(FilePath);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Ошибка БД: {0}", ex.Message.ToString()));
                return;
            }

        }

        public void Init()
        {

            if (Conn.State != System.Data.ConnectionState.Open)
            {
                //ОТКРЫВАЙ НАХУЙ
                MessageBox.Show("Соединение не открыто или разорвано");
                return;
            }
            RunSimpleCmd(IMPORT_TABLE);





        }

        public void CleanUP()
        {
            if (Conn.State != System.Data.ConnectionState.Open)
            {
                //ОТКРЫВАЙ НАХУЙ
                MessageBox.Show("Соединение не открыто или разорвано");
                return;
            }
            RunSimpleCmd("DELETE FROM IMPORT;VACUUM;");

        }

        public void RunSimpleCmd(string cmdtext)
        {
            if (Conn.State != System.Data.ConnectionState.Open)
            {
                //ОТКРЫВАЙ НАХУЙ
                MessageBox.Show("Соединение не открыто или разорвано");
                return;
            }

            try
            {
                SQLiteCommand cmd = new SQLiteCommand(Conn)
                {
                    CommandText = cmdtext
                };
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Ошибка БД: {0}", ex.Message.ToString()));
                //throw;
            }

        }

    }
}
