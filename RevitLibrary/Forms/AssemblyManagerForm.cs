using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB;
using System.Data.OleDb;
using System.Xml;
using RevitLibrary.Forms;

namespace RevitLibrary
{
    public partial class AssemblyManagerForm : System.Windows.Forms.Form
    {
        public const int MAX_TO_SHOW = 100;

        public Autodesk.Revit.DB.Document RevitDocument { get; set; }
        public String GeneralCategory { get; set; }
        public AssemblyManagerForm()
        {
            InitializeComponent();
            areas = new Dictionary<string, double>();
            volumes = new Dictionary<string, double>();
            Assemblies = new Dictionary<string, Assembly>();
            comps = new Dictionary<String, BuildingComponent>();
        }
        private Dictionary<String, double> areas;
        private Dictionary<String, double> volumes;
        private Dictionary<String, Assembly> Assemblies;
        private Dictionary<String, BuildingComponent> comps;
        private DBManager manager;
        private void FillData(Assembly assem)
        {
            lbMaterials.Items.Clear();
            txtCO2.Clear();
            txtTotalArea.Clear();
            txtTotalVolume.Clear();
            txtCost.Clear();
            txtCategory.Text = assem.Category;
            double cost = assem.CalculateCostPerUnit();
            txtAssemblyCost.Text = (cost > 0) ? String.Format("{0:C}", cost) : "Unknown";
            double CO2 = assem.CalculateCO2PerUnit();
            txtAssemblyCO2.Text = (CO2 > 0) ? CO2.ToString() : "Unknown";
            foreach (AssemMaterial m in assem.Materials)
                lbMaterials.Items.Add(m);
        }
        private void AssemblyManagerForm_Load(object sender, EventArgs e)
        {
            manager = new DBManager(RevitDocument);
            List<Assembly> currentAssemblies = null;
            switch (this.GeneralCategory)
            {
                case "Wall":
                    currentAssemblies = manager.RetrieveWallInfo();
                    break;
                case "Roofing":
                    currentAssemblies = manager.RetrieveRoofingInfo();
                    break;
                case "Floor":
                    currentAssemblies = manager.RetrieveFloorInfo();
                    break;
                case "All":
                    currentAssemblies = manager.RetrieveWallInfo();
                    currentAssemblies.AddRange(manager.RetrieveRoofingInfo());
                    currentAssemblies.AddRange(manager.RetrieveFloorInfo());
                    break;
                default:
                    break;
            }
            if (currentAssemblies != null)
                calculateAreas_Volumes(currentAssemblies);

            int projectID = manager.getProjectID(this.RevitDocument.Title);
            if (projectID > 0)
            {
                foreach (BuildingComponent comp in comps.Values)
                {
                    comp.Assemblies = manager.getComponentOptions(comp, projectID);
                }
            }
            foreach (Assembly assem in Assemblies.Values)
            {
                if(!lbAssemblies.Items.Contains(assem))
                    lbAssemblies.Items.Add(assem);
            }
        }
        private void calculateAreas_Volumes(List<Assembly> assemblies)
        {
            for(int i = 0; i < assemblies.Count(); i++)
            {
                Assembly assem = assemblies[i];
                String code = assem.AssemblyCode;
                if (areas.ContainsKey(code))
                {
                    double area = areas[assem.AssemblyCode];
                    areas[code] = area + assem.Area;
                }
                else
                {
                    areas.Add(code, assem.Area);
                    BuildingComponent bComp = new BuildingComponent();
                    bComp.Name = assem.AssemblyName;
                    bComp.Description = assem.Description;
                    bComp.Category = this.GeneralCategory;
                    Assemblies.Add(code, assem);
                    comps.Add(code, bComp);
                }

                if (volumes.ContainsKey(code))
                {
                    double volume = volumes[assem.AssemblyCode];
                    volumes[code] = volume + assem.Volume;
                }
                else
                    volumes.Add(code, assem.Volume);
            }
        }
        private void lbAssemblies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbAssemblies.SelectedItem == null)
                return;
            String code = ((Assembly)lbAssemblies.SelectedItem).AssemblyCode;
            String category = AssemblyUtil.GetCategoryFromCode(code);
            Assembly assem = Assemblies[code];
            assem.Category = category;
            FillData(assem);
            txtTotalArea.Text = areas[assem.AssemblyCode].ToString();
            txtTotalVolume.Text = volumes[assem.AssemblyCode].ToString();
            assem.Area = areas[assem.AssemblyCode];
            assem.Volume = volumes[assem.AssemblyCode];
            lbAssemOptions.Items.Clear();
            lbSelectedOptions.Items.Clear();
            List<Assembly> selected = comps[code].Assemblies;
            foreach (Assembly sel in selected)
                lbSelectedOptions.Items.Add(sel);

