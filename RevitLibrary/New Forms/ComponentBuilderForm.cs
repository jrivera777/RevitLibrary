﻿using System;
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
using RevitLibrary.Forms;
using RevitLibrary.DataClasses;
using System.Xml;
using System.Diagnostics;
namespace RevitLibrary.New_Forms
{
    public partial class ComponentBuilderForm : System.Windows.Forms.Form
    {
        private ElementManager manager;
        private const String NSGAII_DIR = @"C:\Documents and Settings\fdot\My Documents\SIMULEICON\ikvm-7.1.4532.2\bin\";
        private Dictionary<String, double> areas = new Dictionary<string, double>();
        private Dictionary<String, double> volumes = new Dictionary<string, double>();
        private Dictionary<String, Assembly> Assemblies = new Dictionary<string, Assembly>();
        private Dictionary<String, BuildingComponent> comps = new Dictionary<String, BuildingComponent>();
        public Document RevitDocument { get; set; }
        public ComponentBuilderForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtCompName.Text))
            {
                MessageBox.Show("Please enter a component name.");
                return;
            }
            //if(cboFoundInModel.SelectedIndex < 0)
            //{
            //    MessageBox.Show("Please select a component from the model to associate.");
            //    return;
            //}

            BuildingComponent comp = null;
            if (cboFoundInModel.SelectedIndex < 0)
            {
                using (MissingCompDialog inputDlg = new MissingCompDialog())
                {
                    
                    inputDlg.ShowDialog();
                    if (inputDlg.DialogResult == DialogResult.OK)
                    {
                        comp = new BuildingComponent();
                        comp.Name = txtCompName.Text.Trim();
                        comp.Description = txtCompDesc.Text.Trim();
                        comp.Category = inputDlg.Text;
                        comp.Area = inputDlg.Area;
                        comp.Volume = inputDlg.Volume;
                        comp.Category = inputDlg.Category;

                        Assembly assoc = new Assembly();
                        assoc.AssemblyName = inputDlg.Name;
                        assoc.Category = inputDlg.Category;
                        assoc.Area = inputDlg.Area;
                        assoc.Volume = inputDlg.Volume;
                        assoc.AssemblyCode = inputDlg.Code;

                        cboFoundInModel.Items.Add(assoc);
                        List<Assembly> list = new List<Assembly>();
                        foreach (Assembly assem in cboFoundInModel.Items)
                            list.Add(assem);

                        if (list.Count > 0)
                            calculateAreas_Volumes(list);
                    }
                }
            }
            else
            {
                comp = new BuildingComponent();
                Assembly assoc = (Assembly)cboFoundInModel.SelectedItem;    
                comp.Name = txtCompName.Text;
                comp.Description = txtCompDesc.Text.Trim();
                comp.Category = txtCategory.Text;
                comp.Area = assoc.Area;
                comp.Volume = assoc.Volume;
            }
            if (comp == null)
                return;
            if (!lbComponents.Items.Contains(comp))
                lbComponents.Items.Add(comp);
            else
                MessageBox.Show("Component already exists.");

            ClearControls();
            clearComponentInfo();
        }
        private void ClearControls()
        {
            lbAssemblies.Items.Clear();
            lbComponents.SelectedIndex = -1;
            txtArea.Clear();
            txtVolume.Clear();
            cboFoundInModel.SelectedIndex = -1;
            txtCategory.Clear();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = lbComponents.SelectedIndex;
            if (index < 0)
                MessageBox.Show("Please select a component to delete.");
            else
                lbComponents.Items.RemoveAt(index);
            txtSelectedComp.Clear();
            ClearControls();
        }
        private void btnWrite_Click(object sender, EventArgs e)
        {
            if (lbComponents.Items.Count <= 0)
            {
                MessageBox.Show("No Components to Write out");
                return;
            }
            using (SaveFileDialog saveDlg = new SaveFileDialog())
            {
                saveDlg.Title = "Save Assembly Options";
                saveDlg.Filter = "XML File|*.xml";
                saveDlg.ShowDialog();

                if (!String.IsNullOrEmpty(saveDlg.FileName))
                {
                    List<BuildingComponent> compsToWrite = new List<BuildingComponent>();
                    foreach(Object obj in lbComponents.Items)
                        compsToWrite.Add((BuildingComponent)obj);


                    Boolean done = this.WriteData(saveDlg.FileName, compsToWrite);
                    if (done)
                        MessageBox.Show("Finished Writing XML file!");
                }
            }
        }
        private Boolean WriteData(String fName, List<BuildingComponent> comps)
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
                    writer.WriteElementString("Category", bComp.Category);
                    writer.WriteElementString("TotalComponentArea", bComp.Area.ToString());
                    writer.WriteElementString("TotalComponentVolume", bComp.Volume.ToString());
                    //write out alternatives
                    foreach (Assembly opt in bComp.Assemblies)
                    {
                        writer.WriteStartElement("Alternative");
                        writer.WriteElementString("Name", opt.AssemblyName);
                        writer.WriteElementString("Code", opt.AssemblyCode);
                        //writer.WriteElementString("Area", opt.Area.ToString());
                        //writer.WriteElementString("Volume", opt.Volume.ToString());
                        double cost = opt.CalculateCostPerUnit();
                        double co2 = opt.CalculateCO2PerUnit();
                        double duration = opt.CalculateRoughDuration(bComp.Area, bComp.Volume);
                        double areaOrVolume = 0;
                        if (cost <= 0)
                            cost = opt.Cost;
                        if (co2 <= 0)
                            co2 = opt.CO2;
                        if (duration <= 0)
                            duration = opt.Duration;

                        //Determine if Using Area or Volume.  So far, only foundation assemblies use volume.
                        if (!bComp.Category.Equals("Foundation"))
                            areaOrVolume = bComp.Area;
                        else
                            areaOrVolume = bComp.Volume;
                        writer.WriteElementString("TotalAssemblyCost", (cost * areaOrVolume).ToString());
                        writer.WriteElementString("TotalAssemblyCO2", (co2 * areaOrVolume).ToString());
                        writer.WriteElementString("EstimatedDuration", duration.ToString());
                        //writer.WriteElementString("CostPerUnit", cost.ToString());
                        //writer.WriteElementString("CO2PerUnit", co2.ToString());
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            return true;
        }
        private void ComponentBuilderForm_Load(object sender, EventArgs e)
        {
            manager = new ElementManager(this.RevitDocument);

            List<Assembly> foundInModel = new List<Assembly>();

            foundInModel = manager.RetrieveWallInfo();
            foundInModel.AddRange(manager.RetrieveRoofingInfo());
            foundInModel.AddRange(manager.RetrieveFloorInfo());

            if (foundInModel.Count > 0)
                calculateAreas_Volumes(foundInModel);

            foreach (Assembly assem in Assemblies.Values)
            {
                if (!cboFoundInModel.Items.Contains(assem))
                    cboFoundInModel.Items.Add(assem);
            }
            //Components found in model.
            //cboFoundInModel.Items.AddRange(foundInModel.ToArray());
        }
        private void clearComponentInfo()
        {
            txtCompDesc.Clear();
            txtCompName.Clear();
            lbComponents.SelectedIndex = -1;
        }
        private void cboFoundInModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFoundInModel.SelectedIndex >= 0)
            {
                clearComponentInfo();
                lbAssemblies.Items.Clear();
                lbCurrentOptions.Items.Clear();
                lbCrewOptions.Items.Clear();
                lbCurrentCrew.Items.Clear();
                Assembly assem = (Assembly)cboFoundInModel.SelectedItem;
                txtCategory.Text = assem.Category;
                //txtArea.Text = assem.Area.ToString();
                //txtVolume.Text = assem.Volume.ToString();
                txtArea.Text = areas[assem.AssemblyCode].ToString();
                txtVolume.Text = volumes[assem.AssemblyCode].ToString();
            }
        }
        private void lbComponents_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lbComponents.SelectedIndex >= 0)
            {
                BuildingComponent bComp = (BuildingComponent)lbComponents.SelectedItem;
                txtSelectedComp.Text = lbComponents.Text;
                lbCurrentOptions.Items.Clear();
                lbAssemblies.Items.Clear();
                lbCrewOptions.Items.Clear();
                lbCurrentCrew.Items.Clear();
                txtArea.Clear();
                txtVolume.Clear();
                cboFoundInModel.SelectedIndex = -1;
                lbCurrentOptions.Items.AddRange(bComp.Assemblies.ToArray());
                lbAssemblies.Items.AddRange(manager.getAssembliesByCategory(bComp.Category, 30).ToArray());
            }
        }
        private void btnAddOption_Click(object sender, EventArgs e)
        {
            if (lbAssemblies.SelectedIndex >= 0)
            {
                if (lbCurrentOptions.Items.Contains(lbAssemblies.SelectedItem))
                    MessageBox.Show("Option already added.");
                else
                {
                    ((BuildingComponent)lbComponents.SelectedItem).Assemblies.Add((Assembly)lbAssemblies.SelectedItem);
                    lbCurrentOptions.Items.Add(lbAssemblies.SelectedItem);
                    lbAssemblies.ClearSelected();
                }
            }
            else
                MessageBox.Show("Please select option to add.");
        }
        private void btnDeleteOption_Click(object sender, EventArgs e)
        {
            if (lbCurrentOptions.SelectedIndex >= 0)
            {
                ((BuildingComponent)lbComponents.SelectedItem).Assemblies.Remove((Assembly)lbCurrentOptions.SelectedItem);
                lbCurrentOptions.Items.RemoveAt(lbCurrentOptions.SelectedIndex);
                lbCrewOptions.Items.Clear();
                lbCurrentCrew.Items.Clear();
            }
            else
                MessageBox.Show("Please select option to delete.");
        }
        private void lbAssemblies_MouseDoubleClick(object sender, MouseEventArgs args)
        {
            if(lbAssemblies.SelectedIndex >= 0)
            {
                Assembly assem = (Assembly)lbAssemblies.SelectedItem;
                AssemblyDetailsForm detFrm = new AssemblyDetailsForm();
                detFrm.CurrentAssembly = assem;
                detFrm.RevitDocument = this.RevitDocument;
                detFrm.Show();
            }
        }
        private void lbCurrentOptions_MouseDoubleClick(object sender, MouseEventArgs args)
        {
            if (lbCurrentOptions.SelectedIndex >= 0)
            {
                Assembly assem = (Assembly)lbCurrentOptions.SelectedItem;
                AssemblyDetailsForm detFrm = new AssemblyDetailsForm();
                detFrm.CurrentAssembly = assem;
                detFrm.RevitDocument = this.RevitDocument;
                detFrm.Show();
            }
        }
        private void btnAddCrewOption_Click(object sender, EventArgs e)
        {
            if (lbCurrentCrew.Items.Count <= 0 && lbCrewOptions.SelectedIndex >= 0)
            {
                lbCurrentCrew.Items.Add(lbCrewOptions.SelectedItem);
                ((Assembly)lbCurrentOptions.SelectedItem).CurrentCrew = (Crew)lbCrewOptions.SelectedItem;
            }
        }
        private void btnDeleteCrew_Click(object sender, EventArgs e)
        {
            if (lbCurrentCrew.SelectedIndex >= 0)
            {
               lbCurrentCrew.Items.RemoveAt(lbCurrentCrew.SelectedIndex);
               ((Assembly)lbCurrentOptions.SelectedItem).CurrentCrew = null;
            }
        }
        public void lbCrewOptions_MouseDoubleClick(object sender, MouseEventArgs args)
        {
            ListBox lbSelected = (ListBox)sender;
            if (lbCrewOptions.SelectedIndex >= 0)
            {
                CrewDetailsForm crewFrm = new CrewDetailsForm();
                crewFrm.CurrentCrew = (Crew)lbSelected.SelectedItem;
                crewFrm.Show(this);
            }
        }
        private void calculateAreas_Volumes(List<Assembly> assemblies)
        {
            areas.Clear();
            volumes.Clear();
            comps.Clear();
            this.Assemblies.Clear();
            for (int i = 0; i < assemblies.Count(); i++)
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
                    bComp.Category = assem.Category;
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
        private void lbCurrentOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbCurrentOptions.SelectedIndex >= 0)
            {
                lbCurrentCrew.Items.Clear();
                lbCrewOptions.Items.Clear();
                Assembly assem = (Assembly)lbCurrentOptions.SelectedItem;
                lbCrewOptions.Items.AddRange(manager.getCrewsByCategory(assem.Category, -1).ToArray());
                if (assem.CurrentCrew != null)
                    lbCurrentCrew.Items.Add(assem.CurrentCrew);
            }
        }

        private void btnOrderComponents_Click(object sender, EventArgs e)
        {
            using (PhysicalScheduleForm phyFrm = new PhysicalScheduleForm())
            {
                List<BuildingComponent> comps = new List<BuildingComponent>();
                for(int i =0; i < lbComponents.Items.Count; i++)
                {
                    comps.Add((BuildingComponent) lbComponents.Items[i]);
                }

                phyFrm.Components = comps;
                if (phyFrm.ShowDialog() == DialogResult.OK)
                    MessageBox.Show("Successfully saved Basic Schedule");
            }
        }

        private void btnCreateNewOption_Click(object sender, EventArgs e)
        {
            if (lbComponents.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a component to be associated with the new option.");
                return;
            }
            using (NewOptionForm optFrm = new NewOptionForm())
            {
                if(lbComponents.SelectedIndex >= 0)
                {
                    optFrm.AssemCategory = ((BuildingComponent)lbComponents.SelectedItem).Category;
                    optFrm.CompArea = ((BuildingComponent)lbComponents.SelectedItem).Area;
                    optFrm.CompVolume = ((BuildingComponent)lbComponents.SelectedItem).Volume;
                }
                optFrm.RevitDocument = this.RevitDocument;
                DialogResult res = optFrm.ShowDialog();
                if (res == DialogResult.OK)
                {
                    Assembly assem = optFrm.CreatedOption;
                    if (lbComponents.SelectedIndex >= 0)
                        assem.Category = ((BuildingComponent)lbComponents.SelectedItem).Category;

                    if (lbCurrentOptions.Items.Contains(assem))
                        MessageBox.Show("Option already added.");
                    else
                    {
                        ((BuildingComponent)lbComponents.SelectedItem).Assemblies.Add(assem);
                        lbCurrentOptions.Items.Add(assem);
                        lbAssemblies.Items.Add(assem);
                        lbAssemblies.ClearSelected();
                    }
                }
            }
        }

        private void btnNSGAII_Click(object sender, EventArgs e)
        {
            String compFile = "";
            String orderFile = "";
            using (OpenFileDialog openDlg = new OpenFileDialog())
            {
                openDlg.Title = "Select Component File";
                openDlg.Filter = "XML File|*.xml";
                openDlg.ShowDialog();

                if (!String.IsNullOrEmpty(openDlg.FileName))
                {
                    compFile = openDlg.FileName;
                }
            }

            using (OpenFileDialog openDlg = new OpenFileDialog())
            {
                openDlg.Title = "Select Precedence File";
                openDlg.Filter = "XML File|*.xml";
                openDlg.ShowDialog();

                if (!String.IsNullOrEmpty(openDlg.FileName))
                {
                    orderFile = openDlg.FileName;
                }
            }

            if (String.IsNullOrEmpty(compFile) || String.IsNullOrEmpty(orderFile))
                MessageBox.Show("Failed to load necessary files for NSGA-II", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                try
                {
                    Process p = new Process();
                    p.StartInfo.WorkingDirectory = NSGAII_DIR;
                    p.StartInfo.FileName = @"NSGAII.exe";
                    p.StartInfo.Arguments = "\"" + compFile + "\"  \"" + orderFile + "\"";
                    p.StartInfo.CreateNoWindow = true;
                    p.Start();
                    p.WaitForExit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void lbAssemblies_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbCrewOptions.Items.Clear();
            lbCurrentCrew.Items.Clear();
            lbCurrentOptions.ClearSelected();
        }
    }
}