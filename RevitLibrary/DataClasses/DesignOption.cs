using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RevitLibrary
{
    public class DesignOption
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public List<BuildingComponent> Components { get; set; }
        public override string ToString()
        {
            return Name;// +" - " + Description;
        }
        public DesignOption()
        {
            this.Components = new List<BuildingComponent>();
        }
    }
}
