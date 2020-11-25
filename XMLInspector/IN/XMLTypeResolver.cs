using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLInspector.IN
{
    class XMLTypeResolver
    {
        
        public static List<DataTypes.XMLNode> Resolve(string FileName, string XMLVersion)
        {
            //resolve xmlversion first
            int TargetVersion = 51;
            switch (XMLVersion)
            {
                case "52.0":
                    TargetVersion = 52;
                    break;
                default:
                    break;
            }
            //and name second
            if (FileName.IndexOf("SPIN")!=-1)
            {
                if (TargetVersion == 52)
                {
                    return new BankNominalPen_52().Generate(); //52
                }
                else return new BankNominalPen().Generate(); //default is 51
            }
            if (FileName.IndexOf("SPIS")!=-1)
            {
                if (TargetVersion == 52)
                {
                    return new BankOrdinaryPen_52().Generate();
                }
                else return new BankOrdinaryPen().Generate();
            }
            return null;
        }
        public static string ResolveSpisPath(string FileName) //TODO: make this function respect xmlVersion as well
        {
            if (FileName.IndexOf("SPIN") != -1)
            {
                return new BankNominalPen().GetSpisPath();
            }
            if (FileName.IndexOf("SPIS") != -1)
            {
                return new BankOrdinaryPen().GetSpisPath();
            }
            return null;
        }

    }
}
