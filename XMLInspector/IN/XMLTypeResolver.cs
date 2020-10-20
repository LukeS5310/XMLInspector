using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLInspector.IN
{
    class XMLTypeResolver
    {
        public static List<DataTypes.XMLNode> Resolve(string FileName)
        {
            if (FileName.IndexOf("SPIN")!=-1)
            {
                return new BankNominalPen().Generate();
            }
            if (FileName.IndexOf("SPIS")!=-1)
            {
                return new BankOrdinaryPen().Generate();
            }
            return null;
        }
        public static string ResolveSpisPath(string FileName)
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
