using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RevitLibrary.DataClasses
{
    public class Crew
    {
        public String Name { get; set; }
        public double BareHourlyCost { get; set; }
        public double BareDailyCost { get; set; }
        public String Details { get; set; }
        public String Category { get; set; }

        public override String ToString()
        {
            return this.Name;
        }
    }
}
