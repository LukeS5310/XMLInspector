using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLInspector.IN
{
    class BankNominalPen_52 : BankNominalPen
    {
        protected override List<DataTypes.XMLNode> GenerateVplItem()
        {
            return new List<DataTypes.XMLNode>
            {
                new DataTypes.XMLNode("ПризнакВыплаты"),
                new DataTypes.XMLNode("НачисленнаяСумма"),
                new DataTypes.XMLNode("СуммаКвыплате"),
                new DataTypes.XMLNode("ДатаНачалаПериода"),
                new DataTypes.XMLNode("ДатаКонцаПериода"),
                new DataTypes.XMLNode("КодВидаДохода",_CannotBeEmpty:true),
                new DataTypes.XMLNode("ВидВыплатыПоПЗ"),

            };
        }


    }
}