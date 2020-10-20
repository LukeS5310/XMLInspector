using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLInspector
{
    class DataTypes
    {
        public struct XMLNode
        {
            public string Name;
            public bool IsMandatory; //Должен присутствовать   
            public bool HasChildren; //Есть ли дочерние элементы
            public bool IsMultiple; //Множественный ли элемент
            public List<XMLNode> ChildrenList; //лист с дочерними элементами
            //expansion should include attributes valuetype etc, not needed atm
            public XMLNode(string _Name, bool _IsMandatory= true,bool _HasChildren = false, bool _IsMultiple = false,List<XMLNode> _ChildrenList = null)
            {
                Name = _Name;
                IsMandatory = _IsMandatory;
                HasChildren = _HasChildren;
                IsMultiple = _IsMultiple;
                ChildrenList = _ChildrenList;
            }
        }
    }
}
