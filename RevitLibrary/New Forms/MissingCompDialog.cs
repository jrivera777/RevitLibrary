using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RevitLibrary.New_Forms
{
    public partial class MissingCompDialog : Form
    {
        public double Area { get; set; }
        public double Volume { get; set; }
        public String Name { get; set; }
        public String Category { get; set; }
        public String Code { get; set; }
        public MissingCompDialog()
        {
            InitializeComponent();
        }
        private void BasicInputDialog_Load(object sender, EventArgs e)
        {
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            double ar;
            double vol;

            if (String.IsNullOrEmpty(txtName.Text))
                MessageBox.Show("Please enter a valid component name.");
            else if (String.IsNullOrEmpty(txtCode.Text))
                MessageBox.Show("Please enter a valid assembly code.");
            else if (String.IsNullOrEmpty(txtArea.Text))
                MessageBox.Show("Please enter a valid area.");
            else if (String.IsNullOrEmpty(txtVolume.Text))
                MessageBox.Show("Please enter a valid volume.");
            else
            {
                if (Double.TryParse(txtArea.Text, out ar))
                    this.Area = ar;
                if (Double.TryParse(txtVolume.Text, out vol))
                    this.Volume = vol;
                this.Name = txtName.Text;
                this.Category = txtCategory.Text;
                this.Code = txtCode.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
