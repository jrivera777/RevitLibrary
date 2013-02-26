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

            //options = manager.getExistingDesignOptions(RevitDocument.Title);
            //foreach (DesignOption dOption in options)
            //{
            //    lbExistingDO.Items.Add(dOption);
            //}
        }
        private void btnWalls_Click(object sender, EventArgs e)
        {
            //initiateAssemblyForm("Wall");
            //initiateAssemblyForm("All");

            UIDocument uidoc = new UIDocument(RevitDocument);
            Autodesk.Revit.UI.Selection.SelElementSet collection = uidoc.Selection.Elements;
            
            // Display current number of selected elements
            TaskDialog.Show("Revit", "Number of selected elements: " + collection.Size.ToString());

            //Create a new SelElementSet
            SelElementSet newSelectedElementSet = SelElementSet.Create();


            Wall wall = null;
            // Add wall into the created element set.
            foreach (Autodesk.Revit.DB.Element elem in collection)
            {
                if (elem is Wall)
                {
                    StringBuilder sb = new StringBuilder();
                    
                    wall = (Wall)elem;
                    foreach (Parameter param in wall.Parameters)
                        sb.Append(param.Definition.Name+ "=> StorageType-"+ param.StorageType.ToString() + ": " + param.AsValueString() + System.Environment.NewLine);

                    MessageBox.Show(sb.ToString(), "Wall Instance Parameters");

                    WallType wType = wall.WallType;
                    sb.Clear();
                    sb.Append("WallType= " + wType.Name + System.Environment.NewLine);
                    foreach (Parameter param in wType.Parameters)
                        sb.Append(param.Definition.Name + "=> StorageType-" + param.StorageType.ToString() + ": " + param.AsValueString() + System.Environment.NewLine);

                    MessageBox.Show(sb.ToString(), "WallType Parameters");

                //    Transaction trans = new Transaction(RevitDocument);
                //    if (trans.Start("UpdateHeight") == TransactionStatus.Started)
                //    {
                //        Parameter wParam = wall.get_Parameter(BuiltInParameter.WALL_USER_HEIGHT_PARAM);
                //        wParam.Set(100.0);

                //        trans.Commit();
                //    }

                //    //if (trans.Start("ChangeWallLength") == TransactionStatus.Started)
                //    //{
                //    //    LocationCurve wallLocation = wall.Location as LocationCurve;
                //    //    MessageBox.Show(wallLocation.Curve.IsReadOnly.ToString());

                //    //    // get the points
                //    //    XYZ pt1 = wallLocation.Curve.get_EndPoint(0);
                //    //    XYZ pt2 = wallLocation.Curve.get_EndPoint(1);

                //    //    pt2 = pt2.Add(new XYZ(10, 0, 0));

                //    //    // create a new LineBound
                //    //    Line newWallLine = RevitDocument.Application.Create.NewLineBound(
                //    //      pt1, pt2);

                //    //    // update the wall curve
                //    //    wallLocation.Curve = newWallLine;

                //    //    trans.Commit();

                //    //    MessageBox.Show(wallLocation.Curve.ApproximateLength.ToString());
                //    //}

                //    if (trans.Start("ChangeWallType") == TransactionStatus.Started)
                //    {
                //        ElementId id = null;
                //        foreach (WallType type in RevitDocument.WallTypes)
                //        {
                //            if (type.Name.Equals("Generic - 8\" Masonry"))
                //            {
                //                id = type.Id;
                //            }
                //        }
                //        wall.WallType = (WallType)RevitDocument.get_Element(id);

                //        trans.Commit();
                //    }

                //    sb.Clear();
                //    foreach (Parameter param in wall.Parameters)
                //        sb.Append(param.Definition.Name + "=> StorageType-" + param.StorageType.ToString() + ": " + param.AsValueString() + System.Environment.NewLine);

                //    MessageBox.Show(sb.ToString(), "Wall Instance Parameters After Height Change");
                }
            }
        }
        private void btnCreateOption_Click(object sender, EventArgs e)
        {
            String name = txtDOName.Text;
            DesignOption d = new DesignOption();
            d.Name = name;

            if (String.IsNullOrEmpty(name))
                MessageBox.Show("Please enter a valid Design Option Name.");
            else
            {
                Boolean found = false;
                foreach (DesignOption dOpt in lbExistingDO.Items)
                {
                    if (dOpt.Name.Equals(d.Name))
                    {
                        MessageBox.Show("Design Option already exists.");
                        found = true;
                        break;
                    }
                }
                if(!found)
                    lbExistingDO.Items.Add(d);
            }
            
            txtDOName.Clear();
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (lbExistingDO.SelectedIndex < 0)
                MessageBox.Show("Please Select a Design Option to load.");
            else
            {
                BuildingComponentForm bFrm = new BuildingComponentForm();
                bFrm.RevitDocument = this.RevitDocument;
                bFrm.ProjectName = this.RevitDocument.Title;
                bFrm.CurrentDesignOption = (DesignOption)lbExistingDO.SelectedItem;
                bFrm.ShowDialog();
            }
        }
        private void btnRoofing_Click(object sender, EventArgs e)
        {
            //initiateAssemblyForm("Roofing");   
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

                        //get selected assemblies for each project
                        for (int i = 3; i < children.Count; i++)
                        {
                            XmlNode component = children[i];
                            XmlNodeList compData = node.ChildNodes;
                        }
                        
                        //add only unique projects
                        if (!results.Contains(res))
                            results.Add(res);
                    }
                }
            }
            
            if(results.Count <= 0)
            {
                //MessageBox.Show("Failed to read Results.");
                return;
            }

            using (ResultsForm resFrm = new ResultsForm())
            {
                resFrm.FileName = fName;
                resFrm.Results = results;
                resFrm.ShowDialog();
            }
        }

        private void btnFamily_Click(object sender, EventArgs e)
        {
            //define categories to search
            List<BuiltInCategory> cats = new List<BuiltInCategory>();
            cats.Add(BuiltInCategory.OST_Walls);
            cats.Add(BuiltInCategory.OST_Roofs);
            cats.Add(BuiltInCategory.OST_StructuralFoundation);

            CreateFamilyTree(RevitDocument);
        }

        public void CreateFamilyTree(Document myDoc)
        {
            IEnumerable<Element> familiesCollector = new FilteredElementCollector(myDoc)
                .OfClass(typeof(FamilyInstance))
                .WhereElementIsNotElementType()
                .Cast<FamilyInstance>()
                // (family, familyInstances):
                .GroupBy(fi => fi.Symbol.Family)
                .Select(f => f.Key);

            var mapCatToFam = new Dictionary<string, List<Element>>();

            var categoryList = new Dictionary<string, Category>();

            foreach (var f in familiesCollector)
            {
                Family fam = (Family)f;
                var catName = "";
                if (fam.FamilyCategory != null)
                    catName = fam.FamilyCategory.Name;
                if(!String.IsNullOrEmpty(catName))
                {
                    if (mapCatToFam.ContainsKey(catName))
                        mapCatToFam[catName].Add(f);
                    else
                    {
                        mapCatToFam.Add(catName,
                          new List<Element> { f });
                        categoryList.Add(catName,
                          f.Category);

                        StringBuilder sb = new StringBuilder();
                        foreach (FamilySymbol sym in fam.Symbols)
                            sb.Append(sym.Name + System.Environment.NewLine);
                        MessageBox.Show(sb.ToString());
                    }
                }
            }

            foreach (KeyValuePair<String, Category> item in categoryList)
            {
                MessageBox.Show(item.Key);
            }
        }
    }
}
