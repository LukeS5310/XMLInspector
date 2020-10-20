using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Xml.Linq;
using System.Data;

namespace XMLInspector.PROCESSING
{
    class AdditionalChecks
    {
        public static void CheckVPLDouble(SQLiteConnection Conn,XElement Elem,LOGGING.DoublesList DList, string FileName)
        {
            SQLiteCommand Cmd = new SQLiteCommand(Conn) { CommandText = "INSERT INTO IMPORT (FILENAME,REFNAME,NVPL) VALUES(@FILENAME,@REFNAME,@NVPL)"};
            SQLiteTransaction Transact = Conn.BeginTransaction();
            IEnumerable<XElement> TempElems = from el in Elem.Elements("СведенияОполучателе") select el;
            string RefName="";
            string NVpl = "";
            foreach (XElement el in TempElems)
            {
               
                RefName = GetRefName(el);
                NVpl = el.Element("НомерВыплатногоДела")?.Value.ToString() ?? "НЕ НАЙДЕН"; //TRY TO ASSEMBLE NEEDED VALUES
                try
                {
                    Cmd.Parameters.Add("@FILENAME", DbType.String).Value = FileName;
                    Cmd.Parameters.Add("@REFNAME", DbType.String).Value = RefName;
                    Cmd.Parameters.Add("@NVPL", DbType.String).Value = NVpl;
                    Cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    DList.AddEntry(RefName, NVpl, FileName);
                    GetOrig(Conn, NVpl, DList);
                    continue;
                }
            }
            Transact.Commit();
        }
        private static void GetOrig(SQLiteConnection Conn, string NVpl,LOGGING.DoublesList DList)
        {
            SQLiteCommand cmd = new SQLiteCommand(Conn) { CommandText="SELECT * from IMPORT WHERE NVPL =@NVPL" };
            cmd.Parameters.Add("@NVPL", DbType.String).Value = NVpl;
            SQLiteDataReader Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                DList.AddEntry(Reader[1].ToString(), Reader[2].ToString(), Reader[0].ToString());
            }
        }
        private static string GetRefName(XElement el)
        {
            if (el.Element("ФИО")!=null)
            {
                return string.Join(" ", el.Element("ФИО").Element("Фамилия")?.Value.ToString() ?? "", el.Element("ФИО").Element("Имя")?.Value.ToString() ?? "", el.Element("ФИО").Element("Отчество")?.Value.ToString() ?? "");
            }
            if (el.Element("НаименованиеОрганизации") != null)
            {
                return el.Element("НаименованиеОрганизации")?.Value.ToString() ?? "";

            }
            return "";
        }
    }
}