            List<Assembly> options = manager.getAssembliesByCategory(category, MAX_TO_SHOW);
            foreach (Assembly a in options)
                 lbAssemOptions.Items.Add(a);
        }
        private void lbAssemOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            Assembly assem = (Assembly)lbAssemOptions.SelectedItem;
            List<AssemMaterial> materials = manager.getMaterialsByAssemblyName(assem.AssemblyName);
            FillData(assem);
        }
        private void lbMaterials_SelectedIndexChanged(object sender, EventArgs e)
        {
            AssemMaterial mat = (AssemMaterial)lbMaterials.SelectedItem;
            txtCost.Text = (mat.CostPerUnit > 0 ? String.Format("{0:C}", mat.CostPerUnit): "Unknown");
            txtCO2.Text = (mat.CO2PerUnit > 0 ? String.Format("{0:0.###}", mat.CO2PerUnit) : "Unknown");
        }
        private void btnWriteOut_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDlg = new SaveFileDialog())
            {
                saveDlg.Title = "Save Assembly Options";
                saveDlg.Filter = "XML File|*.xml";
                saveDlg.ShowDialog();

                if (!String.IsNullOrEmpty(saveDlg.FileName))
                {
                    List<Assembly> assems = new List<Assembly>();
                    foreach(Object obj in lbAssemblies.Items)
                        assems.Add((Assembly)obj);


                    this.WriteData(saveDlg.FileName, comps.Values.ToList());
                    //this.WriteData(saveDlg.FileName, comps.Values.ToList(), this.GeneralCategory);
                    //switch(this.GeneralCategory)
                    //{
                    //    case "Wall":
                    //        manager.WriteOutWalls(saveDlg.FileName, comps.Values);
                    //        break;
                    //    default:
                    //        break;
                    //}
                }
            }
        }

        private void WriteData(String fName, List<BuildingComponent> comps)
        {
            using (XmlWriter writer = XmlWriter.Create(fName))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("ComponentData");
                foreach (BuildingComponent bComp in comps)
                {
                    //available assembly data
                    writer.WriteStartElement("Component");
                    writer.WriteElementString("Name", bComp.Name);
                    writer.WriteElementString("Description", bComp.Description);

                    //write out alternatives
                    foreach (Assembly opt in bComp.Assemblies)
                    {
                        writer.WriteStartElement("Alternative");
                        writer.WriteElementString("Name", opt.AssemblyName);
                        writer.WriteElementString("Code", opt.AssemblyCode);
                        writer.WriteElementString("Category", opt.Category);
                        writer.WriteElementString("Area", opt.Area.ToString());
                        writer.WriteElementString("Volume", opt.Volume.ToString());
                        writer.WriteElementString("CostPerUnit", opt.CalculateCostPerUnit().ToString());
                        writer.WriteElementString("CO2PerUnit", opt.CalculateCO2PerUnit().ToString());
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }
        private void WriteData(String fName, List<BuildingComponent> comps, String category)
        {
            using (XmlWriter writer = XmlWriter.Create(fName))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement(category + "Data");
                foreach (BuildingComponent bComp in comps)
                {
                    //available assembly data
                    writer.WriteStartElement("Existing" + category);
                    writer.WriteElementString("Name", bComp.Name);
                    writer.WriteElementString("Description", bComp.Description);
                    
                    //write out alternatives
                    foreach (Assembly opt in bComp.Assemblies)
                    {
                        writer.WriteStartElement("Alternative");
                        writer.WriteElementString("Name", opt.AssemblyName);
                        writer.WriteElementString("Code", opt.AssemblyCode);
                        writer.WriteElementString("Category", opt.Category);
                        writer.WriteElementString("Area", opt.Area.ToString());
                        writer.WriteElementString("Volume", opt.Volume.ToString());
                        writer.WriteElementString("CostPerUnit", opt.CalculateCostPerUnit().ToString());
                        writer.WriteElementString("CO2PerUnit", opt.CalculateCO2PerUnit().ToString());
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }

        private void lbAssemOptions_MouseDoubleClick(object sender, EventArgs eDoubleClick)
        {
            Assembly selectedAssem;
            if (lbAssemblies.SelectedItem != null)
            {
                
                selectedAssem = (Assembly)lbAssemblies.SelectedItem;
                BuildingComponent bComp = comps[selectedAssem.AssemblyCode];

                Assembly assem = (Assembly)lbAssemOptions.SelectedItem;
                if (lbAssemOptions.SelectedItem != null && !lbSelectedOptions.Items.Contains(assem))
                {
                    bComp.Assemblies.Add(assem);
                    lbSelectedOptions.Items.Add(assem);
                }
            }
        }
        private void btnSaveOptions_Click(object sender, EventArgs e)
        {
            int projID = manager.SaveProject(this.RevitDocument.Title);
            if (projID > 0)
            {
                manager.deleteOldComponentsFromProject(projID);
                manager.saveComponentsToProject(projID, comps.Values.ToList());
                MessageBox.Show(String.Format("Successfully Saved Project: {0}", projID));
            }
            else
            {
                MessageBox.Show("Failed to Save Project.");
            }
                
        }
        private void btnRemoveOption_Click(object sender, EventArgs e)
        {
            if (lbAssemblies.SelectedItem != null && lbSelectedOptions.SelectedItem != null)
            {
                Assembly toRemove = (Assembly)lbSelectedOptions.SelectedItem;
                comps[((Assembly)lbAssemblies.SelectedItem).AssemblyCode].Assemblies.Remove(toRemove);
                lbSelectedOptions.Items.RemoveAt(lbSelectedOptions.SelectedIndex);
            }
        }

        private void btnCompOrder_Click(object sender, EventArgs e)
        {
            using (PhysicalScheduleForm phyFrm = new PhysicalScheduleForm())
            {
                phyFrm.Components = comps.Values.ToList();
                if (phyFrm.ShowDialog() == DialogResult.OK)
                    MessageBox.Show("Successfully saved Basic Schedule");
            }
        }
    }
}
