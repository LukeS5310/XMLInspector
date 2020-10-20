using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using XMLInspector.LOGGING;
using System.Xml.Schema;
using System.Xml.Linq;
using System.Xml;
using System.Data.SQLite;
using System.Threading;

namespace XMLInspector.PROCESSING
{
    class XMLCheckProcess
    {
        private readonly BackgroundWorker wrk;
        
        public XMLCheckProcess(BackgroundWorker BgWorker = null)
        {
            wrk = BgWorker;
        }

        public void CheckTarget(XElement XMLTarget,List<DataTypes.XMLNode> XMLStruct,Logger Logger)
        {
            
            if (XMLStruct == null) //Unknown File
            {
               
                Logger.WriteLogMsg("Неподдерживаемый Файл!",true);
                return;
            }
            foreach (DataTypes.XMLNode Node in XMLStruct)
            {
                if (XMLTarget.Element(Node.Name)==null && Node.IsMandatory == true)
                {
                    Logger.WriteLogMsg(string.Format("ОШИБКА:Тег <{0}> Отсутствует в блоке <{1}> (Строка {2})", Node.Name, XMLTarget.Name, (XMLTarget as IXmlLineInfo)?.LineNumber),true,true);
                    continue;
                }
                else if (XMLTarget.Element(Node.Name) == null && Node.IsMandatory==false)
                {
                    continue;
                }
               
                if (Node.Name == "НомерВыплатногоДела")
                {
                   
                    Logger.AddPrePend(string.Format("Проверка дела № {0}", XMLTarget.Element(Node.Name).Value));
                }
                if (Node.IsMultiple == true && Node.HasChildren == true)
                {
                    IEnumerable<XElement> TempElems = from el in XMLTarget.Elements(Node.Name) select el;
                    foreach  (XElement el in TempElems)
                    {
                        CheckTarget(el, Node.ChildrenList, Logger);
                    }
                    continue;
                }
                if (Node.HasChildren==true && Node.IsMultiple == false)
                {
                    CheckTarget(XMLTarget.Element(Node.Name),Node.ChildrenList,Logger);
                }

            }
            

        }

    }
}
