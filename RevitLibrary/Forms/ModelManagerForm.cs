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
using RevitLibrary.Forms;
using RevitLibrary.New_Forms;
using System.Xml;
using System.Diagnostics;
using RevitLibrary.DataClasses;

namespace RevitLibrary
{
    public partial class ModelManagerForm : System.Windows.Forms.Form
    {
        public Autodesk.Revit.DB.Document RevitDocument { get; set; }
        private ElementManager manager;
        private List<DesignOption> options;
        public ModelManagerForm()
        {
            InitializeComponent();
        }
        private void ModelManager_Load(object sender, EventArgs e)
        {
            lblFileName.Text = RevitDocument.Title;
            manager = new ElementManager(RevitDocument);
        }
        /// <summary>
        /// Create ComponentBuilderForm. Pass in the Revit Document object for use.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComponentBuilder_Click(object sender, EventArgs e)
        {
            using (ComponentBuilderForm compFrm = new ComponentBuilderForm())
            {
                compFrm.RevitDocument = RevitDocument;
                compFrm.ShowDialog();
            }
        }
        private void initiateAssemblyForm(String cat)
        {
            using (AssemblyManagerForm wManager = new AssemblyManagerForm())
            {
                wManager.RevitDocument = this.RevitDocument;
                wManager.GeneralCategory = cat;
                wManager.ShowDialog();
            }
        }
        private void btnViewResults_Click(object sender, EventArgs e)
        {
            List<ProjectResult> results = new List<ProjectResult>();
            String fName = "";
            using (OpenFileDialog openDlg = new OpenFileDialog())
            {
                openDlg.Title = "Open Project Results";
                openDlg.Filter = "XML File|*.xml";
                openDlg.ShowDialog();

                if (!String.IsNullOrEmpty(openDlg.FileName))
                {
                    fName = openDlg.FileName;
                    FileStream reader = new FileStream(openDlg.FileName, FileMode.Open, FileAccess.Read);
                    XmlDocument projects = new System.Xml.XmlDocument();
                    projects.Load(reader);
                    XmlNodeList nList = projects.GetElementsByTagName("Project");

                    foreach (XmlNode node in nList)
                    {
                        ProjectResult res = new ProjectResult();
                        XmlNodeList children = node.ChildNodes;
                        //id attribute has project name
                        res.ProjectName = node.Attributes["id"].InnerText;

                        //project level data
                        res.TotalCost = Double.Parse(children[0].InnerText);
                        res.TotalEI = Double.Parse(children[1].InnerText);
                        res.TotalDuration = Double.Parse(children[2].InnerText);

                        res.SelectedAssemblies = new List<Assembly>();
                        //get selected assemblies for each project
                        for (int i = 3; i < children.Count; i++)
                        {
                            XmlNode component = children[i];
                            XmlNodeList compData = component.ChildNodes;
                            Assembly assem = new Assembly();
                            assem.Category = component.Attributes["id"].Value;
                            assem.AssemblyName = compData[0].InnerText;
                            assem.Cost = Double.Parse(compData[1].InnerText);
                            assem.CO2 = Double.Parse(compData[2].InnerText);
                            assem.Duration = Double.Parse(compData[3].InnerText);
                            res.SelectedAssemblies.Add(assem);
                        }

                        if (!results.Contains(res))
                            results.Add(res);
                    }
                }
            }

            if (results.Count <= 0)
                return;

            using (ResultsForm resFrm = new ResultsForm())
            {
                resFrm.FileName = fName;
                resFrm.Results = results;
                resFrm.ShowDialog();
            }
        }
    }
}
