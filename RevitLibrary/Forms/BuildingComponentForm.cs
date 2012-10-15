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
using System.IO;

namespace RevitLibrary.Forms
{
    public partial class BuildingComponentForm : System.Windows.Forms.Form
    {
        public Document RevitDocument { get; set; }
        public DesignOption CurrentDesignOption { get; set; }
        public String ProjectName { get; set; }
        public Boolean ChangesMade { get; set; }
        private ElementManager manager;
        public BuildingComponentForm()
        {
            InitializeComponent();
        }

        private void BuildingComponentForm_Load(object sender, EventArgs e)
        {
            manager = new ElementManager(this.RevitDocument);
            lblDO.Text = CurrentDesignOption.Name;
            txtDODescription.Text = CurrentDesignOption.Description;

            List<BuildingComponent> comps = manager.getDesignOptionComponents(CurrentDesignOption);

            foreach (BuildingComponent bComp in comps)
            {
                bComp.Assemblies = manager.getComponentAssemblies(bComp);
                lbExistingComps.Items.Add(bComp);
            }
        }
        private void lblExistingComps_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            BuildingComponent bComp = (BuildingComponent)lbExistingComps.SelectedItem;
            if (bComp != null)
            {
                lbCompAssemblies.Items.Clear();
                foreach (Assembly assem in bComp.Assemblies)
                {
                    if(!assem.ToDelete)
                        lbCompAssemblies.Items.Add(assem);
                }
            }
        }
        private void lbCompAssemblies_MouseDoubleClick(object sender, System.EventArgs e)
        {
            Assembly selectedAssem = (Assembly) lbCompAssemblies.SelectedItem;

            if (selectedAssem != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(String.Format("{0}: {1}\n", "Assembly Name", selectedAssem.AssemblyName));
                sb.Append(String.Format("{0}: {1}\n", "Assembly Code", selectedAssem.AssemblyCode));
                sb.Append(String.Format("{0}: {1}\n", "Description", selectedAssem.Description));
                sb.Append(String.Format("{0}: {1:C}\n", "Cost Per Unit", selectedAssem.CalculateCostPerUnit()));
                sb.Append(String.Format("{0}: {1:#.####}\n", "CO2 Per Unit", selectedAssem.CalculateCO2PerUnit()));
                MessageBox.Show(sb.ToString());
            }
        }
        private void btnAssemblyDetails_Click(object sender, EventArgs e)
        {
            if (lbCompAssemblies.SelectedIndex < 0)
                MessageBox.Show("Please select an assembly to swap.");
            else
            {
                using (AssemblyDetailsForm dForm = new AssemblyDetailsForm())
                {
                    dForm.CurrentAssembly = (Assembly)lbCompAssemblies.SelectedItem;
                    dForm.RevitDocument = this.RevitDocument;
                    dForm.ShowDialog();

                    if (dForm.ChangesMade)
                    {
                        lbCompAssemblies.Items.RemoveAt(lbCompAssemblies.SelectedIndex);
                        lbCompAssemblies.Items.Add(dForm.CurrentAssembly);
                        lbCompAssemblies.SelectedItem = dForm.CurrentAssembly;
                        dForm.ChangesMade = false;
                    }
                }
                lbCompAssemblies.ClearSelected();
            }
        }
        private void btnAddComponent_Click(object sender, EventArgs e)
        {
            BuildingComponent newComp = new BuildingComponent();
            newComp.Name = txtCompName.Text;
            Boolean found = false;
            foreach(BuildingComponent comp in lbExistingComps.Items)
            {
                if(comp.Name.Equals(newComp.Name))
                {
                    MessageBox.Show("Component already exists.");
                    found = true;
                    break;
                }
            }
            if (!found)
                lbExistingComps.Items.Add(newComp);

            lbExistingComps.ClearSelected();
            txtCompName.Clear();
        }
        private void btnAddAssembly_Click(object sender, EventArgs e)
        {
            using (AssemblyDetailsForm dForm = new AssemblyDetailsForm())
            {
                dForm.RevitDocument = this.RevitDocument;
                dForm.IsAdd = true;
                dForm.ShowDialog();

                BuildingComponent currComp = (BuildingComponent)lbExistingComps.SelectedItem;
                currComp.Assemblies.Add(dForm.CurrentAssembly);
                if (dForm.CurrentAssembly != null) 
                    lbCompAssemblies.Items.Add(dForm.CurrentAssembly);
                dForm.ChangesMade = false;
            }
            lbCompAssemblies.ClearSelected();
        }
        private void btnRemoveAssembly_Click(object sender, EventArgs e)
        {
            if (lbCompAssemblies.SelectedIndex >= 0)
            {
                BuildingComponent currComp = (BuildingComponent)lbExistingComps.SelectedItem;
                currComp.Assemblies[lbCompAssemblies.SelectedIndex].ToDelete = true;
                lbCompAssemblies.Items.RemoveAt(lbCompAssemblies.SelectedIndex);
            }
            else
                MessageBox.Show("Please select an Assembly to remove.");
        }
        private void btnSaveDO_Click(object sender, EventArgs e)
        {
            DesignOption currDO = this.CurrentDesignOption;
            currDO.Description = txtDODescription.Text;
            currDO.Components.Clear();
            foreach (BuildingComponent bComp in lbExistingComps.Items)
                currDO.Components.Add(bComp);

            Boolean saved = manager.saveDesignOption(currDO, this.ProjectName);
            
            if(!saved)
                MessageBox.Show("Error on save!");
        }
    }
}
