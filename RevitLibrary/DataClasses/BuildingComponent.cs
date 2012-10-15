using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RevitLibrary.DataClasses;

namespace RevitLibrary
{
    public class BuildingComponent
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public Boolean ToDelete { get; set; }
        public List<Assembly> Assemblies { get; set; }
        public String Category { get; set; }
        public double Area { get; set; }
        public double Volume { get; set; }
        

        public override string ToString()
        {
            return Name;
        }
        public BuildingComponent()
        {
            this.Assemblies = new List<Assembly>();
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (this.GetType() != obj.GetType())
                return false;

            return this.Equals((BuildingComponent)obj);
        }
        private Boolean Equals(BuildingComponent that)
        {
            if (that == null)
                return false;

            return this.Name.Equals(that.Name);
        }
    }
}
