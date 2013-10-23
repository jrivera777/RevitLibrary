using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RevitLibrary.DataClasses
{
    public class ProjectResult
    {
        public String ProjectName { get; set; }
        public double TotalCost { get; set; }
        public double TotalEI { get; set; }
        public double TotalDuration { get; set; }
        public List<Assembly> SelectedAssemblies { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.ProjectName + ": ");
            sb.Append(String.Format("Total Cost - {0:C}, ", this.TotalCost));
            sb.Append(String.Format("Total EI - {0}, ", this.TotalEI));
            sb.Append(String.Format("Total Duration - {0} ", this.TotalDuration));
            return sb.ToString();
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (this.GetType() != obj.GetType())
                return false;

            return this.Equals((ProjectResult)obj);
        }
        private Boolean Equals(ProjectResult that)
        {
            if (that == null)
                return false;

            return this.TotalCost == that.TotalCost && this.TotalEI == that.TotalEI && this.TotalDuration == that.TotalDuration;
        }
    }
}
