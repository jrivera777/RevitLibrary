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

namespace RevitLibrary.New_Forms
{
    public partial class ResultSelectedAssembliesForm : Form
    {
        public ProjectResult Project { get; set; }
        public ResultSelectedAssembliesForm()
        {
            InitializeComponent();
        }

        private void ResultSelectedAssembliesForm_Load(object sender, EventArgs e)
        {
            this.Text = "Selected Components for " + Project.ProjectName;
            lblProject.Text = Project.ProjectName;
            foreach (Assembly assem in Project.SelectedAssemblies)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(assem.Category + ":" + System.Environment.NewLine);
                sb.Append("\t" + assem.AssemblyName + System.Environment.NewLine);
                sb.Append("\tCost:" + assem.Cost + System.Environment.NewLine);
                sb.Append("\tEI:" + assem.CO2 + System.Environment.NewLine);
                sb.Append("\tTime:" + assem.Duration + System.Environment.NewLine + System.Environment.NewLine);
                txtAssemblies.Text += sb.ToString();
            }
        }
    }
}
