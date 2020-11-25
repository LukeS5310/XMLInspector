using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace XMLInspector.UTILS
{
    class XMLVersionResolver
    {
        public static string ResolveXMLVersion(string FilePath)
        {
            string Version = XElement.Load(FilePath).XPathSelectElement("ЗаголовокФайла/ПрограммаПодготовкиДанных/ТекущаяВерсияФорматаОбмена")?.Value.ToString() ?? "50.0 или ниже";
            return Version;
        }
    }
}
