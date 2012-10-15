using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RevitLibrary.DataClasses;

namespace RevitLibrary
{
    public class AssemMaterial
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public double CostPerUnit { get; set; }
        public double CO2PerUnit { get; set; }
        public double RValue { get; set; }
        public String Unit { get; set; }
        public String MaterialCode { get; set; }
        public override string ToString()
        {
            return this.Name + " - " + this.Description;
        }
        public MaterialLabor Labor { get; set; }
        public MaterialSummary Summary { get; set; }
    }
}
