using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLInspector.IN
{
    class BankNominalPen : CheckGenerator
    {
        protected override List<DataTypes.XMLNode> GeneratePVD()
        {
            return new List<DataTypes.XMLNode>
            {
                 new DataTypes.XMLNode("ВХОДЯЩАЯ_ОПИСЬ",_HasChildren:true,_ChildrenList:GenerateInOpis()),
                 new DataTypes.XMLNode("СПИСОК_НА_ЗАЧИСЛЕНИЕ_НОМИН_ОРГ",_HasChildren:true,_ChildrenList:GenerateSpis())
            };
        }
        public override string GetSpisPath()
        {
            return "ПачкаВходящихДокументов/СПИСОК_НА_ЗАЧИСЛЕНИЕ_НОМИН_ОРГ";  
        }
        protected override List<DataTypes.XMLNode> GenerateSved()
        {
            return new List<DataTypes.XMLNode>
            {
                new DataTypes.XMLNode("НомерВмассиве"),
                new DataTypes.XMLNode("НомерВыплатногоДела"),
                new DataTypes.XMLNode("КодРайона"),
                new DataTypes.XMLNode("СтраховойНомер"),
                new DataTypes.XMLNode("ОрганизацияНоминальныйСчет",_HasChildren:true,_ChildrenList:GenerateOrgNomS()),
                new DataTypes.XMLNode("НомерСчета"),
                new DataTypes.XMLNode("ВсеВыплаты",_HasChildren:true,_ChildrenList:GenerateVplList()),
                new DataTypes.XMLNode("ВсеУдержания",_IsMandatory:false,_HasChildren:true,_ChildrenList:GenerateUderList()),
                new DataTypes.XMLNode("СуммаКдоставке"),
                new DataTypes.XMLNode("СлужебнаяИнформация")
            };
        }
        protected List<DataTypes.XMLNode> GenerateOrgNomS()
        {
            return new List<DataTypes.XMLNode>
            {
                 new DataTypes.XMLNode("НалоговыйНомер",_HasChildren:true,_ChildrenList:new List<DataTypes.XMLNode> {new DataTypes.XMLNode("ИНН") }),
                 new DataTypes.XMLNode("НаименованиеОрганизации")
            };
        }
    }
}
