using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using XMLInspector.DB;
using System.Data;

namespace XMLInspector.PROCESSING
{
    class SysNumbersCheck
    {
        private static readonly string SysDubIPConn = "\\\\10.60.97.250\\dod\\DB_XMLIN\\XMLIN.db";
        private static readonly string SysDubDefaultConn = "\\\\SW06020308005\\dod\\DB_XMLIN\\XMLIN.db";
        private static readonly string SysDubDebugConn = "G:\\work\\XMLIN.DB";
        private string CurrConn = "Data Source=";
        public bool IsDBAvailable;
        public void ResolveConnection(ref string stmp)
        {
            CurrConn = "Data Source=";
            string LocalConn = Path.Combine(Application.StartupPath, "XMLIN.DB");
            DB_ENGINE Db = new DB_ENGINE();
            if (File.Exists(LocalConn)==true)
            {
                stmp = "Локальная база";
                CurrConn += LocalConn;
            }
            else if (File.Exists(SysDubDebugConn) == true)
            {
                stmp = "DEBUG";
                CurrConn += SysDubDebugConn;
            }
            else if (File.Exists(SysDubIPConn) == true) //ON MODE (IP, which is somewhat more reliable for this network kek)
            {
                stmp = "Сетевая база(IP)";
                CurrConn += "\\\\";
                CurrConn += SysDubIPConn;
            }
            else if (File.Exists(SysDubDefaultConn)== true) //ON MODE
            {
                stmp = "Сетевая база(DNS)";
                CurrConn += "\\\\";
                CurrConn += SysDubDefaultConn;
            }
            else
            {
                stmp = "Ошибка подключения,0";
                IsDBAvailable= false;
            }
            try
            {
                Db.Open(CurrConn);
                SQLiteCommand cmd = new SQLiteCommand(Db.Conn) { CommandText = "SELECT COUNT(*) FROM SYSNUMS" };
                stmp = string.Join(",", stmp, cmd.ExecuteScalar().ToString());
                Db.Close();
                IsDBAvailable = true;
            }
            catch (Exception)
            {
                Db.Close();
                IsDBAvailable = false;
            }

         
        }
        public void CheckSysDouble(string SysNum, LOGGING.Logger logger, string FileName)
        {
            if (IsDBAvailable == false) return;
            DB_ENGINE DBase = new DB_ENGINE();
            DBase.Open(CurrConn);
            SQLiteCommand cmd = new SQLiteCommand(DBase.Conn) {CommandText="INSERT INTO SYSNUMS (SYSNUM) VALUES(@SYSNUM);" };
            try
            {
                cmd.Parameters.Add("@SYSNUM", DbType.String).Value = SysNum;
                cmd.ExecuteNonQuery();
                DBase.Close();
            }
            catch (Exception)
            {
                DBase.Close();
                logger.WriteLogMsg(string.Format("[ВНИМАНИЕ!] Данный номер системного массива ({0}) уже проходил проверку ранее! Файл: {1}", SysNum,FileName));
            }

        }
    }
}
