using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLInspector.IN
{
    abstract class CheckGenerator
    {
        public List<DataTypes.XMLNode> Generate()
        {
            List<DataTypes.XMLNode> Target = GenerateRoot();

            return Target;
        }
        public virtual string GetSpisPath()
        {
            return "ПачкаВходящихДокументов/СПИСОК_НА_ЗАЧИСЛЕНИЕ";
        }
        protected virtual List<DataTypes.XMLNode> GenerateRoot()
        {
            return new List<DataTypes.XMLNode>() //Level one CONSIDER COMMON
              {
                    new DataTypes.XMLNode("ИмяФайла"),
                    new DataTypes.XMLNode("ЗаголовокФайла",_HasChildren:true,_ChildrenList:GenerateZagF()),//ENTER LIST HERE
                    new DataTypes.XMLNode("ПачкаВходящихДокументов",_HasChildren:true,_ChildrenList:GeneratePVD()) //same here

              };
        }

        protected virtual List<DataTypes.XMLNode> GenerateZagF()
        {
            return new List<DataTypes.XMLNode>
            {
                 new DataTypes.XMLNode("ВерсияФормата"),
                 new DataTypes.XMLNode("ТипФайла"),
                 new DataTypes.XMLNode("ПрограммаПодготовкиДанных",_HasChildren:true,_ChildrenList:GeneratePrPoDan()),
                 new DataTypes.XMLNode("ИсточникДанных")
            };

        }
        protected virtual List<DataTypes.XMLNode> GeneratePrPoDan()
        {
            return new List<DataTypes.XMLNode>
            {
                new DataTypes.XMLNode("НазваниеПрограммы"),
                new DataTypes.XMLNode("Версия"),
                new DataTypes.XMLNode("ТекущаяВерсияФорматаОбмена")
            };
        }
        protected virtual List<DataTypes.XMLNode> GeneratePVD()
        {
            return new List<DataTypes.XMLNode>
            {
                 new DataTypes.XMLNode("ВХОДЯЩАЯ_ОПИСЬ",_HasChildren:true,_ChildrenList:GenerateInOpis()),
                  new DataTypes.XMLNode("СПИСОК_НА_ЗАЧИСЛЕНИЕ",_HasChildren:true,_ChildrenList:GenerateSpis()) //BIG BOY
            };
        }
        protected virtual List<DataTypes.XMLNode> GenerateInOpis()
        {
            return new List<DataTypes.XMLNode>
            {
                new DataTypes.XMLNode("НомерВпачке"),
                new DataTypes.XMLNode("ТипВходящейОписи"),
                new DataTypes.XMLNode("СоставительПачки",_HasChildren:true,_ChildrenList:GenerateSostPach()),
                new DataTypes.XMLNode("НомерПачки",_HasChildren:true,_ChildrenList:new List<DataTypes.XMLNode>{new DataTypes.XMLNode("Основной") }),
                new DataTypes.XMLNode("СоставДокументов",_HasChildren:true,_ChildrenList:GenerateSostDoc()),
                new DataTypes.XMLNode("ДатаСоставления"),
                new DataTypes.XMLNode("ТерриториальныйОрганПФР",_HasChildren:true,_ChildrenList:GenerateSostPach()),
                new DataTypes.XMLNode("НомерБанка"),
                new DataTypes.XMLNode("Банк",_HasChildren:true,_ChildrenList:new List<DataTypes.XMLNode>{new DataTypes.XMLNode("НаименованиеОрганизации") }),
                new DataTypes.XMLNode("НомерПлатежногоПоручения",_IsMandatory:false),
                new DataTypes.XMLNode("ДатаПлатежногоПоручения",_IsMandatory:false),
                new DataTypes.XMLNode("НомерДоговораОзачисленииСуммПенсий"),
                new DataTypes.XMLNode("ДатаДоговораОзачисленииСуммПенсий"),
                new DataTypes.XMLNode("СистемныйНомерМассива"),
                new DataTypes.XMLNode("ТипМассиваПоручений"),
                new DataTypes.XMLNode("Месяц"),
                new DataTypes.XMLNode("Год"),
                new DataTypes.XMLNode("ОбщаяСуммаПоМассиву"),
                new DataTypes.XMLNode("ОбщееКоличествоПорученийПоМассиву"),
                new DataTypes.XMLNode("КоличествоЧастейМассива"),
                new DataTypes.XMLNode("НомерЧастиМассива"),
                new DataTypes.XMLNode("СуммаПоЧастиМассива"),
                new DataTypes.XMLNode("КоличествоПорученийПоЧастиМассива"),
                new DataTypes.XMLNode("Должность"),
                new DataTypes.XMLNode("Руководитель"),
            };
        }
        protected virtual List<DataTypes.XMLNode> GenerateSostPach()
        {
            return new List<DataTypes.XMLNode>
            {
                new DataTypes.XMLNode("НалоговыйНомер",_HasChildren:true,_ChildrenList:new List<DataTypes.XMLNode>{new DataTypes.XMLNode("ИНН"),new DataTypes.XMLNode("КПП") }),
                new DataTypes.XMLNode("НаименованиеОрганизации"),
                new DataTypes.XMLNode("РегистрационныйНомер")
            };
        }
        protected virtual List<DataTypes.XMLNode> GenerateSostDoc()
        {
            return new List<DataTypes.XMLNode>
            {
                new DataTypes.XMLNode("Количество"),
                new DataTypes.XMLNode("НаличиеДокументов",_HasChildren:true,_IsMultiple:true,_ChildrenList:new List<DataTypes.XMLNode>{new DataTypes.XMLNode("ТипДокумента"),new DataTypes.XMLNode("Количество") })
            };
        }


        protected virtual List<DataTypes.XMLNode> GenerateSpis()
        {
            return new List<DataTypes.XMLNode>
            {
                new DataTypes.XMLNode("НомерВпачке"),
                new DataTypes.XMLNode("СведенияОполучателе",_HasChildren:true,_IsMultiple:true, _ChildrenList:GenerateSved()),
                new DataTypes.XMLNode("СуммаПоФилиалу"),
                new DataTypes.XMLNode("КоличествоПолучателей"),
                new DataTypes.XMLNode("ДатаВыдачиДокумента")
            };
        }
        protected virtual List<DataTypes.XMLNode> GenerateSved()
        {
            return new List<DataTypes.XMLNode>
            {
                new DataTypes.XMLNode("НомерВмассиве"),
                new DataTypes.XMLNode("НомерВыплатногоДела"),
                new DataTypes.XMLNode("КодРайона"),
                new DataTypes.XMLNode("СтраховойНомер"),
                new DataTypes.XMLNode("ФИО",_HasChildren:true,_ChildrenList:new List<DataTypes.XMLNode>{new DataTypes.XMLNode("Фамилия"),new DataTypes.XMLNode("Имя"),new DataTypes.XMLNode("Отчество",false) }),
                new DataTypes.XMLNode("НомерСчета"),
                new DataTypes.XMLNode("ВсеВыплаты",_HasChildren:true,_ChildrenList:GenerateVplList()),
                new DataTypes.XMLNode("ВсеУдержания",_IsMandatory:false,_HasChildren:true,_ChildrenList:GenerateUderList()),
                new DataTypes.XMLNode("СуммаКдоставке"),
                new DataTypes.XMLNode("СлужебнаяИнформация",_IsMandatory:false)
            };
        }
        protected virtual List<DataTypes.XMLNode> GenerateVplList()
        {
            return new List<DataTypes.XMLNode>
            {
                new DataTypes.XMLNode("Количество"),
                new DataTypes.XMLNode("Выплата",_HasChildren:true,_IsMultiple:true,_ChildrenList:GenerateVplItem())
            };
        }
        protected virtual List<DataTypes.XMLNode> GenerateVplItem()
        {
            return new List<DataTypes.XMLNode>
            {
                new DataTypes.XMLNode("ПризнакВыплаты"),
                new DataTypes.XMLNode("НачисленнаяСумма"),
                new DataTypes.XMLNode("СуммаКвыплате"),
                new DataTypes.XMLNode("ДатаНачалаПериода"),
                new DataTypes.XMLNode("ДатаКонцаПериода"),
                new DataTypes.XMLNode("ВидВыплатыПоПЗ"),

            };
        }
        protected virtual List<DataTypes.XMLNode> GenerateUderList()
        {
            return new List<DataTypes.XMLNode>
            {
                new DataTypes.XMLNode("Количество"),
                new DataTypes.XMLNode("ОбщаяСуммаУдержаний"),
                new DataTypes.XMLNode("УдержанияПоДокументу",_HasChildren:true,_IsMultiple:true,_ChildrenList:GenerateUderItem())
            };
        }

        protected virtual List<DataTypes.XMLNode> GenerateUderItem()
        {
            return new List<DataTypes.XMLNode>
            {
                new DataTypes.XMLNode("КодДокументаПоУдержаниям"),
                new DataTypes.XMLNode("СведенияОдокументе"),
                new DataTypes.XMLNode("ВидУдержания"),
                new DataTypes.XMLNode("СуммаУдержанияПоДокументу"),
                new DataTypes.XMLNode("УдержаниеПоВидуВыплаты",_HasChildren:true,_IsMultiple:true,_ChildrenList:new List<DataTypes.XMLNode>{new DataTypes.XMLNode("СуммаУдержания"),new DataTypes.XMLNode("ВидВыплатыПоПЗ") })
            };
        }

    }   


}
