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
namespace RevitLibrary.Forms
{
    public partial class AssemblyDetailsForm : System.Windows.Forms.Form
    {
        public Assembly CurrentAssembly { get; set; }
        public Document RevitDocument { get; set; }
        public Boolean ChangesMade { get; set; }
        public Boolean IsAdd { get; set; }
        private Assembly toSwap;
        private ElementManager manager;
        public AssemblyDetailsForm()
        {
            InitializeComponent();
        }

        private void AssemblyDetailsForm_Load(object sender, EventArgs e)
        {
            manager = new ElementManager(RevitDocument);

            //if (this.IsAdd)
            //{
            //    lblTitle.Text = "";
            //}
            //else
            //{
                toSwap = CurrentAssembly;
            //    lblToSwap.Text = toSwap.AssemblyName;
                loadInformation(toSwap);
            //}
            List<Assembly> fromModel = manager.RetrieveWallInfo();
            //List<Assembly> options = null;
            //if (this.IsAdd)
            //options = manager.getAllAssemblies();
            //options.AddRange(fromModel);
            
            //else
            //    options = manager.getAssembliesByCode(toSwap.AssemblyCode);
            //if (options != null)
            //{
            //    foreach (Assembly a in options)
            //        cboAlternatives.Items.Add(a);
            //}
        }
        private void loadInformation(Assembly assem)
        {
            txtName.Text = assem.AssemblyName;
            txtCode.Text = assem.AssemblyCode;
            txtDescription.Text = assem.Description;
            lblCostPerUnit.Text = String.Format("{0:C}", assem.CalculateCostPerUnit());
            lblCO2PerUnit.Text = String.Format("{0:#.####}", assem.CalculateCO2PerUnit());

            lbMaterials.Items.Clear();
            lblCO2.Text = "";
            lblCost.Text = "";
            if (assem.Materials != null)
            {
                foreach (AssemMaterial mat in assem.Materials)
                    lbMaterials.Items.Add(mat);
            }
        }
        private void lblMaterials_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCO2.Text = "";
            lblCost.Text = "";
            double cost = 0.0;
            double co2 = 0.0;
            AssemMaterial mat = (AssemMaterial)lbMaterials.SelectedItem;
            if (mat != null)
            {
                switch (mat.Unit.ToLower())
                {
                    case "s.f.": //standard measure square feet
                        cost = mat.CostPerUnit;
                        co2 = mat.CO2PerUnit;
                        break;
                    case "c.f.": //cubic yard (mainly for foundations)
                        cost = mat.CostPerUnit;
                        co2 = mat.CO2PerUnit;
                        break;
                    case "c.y.": //cubic yard (mainly for foundations)
                        cost = mat.CostPerUnit / 27;
                        co2 = mat.CO2PerUnit / 27;
                        break;
                    case "sq":   //square ==> 100 s.f.
                        cost = mat.CostPerUnit / 100;
                        co2 = mat.CO2PerUnit / 100;
                        break;
                    default:
                        //assume S.F. measurement for empty string and any other invalid unit
                        cost = mat.CostPerUnit;
                        co2 = mat.CO2PerUnit;
                        break;
                    //throw new Exception(String.Format("Cannot Parse unit of material: {0} for {1} - {2}", m.Unit.ToLower(), m.Name, m.Description));
                }
                lblCost.Text = String.Format("{0:C}", cost);
                lblCO2.Text = String.Format("{0:#.####}", co2);
            }
        }
        private void btnSaveAssembly_Click(object sender, EventArgs e)
        {
            if (cboAlternatives.SelectedIndex >= 0)
            {
                this.ChangesMade = true;
                this.CurrentAssembly = (Assembly)cboAlternatives.SelectedItem;
                this.Close();
            }
            else
            {
                if (this.IsAdd)
                    MessageBox.Show("No assembly was selected.  No addd will be done.");
                else
                    MessageBox.Show("No alternative was selected. No swap will be done.");
            }
        }
        private void cboAlternatives_SelectedIndexChanged(object sender, EventArgs e)
        {
            Assembly selected = (Assembly)cboAlternatives.SelectedItem;
            this.CurrentAssembly = selected;
            loadInformation(CurrentAssembly);
        }
    }
}
