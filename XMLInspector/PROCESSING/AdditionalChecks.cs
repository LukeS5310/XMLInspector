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
            SQLiteCommand Cmd = new SQLiteCommand(Conn) { CommandText = "INSERT INTO IMPORT (FILENAME,REFNAME,NPERS,NVPL,PWVID,QUANTITY) VALUES(@FILENAME,@REFNAME,@NPERS,@NVPL,@PWVID,@QUANTITY)" };
            SQLiteTransaction Transact = Conn.BeginTransaction();
            IEnumerable<XElement> TempElems = from el in Elem.Elements("СведенияОполучателе") select el;
            string RefName="";
            string npers = "";
            string NVpl = "";
            string PwVid = "";
            string QVidVpl = "";
            foreach (XElement el in TempElems)
            {
               
                RefName = GetRefName(el);
                npers = el.Element("СтраховойНомер").Value.ToString();
                NVpl = el.Element("НомерВыплатногоДела").Value.ToString();//TRY TO ASSEMBLE NEEDED VALUES
                PwVid = el.Element("ВсеВыплаты").Element("Выплата").Element("ВидВыплатыПоПЗ").Value.ToString();
                QVidVpl = el.Element("ВсеВыплаты").Element("Количество").Value.ToString();

                bool Isnumeric = int.TryParse(NVpl, out int n);
                if (!Isnumeric)
                {
                    DList.AddEntry(RefName, NVpl, npers, PwVid, QVidVpl, FileName);
                }
                try
                {
                    Cmd.Parameters.Add("@FILENAME", DbType.String).Value = FileName;
                    Cmd.Parameters.Add("@REFNAME", DbType.String).Value = RefName;
                    Cmd.Parameters.Add("@NPERS", DbType.String).Value = npers;
                    Cmd.Parameters.Add("@NVPL", DbType.String).Value = NVpl;
                    Cmd.Parameters.Add("@PWVID", DbType.String).Value = PwVid;
                    Cmd.Parameters.Add("@QUANTITY", DbType.String).Value=QVidVpl;
                    Cmd.ExecuteNonQuery();

                }
                catch (SQLiteException ex)
                {
                    continue;
                }
            }
            Transact.Commit();
            GetDoubles(Conn, DList); // учитывая новые требования проверки логику пришлось поменять, в самой базе убралась уникальность поля номер выплатного дела, а двойники теперь вытягиваются отдельным запросом
        } //в идеале если будут следующие требования по доп проверкам, то разделить импорт, и операции над импортированными данными
       
        private static void GetDoubles(SQLiteConnection Conn, LOGGING.DoublesList DList)
        {
            SQLiteCommand cmd = new SQLiteCommand(Conn) { CommandText= "SELECT * FROM IMPORT AS a WHERE 1 < (SELECT COUNT(*) FROM IMPORT AS b WHERE a.NVPL = b.NVPL AND a.PWVID = b.PWVID)" };

            SQLiteDataReader Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                DList.AddEntry(Reader[1].ToString(), Reader[3].ToString(),Reader[2].ToString(),Reader[4].ToString(),Reader[5].ToString(), Reader[0].ToString());
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
