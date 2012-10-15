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
            sb.Append("Total Cost - " + this.TotalCost.ToString() + ", ");
            sb.Append("Total EI - " + this.TotalEI.ToString() + ", ");
            sb.Append("Total Duration - " + this.TotalDuration.ToString());
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
