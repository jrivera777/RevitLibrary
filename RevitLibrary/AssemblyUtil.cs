using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RevitLibrary
{
    class AssemblyUtil
    {
        public static String GetCategoryFromCode(String code)
        {
            String category = "";
            if (Regex.IsMatch(code, "B2010.*", RegexOptions.IgnoreCase))
                category = "Exterior Wall";
            else if (Regex.IsMatch(code, "C1010.*", RegexOptions.IgnoreCase))
                category = "Interior Partition";
            else if (Regex.IsMatch(code, "B1020.*", RegexOptions.IgnoreCase))
                category = "Roofing";
            else if (Regex.IsMatch(code, "A10.*", RegexOptions.IgnoreCase))
                category = "Foundation";
            return category;
        }
    }
}
