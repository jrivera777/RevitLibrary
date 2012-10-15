using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB;
using System.IO;
using System.Diagnostics;

namespace RevitLibrary
{
    public partial class Data : System.Windows.Forms.Form
    {
        public List<String> ElementTypes
        {
            get
            {
                List<String> elems = new List<String>();
                foreach (object obj in cboElementType.Items)
                {
                    elems.Add((string)obj);
                }
                return elems;
            }
            set
            {
                cboElementType.Items.Clear();
                cboElementType.Items.AddRange(value.ToArray());
            }
        }
        public Dictionary<Assembly, double> Areas { get; set; }
        public Dictionary<Assembly, double> Volumes { get; set; }
        public Autodesk.Revit.DB.Document RevitDocument { get; set; }
        public Data()
        {
            InitializeComponent();
        }
        private void SearchForm_Load(object sender, EventArgs e)
        {
        }
        private void btnFindElements_Click(object sender, EventArgs e)
        {
            lblDone.Visible = false;
            String choice = cboElementType.Text;

            ElementManager manager = new ElementManager(RevitDocument);
            switch (choice)
            {
                case "Floors":
                //    manager.WriteOutFloors();
                    break;
                case "Roofing":
                  //  manager.WriteOutRoofing();
                    break;
                case "Walls":
              //      manager.WriteOutWalls();
                    break;
                default:
                    break;
            }
        }
        private void cboElementType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDone.Visible = false;

            String choice = cboElementType.Text;
            ElementManager manager = new ElementManager(RevitDocument);
            switch (choice)
            {
                case "Floors":
                    break;
                case "Roofing":
                    break;
                case "Walls":
                    manager.CalculateWallAssemblies(typeof(Wall));
                    //this.Areas = manager.AssemblyAreas;
                    //this.Volumes = manager.AssemblyVolumes;
                    foreach (KeyValuePair<Assembly, double> pair in this.Areas)
                        cboAssemblies.Items.Add(pair.Key.AssemblyCode);
                    break;
                default:
                    break;
            }
        }
        private void cboAssemblies_SelectedIndexChanged(object sender, EventArgs e)
        {
            //double area = this.Areas[cboAssemblies.Text];
            //lblArea.Text = Math.Round(area, 2) + "SF";
            //double volume = this.Volumes[cboAssemblies.Text];
            //lblVolume.Text = Math.Round(volume, 2) + "CF";

            //ElementManager manager = new ElementManager(RevitDocument);
            //cboOptions.Items.AddRange(manager.getAssembliesByCode(cboAssemblies.Text).ToArray());
        }
        private void cboOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Assembly asm = (Assembly) cboOptions.SelectedItem;

            //lblTotalCost.Text = String.Format("{0:C}", asm.CostPerUnit * this.Volumes[cboAssemblies.Text]);
        }
    }
}