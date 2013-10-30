using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RevitLibrary.DataClasses;
using RevitLibrary.New_Forms;
using System.Diagnostics;

namespace RevitLibrary.Forms
{
    public partial class ResultsForm : Form
    {
        public ResultsForm()
        {
            InitializeComponent();
        }
        public List<ProjectResult> Results { get; set; }
        public String FileName { get; set; }
        private void ResultsForm_Load(object sender, EventArgs e)
        {
            lbProjects.Items.AddRange(this.Results.ToArray());
            cbSortBy.SelectedIndex = 1;
        }

        private void lbProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lbProjects.SelectedIndex >= 0)
            {
                ProjectResult proj = (ProjectResult)lbProjects.SelectedItem;

                txtName.Text = proj.ProjectName;
                txtCost.Text = String.Format("{0:c}", proj.TotalCost);
                txtEI.Text = proj.TotalEI.ToString();
                txtDuration.Text = proj.TotalDuration.ToString();
            }
        }
        private void lbProjects_MouseDoubleClick(object sender, MouseEventArgs args)
        {
            if (lbProjects.SelectedIndex >= 0)
            {
                ProjectResult res = (ProjectResult)lbProjects.SelectedItem;
                ResultSelectedAssembliesForm rFrm = new ResultSelectedAssembliesForm();
                rFrm.Project = res;
                rFrm.Show();        
            }
        }
        private void btnTimeVsCost_Click(object sender, EventArgs e)
        {
            DataVisualizer dvFrm = new DataVisualizer();
            dvFrm.Owner = this;
            dvFrm.Projects = this.Results;
            dvFrm.CompareType = DataVisualizer.Comparison.TIMEVCOST;
            dvFrm.Text = "Time VS Cost";
            dvFrm.Show();
        }

        private void btnTimeVSEI_Click(object sender, EventArgs e)
        {
            DataVisualizer dvFrm = new DataVisualizer();
            dvFrm.Owner = this;
            dvFrm.Projects = this.Results;
            dvFrm.CompareType = DataVisualizer.Comparison.TIMEVEI;
            dvFrm.Text = "Time VS EI";
            dvFrm.Show();
        }

        private void btnCostVSEI_Click(object sender, EventArgs e)
        {
            DataVisualizer dvFrm = new DataVisualizer();
            dvFrm.Owner = this;
            dvFrm.Projects = this.Results;
            dvFrm.CompareType = DataVisualizer.Comparison.COSTVEI;
            dvFrm.Text = "Cost VS EI";
            dvFrm.Show();
        }

        private void btn3D_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            List<ProjectResult> projs = Results;
            IComparer<ProjectResult> comparer = null;
            switch(cbSortBy.SelectedIndex)
            {
                case 0:
                    comparer = new TimeComparator();
                    break;
                case 1:
                    comparer = new CostComparator();
                    break;
                case 2:
                    comparer = new EIComparator();
                    break;
                default:
                    return;
                
            }
            projs.Sort(comparer);
            lbProjects.Items.Clear();
            lbProjects.Items.AddRange(projs.ToArray());
        }

        private class CostComparator : IComparer<ProjectResult>
        {
            int IComparer<ProjectResult>.Compare(ProjectResult x, ProjectResult y)
            {
                if (x.TotalCost > y.TotalCost)
                    return 1;
                else if (x.TotalCost < y.TotalCost)
                    return -1;
                return 0;
            }
        }
        private class TimeComparator : IComparer<ProjectResult>
        {
            int IComparer<ProjectResult>.Compare(ProjectResult x, ProjectResult y)
            {
                if (x.TotalDuration > y.TotalDuration)
                    return 1;
                else if (x.TotalDuration < y.TotalDuration)
                    return -1;
                else
                {
                    if (x.TotalCost > y.TotalCost)
                        return 1;
                    else if (x.TotalCost < y.TotalCost)
                        return -1;
                    return 0;
                }
            }
        }
        private class EIComparator : IComparer<ProjectResult>
        {
            int IComparer<ProjectResult>.Compare(ProjectResult x, ProjectResult y)
            {
                if (x.TotalEI > y.TotalEI)
                    return 1;
                else if (x.TotalEI < y.TotalEI)
                    return -1;
                return 0;
            }
        }
    }
}
