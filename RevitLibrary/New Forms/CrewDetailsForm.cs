using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RevitLibrary.DataClasses;

namespace RevitLibrary.New_Forms
{
    public partial class CrewDetailsForm : Form
    {
        public Crew CurrentCrew { get; set; }
        public CrewDetailsForm()
        {
            InitializeComponent();
        }

        private void CrewDetailsForm_Load(object sender, EventArgs e)
        {
            if (CurrentCrew == null)
                this.Close();
            else
            {
                txtName.Text = CurrentCrew.Name;
                txtDetails.Text = CurrentCrew.Details;
                txtHourlyCost.Text = String.Format("{0:C}", CurrentCrew.BareHourlyCost);
                txtDailyCost.Text = String.Format("{0:C}", CurrentCrew.BareDailyCost);
            }
        }
    }
}
