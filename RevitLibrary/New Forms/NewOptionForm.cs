using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB;

namespace RevitLibrary.New_Forms
{
    public partial class NewOptionForm : System.Windows.Forms.Form
    {
        public Document RevitDocument { get; set; }
        public Assembly CreatedOption { get; set; }
        public String AssemCategory { get; set; }
        public String AssemCode { get; set; }
        public double CompArea { get; set; }
        public double CompVolume { get; set; }
        public NewOptionForm()
        {
            InitializeComponent();
        }
        private void NewOptionForm_Load(object sender, EventArgs e)
        {
            CreatedOption = new Assembly();
        }

        private void CalculateTimeCostEI()
        {
            double cost = CreatedOption.CalculateCostPerUnit();
            double co2 = CreatedOption.CalculateCO2PerUnit();
            double dur = CreatedOption.CalculateRoughDuration(CompArea, CompVolume);
            txtCost.Text = cost.ToString();
            txtEI.Text = co2.ToString();
            txtDuration.Text = dur.ToString();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtName.Text) || String.IsNullOrEmpty(txtDuration.Text)
                || String.IsNullOrEmpty(txtCost.Text) || String.IsNullOrEmpty(txtEI.Text))
            {
                DialogResult = DialogResult.Abort;
                MessageBox.Show("Missing option name, duration, cost, or EI.");
                return;
            }
            else
            {
                Assembly assem = new Assembly();
                CreatedOption.AssemblyName = txtName.Text;
                CreatedOption.AssemblyCode = txtCode.Text;
                CreatedOption.Description = txtDesc.Text;
                CreatedOption.Cost = Double.Parse(txtCost.Text);
                CreatedOption.CO2 = Double.Parse(txtEI.Text);
                CreatedOption.Duration = Double.Parse(txtDuration.Text);
                //foreach(AssemMaterial mat in lbMaterials.Items)
                //    createdOption.Materials.Add(mat);

                DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void btnaddMaterial_Click(object sender, EventArgs e)
        {
            AssemMaterial mat = null;
            using (MaterialForm matFrm = new MaterialForm())
            {
                DialogResult res = matFrm.ShowDialog();
                if (res == DialogResult.OK)
                {
                    mat = matFrm.createdMaterial;
                    lbMaterials.Items.Add(mat);
                    CreatedOption.Materials.Add(mat);
                    CalculateTimeCostEI();
                }
            }
        }

        private void btnDeleteMaterial_Click(object sender, EventArgs e)
        {
            if (lbMaterials.SelectedIndex < 0)
                MessageBox.Show("Please select a material to delete.");
            else
            {
                this.CreatedOption.Materials.Remove((AssemMaterial)lbMaterials.SelectedItem);
                lbMaterials.Items.RemoveAt(lbMaterials.SelectedIndex);
            }
            clearCalculations();
        }

        private void btnSaveOption_Click(object sender, EventArgs e)
        {
            double duration = 0;
            if (String.IsNullOrEmpty(txtName.Text))
                MessageBox.Show("Please enter a valid Assembly Name.");
            else if (String.IsNullOrEmpty(txtCode.Text))
                MessageBox.Show("Please enter a valid Assembly Code.");
            else if (String.IsNullOrEmpty(txtDuration.Text) || !Double.TryParse(txtDuration.Text, out duration))
                MessageBox.Show("Please enter a valid duration.");
            else if (CreatedOption.Materials.Count() <= 0)
                MessageBox.Show("Assembly must contain at least one material.");
            else
            {
                CreatedOption.AssemblyName = txtName.Text;
                CreatedOption.AssemblyCode = txtCode.Text;
                CreatedOption.Description = txtDesc.Text;
                CreatedOption.Cost = Double.Parse(txtCost.Text);
                CreatedOption.CO2 = Double.Parse(txtEI.Text);
                CreatedOption.Duration = Double.Parse(txtDuration.Text);
                CreatedOption.Category = this.AssemCategory;

                ElementManager manager = new ElementManager(RevitDocument);
                if (!manager.saveAssembly(CreatedOption))
                    MessageBox.Show("Failed to save Option.");
            }
        }

        private void clearCalculations()
        {
            txtCost.Clear();
            txtEI.Clear();
            txtDuration.Clear();
        }
    }
    
}
