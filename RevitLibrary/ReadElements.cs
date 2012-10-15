using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB;

namespace RevitLibrary
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class ReadElements : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {
            Application app = commandData.Application.Application;
            Document document = commandData.Application.ActiveUIDocument.Document;
            
            OpenModelDialog(document);
            //ReadWallMaterials(document);
            return Result.Succeeded;
        }

       /** public void GetMaterial(Document document, FamilyInstance window)
        {
            Materials materials = document.Settings.Materials;
            FamilySymbol windowSymbol = window.Symbol;
            Category category = windowSymbol.Category;
            Autodesk.Revit.DB.Material frameExteriorMaterial = null;
            Autodesk.Revit.DB.Material frameInteriorMaterial = null;
            Autodesk.Revit.DB.Material sashMaterial = null;

            // Check the paramters first
            foreach (Parameter parameter in windowSymbol.Parameters)
            {
                switch (parameter.Definition.Name)
                {
                    case "Frame Exterior Material":
                        frameExteriorMaterial = materials.get_Item(parameter.AsElementId());
                        break;
                    case "Frame Interior Material":
                        frameInteriorMaterial = materials.get_Item(parameter.AsElementId());
                        break;
                    case "Sash":
                        sashMaterial = materials.get_Item(parameter.AsElementId());
                        break;
                    default:
                        break;
                }
            }
            // Try category if the material is set by category
            if (null == frameExteriorMaterial)
                frameExteriorMaterial = category.Material;


            if (null == frameInteriorMaterial)
                frameInteriorMaterial = category.Material;
            if (null == sashMaterial)
                sashMaterial = category.Material;
            // Show the result because the category may have a null Material,
            // the Material objects need to be checked.
            string materialsInfo = "Frame Exterior Material: " + (null != frameExteriorMaterial ? frameExteriorMaterial.Name : "null") + "\n";
            materialsInfo += "Frame Interior Material: " + (null != frameInteriorMaterial ? frameInteriorMaterial.Name : "null") + "\n";
            materialsInfo += "Sash: " + (null != sashMaterial ? sashMaterial.Name : "null") + "\n";
            TaskDialog.Show("Revit", materialsInfo);
        }*/
        
        public void ReadWallMaterials(Document doc)
        {
            ElementCategoryFilter wallsCategoryfilter = new ElementCategoryFilter(BuiltInCategory.OST_Walls);
            ElementClassFilter classFilter = new ElementClassFilter(typeof(Wall));

            LogicalAndFilter wallInstancesFilter = new LogicalAndFilter(wallsCategoryfilter, classFilter);

            FilteredElementCollector collector = new FilteredElementCollector(doc);
            ICollection<Element> walls = collector.WherePasses(wallInstancesFilter).ToElements();
            
            TextWriter writer = new StreamWriter("C:\\Documents and Settings\\fdot\\Desktop\\materials.txt");
            foreach (Element e in walls)
            {
                Wall w = null;
                WallType wType = null;
                w = (Wall)e;
                writer.WriteLine("Wall - " + w.Name);
                wType = w.WallType;

                if (wType.Kind == WallKind.Basic)
                {
                        //Write Assembly Name
                        writer.Write("Assembly Description: ");
                        Parameter assemName = wType.get_Parameter("Assembly Description");
                        writeValueByStorageType(assemName, writer, doc);
                        writer.WriteLine();

                        //Write Assembly Code
                        writer.Write("Assembly Code: ");
                        Parameter assemCode = wType.get_Parameter("Assembly Code");
                        writeValueByStorageType(assemCode, writer, doc);
                        writer.WriteLine();

                        foreach (Material m in w.Materials)
                        {
                            writer.WriteLine("Material: " + m.Name + " - Area:" + w.GetMaterialArea(m));
                        }
                        //foreach (Parameter p in w.Parameters)
                        //{
                        //    if (p.Definition.Name.Equals("Area") || p.Definition.Name.Equals("Volume"))
                        //    {
                        //        writer.Write("\t" + p.Definition.Name + ": ");
                        //        if (p.HasValue)
                        //        {
                        //            writeValueByStorageType(p, writer, doc);
                        //        }
                        //        else
                        //            writer.Write("N/A");
                        //        writer.WriteLine();
                        //    }
                        //}
                    }
                //}

                writer.WriteLine();
            }
            writer.Dispose();
        }
        private void writeValueByStorageType(Parameter p, TextWriter writer, Document doc)
        {
            if (null != p)
            {
                switch (p.StorageType)
                {
                    case StorageType.Double:
                        {
                            writer.Write(p.AsDouble());
                            break;
                        }
                    case StorageType.Integer:
                        {
                            writer.Write(p.AsInteger());
                            break;
                        }
                    case StorageType.String:
                        {
                            writer.Write(p.AsString());
                            break;
                        }
                    case StorageType.ElementId:
                        {
                            Element elem = doc.get_Element(p.AsElementId());
                            if (null == elem)
                                writer.Write("NULL ELEMENT FOUND");
                            else
                                writer.Write(elem.Name);
                            break;
                        }
                    default:
                        writer.Write("N/A");
                        break;
                }
            }
        }
        /**void SearchApp(Document doc)
        {
            Data srch = new Data();
            List<String> list = new List<String>();
            foreach (BuiltInCategory bic in Enum.GetValues(typeof(BuiltInCategory)))
            {
                list.Add(bic.ToString());
            }
            srch.ElementTypes = list;
            srch.RevitDocument = doc;
            srch.ShowDialog();
        }*/
        public void OpenModelDialog(Document doc)
        {
            //Data srch = new Data();
            ModelManagerForm srch = new ModelManagerForm();
            List<String> list = new List<String>();

            list.Add("Floors");
            list.Add("Roofing");
            list.Add("Walls");

           // srch.ElementTypes = list;
            srch.RevitDocument = doc;

            srch.Show();
        }
    }
}
