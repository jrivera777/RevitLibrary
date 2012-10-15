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

namespace RevitLibrary.Forms
{
    public partial class ResultsForm : Form
    {
        public ResultsForm()
        {
            InitializeComponent();
        }
        public List<ProjectResult> Results { get; set; }
        private void ResultsForm_Load(object sender, EventArgs e)
        {
            lbProjects.Items.AddRange(this.Results.ToArray());
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

        private void btnTimeVsCost_Click(object sender, EventArgs e)
        {
            DataVisualizer dvFrm = new DataVisualizer();
            dvFrm.Projects = this.Results;
            dvFrm.CompareType = DataVisualizer.Comparison.TIMEVCOST;
            dvFrm.Show();
        }

        private void btnTimeVSEI_Click(object sender, EventArgs e)
        {
            DataVisualizer dvFrm = new DataVisualizer();
            dvFrm.Projects = this.Results;
            dvFrm.CompareType = DataVisualizer.Comparison.TIMEVEI;
            dvFrm.Show();
        }

        private void btnCostVSEI_Click(object sender, EventArgs e)
        {
            DataVisualizer dvFrm = new DataVisualizer();
            dvFrm.Projects = this.Results;
            dvFrm.CompareType = DataVisualizer.Comparison.COSTVEI;
            dvFrm.Show();
        }

        private void btn3D_Click(object sender, EventArgs e)
        {
            Form3DViewer viewer = new Form3DViewer();
            viewer.Projects = this.Results;
            viewer.Show();
        }
    }
}
