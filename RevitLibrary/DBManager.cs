using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB;
using System.Xml;
using System.Diagnostics;
using System.Configuration;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using RevitLibrary.DataClasses;
using System.Resources;
using System.Collections;

namespace RevitLibrary
{
    class DBManager
    {
        private const String connBase = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Persist Security Info=True";
        private String connectionString = "";
        private Document doc;
        private Dictionary<Assembly, double> assemblyVolumes;
        private Dictionary<Assembly, double> assemblyAreas;

        /// <summary>
        /// Controls Element Selection and Retrieval
        /// </summary>
        /// <param name="revDoc">Revit documet elements will retrieved from.</param>
        /// 

        public DBManager(Document revDoc)
        {
            doc = revDoc;
            String src = Properties.Settings.Default.dbSource;
            connectionString = String.Format(connBase, src);

        }
        public ICollection<Element> getElementsOfCategory(Document doc, BuiltInCategory cat, Type ty)
        {
            //Select all elements of type Wall.  Ignore walltypes for now.
            ElementCategoryFilter Categoryfilter = new ElementCategoryFilter(cat);
            ElementClassFilter classFilter = new ElementClassFilter(ty);
            LogicalAndFilter InstancesFilter = new LogicalAndFilter(Categoryfilter, classFilter);

            FilteredElementCollector collector = new FilteredElementCollector(doc);

            return collector.WherePasses(InstancesFilter).ToElements();
        }
        public List<Assembly> RetrieveWallInfo()
        {
            List<Assembly> assemblies = new List<Assembly>();
            ICollection<Element> walls = getElementsOfCategory(doc, BuiltInCategory.OST_Walls, typeof(Wall));

            foreach (Element e in walls)
            {
                Wall w = null;
                WallType wType = null;
                w = (Wall)e;
                Assembly assem = new Assembly();
                wType = w.WallType;
                if (wType.Kind == WallKind.Basic)
                {
                    Parameter assemName = wType.get_Parameter("Assembly Description");
                    assem.AssemblyName = assemName.AsString();
                    Parameter assemCode = wType.get_Parameter("Assembly Code");
                    assem.AssemblyCode = assemCode.AsString();
                    assem.Category = AssemblyUtil.GetCategoryFromCode(assem.AssemblyCode);
                    //get all materials associated with this assembly
                    List<AssemMaterial> mats = new List<AssemMaterial>();

                    foreach (Material m in w.Materials)
                    {
                        // MessageBox.Show(String.Format("{0} : {1}: Area = {2}", assemName.AsString(), m.Name, w.GetMaterialArea(m)));
                        AssemMaterial mat = new AssemMaterial();
                        mat.Name = m.Name;
                        mats.Add(mat);
                    }
                    assem.Materials = mats;

                    //get area and volume for each assembly
                    foreach (Parameter p in w.Parameters)
                    {
                        if (p.Definition.Name.Equals("Area"))
                        {
                            if (p.HasValue)
                            {
                                assem.Area = p.AsDouble();
                            }
                        }
                        else if (p.Definition.Name.Equals("Volume"))
                        {
                            if (p.HasValue)
                            {
                                assem.Volume = p.AsDouble();
                            }
                        }
                    }
                    //if(!assemblies.Contains(assem))
                    assemblies.Add(assem);
                }
            }
            return assemblies;
        }
        public List<Assembly> RetrieveRoofingInfo()
        {
            List<Assembly> assemblies = new List<Assembly>();
            ICollection<Element> roofing = getElementsOfCategory(doc, BuiltInCategory.OST_Roofs, typeof(RoofBase));

            foreach (Element e in roofing)
            {
                RoofBase roof = null;
                RoofType rType = null;
                roof = (RoofBase)e;
                Assembly assem = new Assembly();
                rType = roof.RoofType;

                Parameter assemName = rType.get_Parameter("Assembly Description");
                assem.AssemblyName = assemName.AsString();
                Parameter assemCode = rType.get_Parameter("Assembly Code");
                assem.AssemblyCode = assemCode.AsString();
                assem.Category = AssemblyUtil.GetCategoryFromCode(assem.AssemblyCode);
                //get all materials associated with this assembly
                List<AssemMaterial> mats = new List<AssemMaterial>();
                foreach (Material m in roof.Materials)
                {
                    AssemMaterial mat = new AssemMaterial();
                    mat.Name = m.Name;
                    mats.Add(mat);
                }
                assem.Materials = mats;

                //get area and volume for each assembly
                foreach (Parameter p in roof.Parameters)
                {
                    if (p.Definition.Name.Equals("Area"))
                    {
                        if (p.HasValue)
                        {
                            assem.Area = p.AsDouble();
                        }
                    }
                    else if (p.Definition.Name.Equals("Volume"))
                    {
                        if (p.HasValue)
                        {
                            assem.Volume = p.AsDouble();
                        }
                    }
                }
                //if(!assemblies.Contains(assem))
                assemblies.Add(assem);
            }
            return assemblies;
        }
        public List<Assembly> RetrieveFloorInfo()
        {
            List<Assembly> assemblies = new List<Assembly>();
            ICollection<Element> floors = getElementsOfCategory(doc, BuiltInCategory.OST_StructuralFoundation, typeof(Floor));

            foreach (Element e in floors)
            {
                Floor floor = null;
                FloorType fType = null;
                floor = (Floor)e;
                Assembly assem = new Assembly();
                fType = floor.FloorType;

                Parameter assemName = fType.get_Parameter("Assembly Description");

                assem.AssemblyName = floor.Name;
                //assem.AssemblyName = assemName.AsString();
                Parameter assemCode = fType.get_Parameter("Assembly Code");
                if (String.IsNullOrEmpty(assemCode.AsString()))
                    assem.AssemblyCode = "A1030";
                else
                    assem.AssemblyCode = assemCode.AsString();
                assem.Category = AssemblyUtil.GetCategoryFromCode(assem.AssemblyCode);
                //get all materials associated with this assembly
                List<AssemMaterial> mats = new List<AssemMaterial>();
                foreach (Material m in floor.Materials)
                {
                    AssemMaterial mat = new AssemMaterial();
                    mat.Name = m.Name;
                    mats.Add(mat);
                }
                assem.Materials = mats;

                //get area and volume for each assembly
                foreach (Parameter p in floor.Parameters)
                {
                    if (p.Definition.Name.Equals("Area"))
                    {
                        if (p.HasValue)
                        {
                            assem.Area = p.AsDouble();
                        }
                    }
                    else if (p.Definition.Name.Equals("Volume"))
                    {
                        if (p.HasValue)
                        {
                            assem.Volume = p.AsDouble();
                        }
                    }
                }
                //if(!assemblies.Contains(assem))
                assemblies.Add(assem);
            }
            return assemblies;
        }
        public void WriteOutWalls(String fName, List<Assembly> wallAssemblies)
        {
            using (XmlWriter writer = XmlWriter.Create(fName))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("WallData");
                foreach (Assembly assem in wallAssemblies)
                {
                    //available assembly data
                    writer.WriteStartElement("ExistingWall");
                    writer.WriteElementString("Name", assem.AssemblyName);
                    writer.WriteElementString("Code", assem.AssemblyCode);
                    writer.WriteElementString("Category", assem.Category);
                    writer.WriteElementString("Area", assem.Area.ToString());
                    writer.WriteElementString("Volume", assem.Volume.ToString());
                    writer.WriteElementString("CostPerUnit", assem.CalculateCostPerUnit().ToString());
                    writer.WriteElementString("CO2PerUnit", assem.CalculateCO2PerUnit().ToString());

                    //write out alternatives
                    List<Assembly> options = this.getAssembliesByCategory(assem.Category, -1);
                    foreach (Assembly opt in options)
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
        public void CalculateWallAssemblies(Type ty)
        {
            double totalVolume = 0.0;
            double totalArea = 0.0;

            //hold total volume for each assembly code
            assemblyVolumes = new Dictionary<Assembly, double>();
            assemblyAreas = new Dictionary<Assembly, double>();

            ICollection<Element> walls = getElementsOfCategory(doc, BuiltInCategory.OST_Walls, ty);
            foreach (Element e in walls)
            {
                Wall w = null;
                WallType wType = null;
                w = (Wall)e;
                Assembly assem = new Assembly();
                wType = w.WallType;
                if (wType.Kind == WallKind.Basic)
                {
                    //Write Assembly Name
                    Parameter assemName = wType.get_Parameter("Assembly Description");
                    assem.AssemblyName = assemName.AsString();

                    //Write Assembly Code
                    Parameter assemCode = wType.get_Parameter("Assembly Code");
                    assem.AssemblyCode = assemCode.AsString();
                    List<AssemMaterial> mats = new List<AssemMaterial>();
                    foreach (Material m in w.Materials)
                    {
                        AssemMaterial mat = new AssemMaterial();
                        mat.Name = m.Name;
                        mats.Add(mat);
                    }
                    assem.Materials = mats;
                    foreach (Parameter p in w.Parameters)
                    {
                        if (p.Definition.Name.Equals("Area"))
                        {
                            if (p.HasValue)
                            {

                                if (assemblyAreas.ContainsKey(assem))
                                {
                                    double area = assemblyAreas[assem];
                                    totalArea += area;
                                    assemblyAreas[assem] = area + p.AsDouble();
                                }
                                else
                                    assemblyAreas.Add(assem, p.AsDouble());
                            }
                        }
                        else if (p.Definition.Name.Equals("Volume"))
                        {
                            if (p.HasValue)
                            {
                                if (assemblyVolumes.ContainsKey(assem))
                                {
                                    double vol = assemblyVolumes[assem];
                                    totalVolume += vol;
                                    assemblyVolumes[assem] = vol + p.AsDouble();
                                }
                                else
                                    assemblyVolumes.Add(assem, p.AsDouble());
                            }
                        }
                    }
                }
            }
        }
        public void WriteAssemblyValue(XmlWriter writer, Dictionary<String, double> assemblyVals, String value)
        {
            writer.WriteStartElement("Assembly" + value + "s");
            writer.WriteStartElement("Assemblies");
            foreach (KeyValuePair<String, double> code in assemblyVals)
            {
                writer.WriteStartElement("Assembly");
                writer.WriteElementString("AssemblyCode", code.Key);
                writer.WriteElementString("Total" + value, code.Value.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
        private OleDbConnection getConnection()
        {
            return new OleDbConnection(connectionString);
        }
        public List<Assembly> getComponentAssemblies(BuildingComponent bComp)
        {
            List<Assembly> assemblies = new List<Assembly>();
            using (OleDbConnection conn = this.getConnection())
            {
                conn.Open();
                using (OleDbCommand comm = conn.CreateCommand())
                {
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = "SELECT AssemName, Description, AssemblyCode " +
                                       "FROM Assembly WHERE " +
                                       "id in (select AssemblyID from comp_assem where componentID = " +
                                       "(select id from BuildingComponent where ComponentName = ?));";
                    comm.Parameters.AddWithValue("@name", bComp.Name);

                    using (OleDbDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Assembly a = new Assembly();
                            //Basic assembly information
                            a.AssemblyName = reader["AssemName"].ToString();
                            a.Description = reader["Description"].ToString();
                            a.AssemblyCode = reader["AssemblyCode"].ToString();
                            assemblies.Add(a);
                        }
                    }
                    foreach (Assembly a in assemblies)
                    {
                        a.Materials = getMaterialsByAssemblyName(a.AssemblyName);
                    }
                }
                conn.Close();
            }
            return assemblies;
        }
        public int SaveProject(String projName)
        {
            int projID = -1;
            using (OleDbConnection conn = this.getConnection())
            {
                conn.Open();
                using (OleDbCommand comm = conn.CreateCommand())
                {
                    //if project exists, send back ID
                    comm.CommandText = "SELECT ID FROM Project WHERE ProjectName = ?;";
                    comm.Parameters.AddWithValue("@name", projName);
                    Object obj = comm.ExecuteScalar();

                    if (obj != null && !(obj is DBNull))
                    {
                        projID = (int)obj;
                    }
                    else
                    {
                        //No project found, insert it; send back ID
                        comm.CommandType = CommandType.Text;
                        comm.CommandText = "INSERT INTO Project (ProjectName) values (?);";
                        comm.Parameters.AddWithValue("@name", projName);

                        if (comm.ExecuteNonQuery() > 0)
                        {
                            comm.Parameters.Clear();
                            comm.CommandText = "SELECT ID FROM Project WHERE ProjectName = ?;";
                            comm.Parameters.AddWithValue("@name", projName);

                            obj = comm.ExecuteScalar();
                            if (obj != null && !(obj is DBNull))
                            {
                                projID = (int)obj;
                            }
                        }
                    }
                }
                conn.Close();
            }
            return projID;
        }
        public int getProjectID(String projName)
        {
            int projID = -1;
            using (OleDbConnection conn = this.getConnection())
            {
                conn.Open();
                using (OleDbCommand comm = conn.CreateCommand())
                {
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = "SELECT ID FROM Project WHERE ProjectName = ?";
                    comm.Parameters.AddWithValue("@name", projName);

                    object obj = comm.ExecuteScalar();

                    if (obj != null && !(obj is DBNull))
                        projID = (int)obj;
                }
                conn.Close();
            }
            return projID;
        }
        public List<Assembly> getAllAssemblies()
        {
            List<Assembly> assemblies = new List<Assembly>();
            using (OleDbConnection conn = this.getConnection())
            {
                conn.Open();
                using (OleDbCommand comm = conn.CreateCommand())
                {
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = "Select AssemName, Description, AssemblyCode from Assembly";

                    using (OleDbDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Assembly a = new Assembly();
                            //Basic assembly information
                            a.AssemblyName = reader["AssemName"].ToString();
                            a.Description = reader["Description"].ToString();
                            a.AssemblyCode = reader["AssemblyCode"].ToString();
                            a.Materials = getMaterialsByAssemblyName(a.AssemblyName);
                            assemblies.Add(a);
                        }
                    }
                }
                conn.Close();
            }
            return assemblies;
        }
        public List<Assembly> getComponentOptions(BuildingComponent bComp, int projID)
        {
            List<Assembly> assemblies = new List<Assembly>();
            using (OleDbConnection conn = this.getConnection())
            {
                conn.Open();
                using (OleDbCommand comm = conn.CreateCommand())
                {
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = "SELECT AssemName, Description, AssemblyCode, Category FROM Assembly WHERE ID IN (SELECT AssemblyID from Comp_Assem WHERE ComponentID = (Select ID FROM BuildingComponent WHERE ComponentName = ? and ProjectID = ?));";
                    comm.Parameters.AddWithValue("@name", bComp.Name);
                    comm.Parameters.AddWithValue("@projID", projID);
                    using (OleDbDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Assembly assem = new Assembly();
                            assem.AssemblyName = reader["AssemName"].ToString();
                            assem.Description = reader["Description"].ToString();
                            assem.AssemblyCode = reader["AssemblyCode"].ToString();
                            assem.Category = reader["Category"].ToString();
                            assemblies.Add(assem);
                        }
                    }
                    foreach (Assembly a in assemblies)
                    {
                        a.Materials = getMaterialsByAssemblyName(a.AssemblyName);
                    }
                }
                conn.Close();
            }
            return assemblies;
        }
        public List<Assembly> getAssembliesByCode(String code)
        {
            List<Assembly> assemblies = new List<Assembly>();
            using (OleDbConnection conn = this.getConnection())
            {
                conn.Open();
                using (OleDbCommand comm = conn.CreateCommand())
                {
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = "Select AssemName, Description from Assembly Where AssemblyCode=?";
                    comm.Parameters.AddWithValue("@code", code);


                    using (OleDbDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Assembly a = new Assembly();
                            //Basic assembly information
                            a.AssemblyName = reader["AssemName"].ToString();
                            a.Description = reader["Description"].ToString();
                            a.AssemblyCode = code;
                            a.Materials = getMaterialsByAssemblyName(a.AssemblyName);
                            assemblies.Add(a);
                        }
                    }
                }
                conn.Close();
            }
            return assemblies;
        }
        public List<Assembly> getAssembliesByCategory(String category)
        {
            return getAssembliesByCategory(category, -1);
        }
        public List<Assembly> getAssemblRangeByCategory(String category, int nRows, int group)
        {
            List<Assembly> assemblies = new List<Assembly>();
            using (OleDbConnection conn = this.getConnection())
            {
                conn.Open();
                using (OleDbCommand comm = conn.CreateCommand())
                {
                    int rowCount = -1;
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = "Select count(*) FROM Assembly WHERE Category=?";
                    comm.Parameters.AddWithValue("@cat", category);

                    Object obj = comm.ExecuteScalar();
                    if (!(obj is DBNull) && (obj != null))
                        rowCount = (int)obj;

                    int grab = rowCount - ((group - 1) * nRows);
                    if (grab <= 0)
                        return assemblies;
                    comm.Parameters.Clear();
                    comm.CommandText = "Select TOP " + nRows + " * From (Select TOP " + grab +
                        " * From (Select ID, AssemName, Description, AssemblyCode FROM Assembly " +
                        "WHERE Category=?) Order By ID DESC) Order By ID ASC";
                    comm.Parameters.AddWithValue("@cat", category);


                    using (OleDbDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Assembly a = new Assembly();
                            //Basic assembly information
                            a.AssemblyName = reader["AssemName"].ToString();
                            a.Description = reader["Description"].ToString();
                            a.AssemblyCode = reader["AssemblyCode"].ToString();
                            a.Category = category;
                            a.Materials = getMaterialsByAssemblyName(a.AssemblyName);
                            assemblies.Add(a);
                        }
                    }
                }
                conn.Close();
            }
            return assemblies;
        }
        public List<Assembly> getAssembliesByCategory(String category, int max)
        {
            List<Assembly> assemblies = new List<Assembly>();
            using (OleDbConnection conn = this.getConnection())
            {
                conn.Open();
                using (OleDbCommand comm = conn.CreateCommand())
                {
                    comm.CommandType = CommandType.Text;
                    if (max < 0)
                        comm.CommandText = "Select AssemName, Description, AssemblyCode FROM Assembly WHERE Category=?";
                    else
                        comm.CommandText = "Select TOP " + max + " AssemName, Description, AssemblyCode FROM Assembly WHERE Category=?";
                    comm.Parameters.AddWithValue("@cat", category);


                    using (OleDbDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Assembly a = new Assembly();
                            //Basic assembly information
                            a.AssemblyName = reader["AssemName"].ToString();
                            a.Description = reader["Description"].ToString();
                            a.AssemblyCode = reader["AssemblyCode"].ToString();
                            a.Category = category;
                            a.Materials = getMaterialsByAssemblyName(a.AssemblyName);
                            assemblies.Add(a);
                        }
                    }
                }
                conn.Close();
            }
            return assemblies;
        }
        public List<Crew> getCrewsByCategory(String category, int max)
        {
            List<Crew> crews = new List<Crew>();
            using (OleDbConnection conn = this.getConnection())
            {
                conn.Open();
                using (OleDbCommand comm = conn.CreateCommand())
                {
                    comm.Parameters.Clear();
                    comm.CommandType = CommandType.Text;
                    if (max < 0)
                        comm.CommandText = "Select CrewName, BareHourlyCost, BareDailyCost, Details FROM Crew";
                    else
                        comm.CommandText = "Select TOP " + max + " CrewName, BareHourlyCost, BareDailyCost, Details FROM Crew";

                    using (OleDbDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Crew c = new Crew();
                            //Basic Crew information
                            c.Name = reader["CrewName"].ToString();
                            c.BareHourlyCost = (double)reader["BareHourlyCost"];
                            c.BareDailyCost = (double)reader["BareDailyCost"];
                            c.Details = reader["Details"].ToString();
                            c.Category = category;
                            crews.Add(c);
                        }
                    }
                }
                conn.Close();
            }
            return crews;
        }
        public List<AssemMaterial> getMaterialsByAssemblyName(String assemName)
        {
            List<AssemMaterial> materials = new List<AssemMaterial>();
            using (OleDbConnection conn = this.getConnection())
            {
                conn.Open();
                using (OleDbCommand comm = conn.CreateCommand())
                {

                    comm.CommandType = CommandType.Text;
                    comm.CommandText = "SELECT MatName, Description, CostPerUnit, CO2PerUnit, Unit, LaborCost, LaborHours, DailyOutput " +
                                       "FROM Material INNER JOIN Labor ON (Material.ID = Labor.MaterialID)" +
                                       "WHERE Material.ID IN " +
                                       "(SELECT MaterialID FROM Assem_Mat WHERE AssemblyID = " +
                                       "(SELECT ID FROM Assembly WHERE AssemName =?)) ORDER BY MatName;";
                    comm.Parameters.AddWithValue("@name", assemName);
                    using (OleDbDataReader reader = comm.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            materials = new List<AssemMaterial>();
                            while (reader.Read())
                            {
                                AssemMaterial m = new AssemMaterial();
                                MaterialLabor labor = new MaterialLabor();
                                m.Name = reader["MatName"].ToString();
                                m.Description = reader["Description"].ToString();
                                m.CostPerUnit = (double)reader["CostPerUnit"];
                                m.CO2PerUnit = (double)reader["CO2PerUnit"];
                                m.Unit = reader["Unit"].ToString();
                                labor.Cost = (double)reader["LaborCost"];
                                labor.DailyOutPut = (double)reader["DailyOutput"];
                                labor.Hours = (double)reader["LaborHours"];
                                m.Labor = labor;
                                materials.Add(m);
                            }
                        }
                    }
                }
                conn.Close();
            }
            return materials;
        }
        public List<DesignOption> getExistingDesignOptions(String projectName)
        {
            List<DesignOption> results = new List<DesignOption>();
            using (OleDbConnection conn = this.getConnection())
            {
                conn.Open();
                using (OleDbCommand comm = conn.CreateCommand())
                {
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = "SELECT OptionName, Description FROM DesignOption " +
                                       "WHERE ProjectID = (Select ID from Project WHERE ProjectName = ?)";
                    comm.Parameters.AddWithValue("@name", projectName);

                    using (OleDbDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DesignOption opt = new DesignOption();
                            opt.Name = reader["OptionName"].ToString();
                            opt.Description = reader["Description"].ToString();
                            results.Add(opt);
                        }
                    }
                }
                conn.Close();
            }
            return results;
        }
        public List<BuildingComponent> getDesignOptionComponents(DesignOption dOpt)
        {
            List<BuildingComponent> results = new List<BuildingComponent>();
            using (OleDbConnection conn = this.getConnection())
            {
                conn.Open();
                using (OleDbCommand comm = conn.CreateCommand())
                {
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = "SELECT ComponentName, Description FROM BuildingComponent WHERE OptionID =" +
                                       " (SELECT id FROM DesignOption WHERE OptionName = ?);";
                    comm.Parameters.AddWithValue("@name", dOpt.Name);
                    using (OleDbDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BuildingComponent bComp = new BuildingComponent();
                            bComp.Name = reader["ComponentName"].ToString();
                            bComp.Description = reader["Description"].ToString();

                            results.Add(bComp);
                        }
                    }
                }
                conn.Close();
            }
            return results;
        }
        public double getAssemblyCost(Assembly assem)
        {
            double cost = -1.0;
            using (OleDbConnection conn = this.getConnection())
            {
                conn.Open();
                using (OleDbCommand comm = conn.CreateCommand())
                {
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = "SELECT SUM(costperunit) as AssemblyCost " +
                                       "FROM Material WHERE id in " +
                                       "(select materialID from assem_mat where assemblyid = " +
                                       "(select id from Assembly where AssemName = ?));";
                    comm.Parameters.AddWithValue("@name", assem.AssemblyName);
                    Object obj = comm.ExecuteScalar();

                    if (!(obj is DBNull) && (obj != null))
                        cost = (double)obj;
                }
                conn.Close();
            }
            return cost;
        }
        private int getDesignOptionID(DesignOption designOp, String projectName)
        {
            int id = -1;
            using (OleDbConnection conn = this.getConnection())
            {
                conn.Open();
                using (OleDbCommand comm = conn.CreateCommand())
                {
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = "SELECT ID FROM DesignOption WHERE OptionName = ? and " +
                                        "ProjectID = (SELECT ID FROM Project where Projectname = ?);";
                    comm.Parameters.AddWithValue("@optName", designOp.Name.Trim());
                    comm.Parameters.AddWithValue("@pName", projectName.Trim());

                    using (OleDbDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                            id = (int)reader["ID"];
                    }
                }
                conn.Close();
            }
            return id;
        }
        public void deleteOldComponentsFromProject(int projID)
        {
            using (OleDbConnection conn = this.getConnection())
            {
                conn.Open();
                using (OleDbCommand comm = conn.CreateCommand())
                {
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = "SELECT ID FROM BuildingComponent WHERE ProjectID = ?;";
                    comm.Parameters.AddWithValue("@projID", projID);
                    List<int> ids = new List<int>();
                    using (OleDbDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = (int)reader["ID"];
                            ids.Add(id);
                        }
                    }

                    //remove all related component-to-assembly references
                    foreach (int id in ids)
                    {
                        using (OleDbTransaction trans = conn.BeginTransaction())
                        {
                            comm.Transaction = trans;
                            comm.CommandText = "DELETE FROM Comp_Assem WHERE ComponentID = ?;";
                            comm.Parameters.AddWithValue("@compID", id);
                            int dels = comm.ExecuteNonQuery();
                            trans.Commit();
                        }
                        this.ClearCommandData(comm);
                    }
                    //remove old components
                    this.ClearCommandData(comm);
                    comm.CommandText = "DELETE FROM BuildingComponent WHERE ProjectID = ?;";
                    comm.Parameters.AddWithValue("@projID", projID);
                    int delComps = comm.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
        public Boolean saveComponentsToProject(int projID, List<BuildingComponent> components)
        {
            using (OleDbConnection conn = this.getConnection())
            {
                conn.Open();
                using (OleDbCommand comm = conn.CreateCommand())
                {
                    comm.CommandType = CommandType.Text;
                    foreach (BuildingComponent bComp in components)
                    {
                        this.ClearCommandData(comm);
                        comm.CommandText = "INSERT INTO BuildingComponent (ComponentName, Description, ProjectID, Category) values (?,?,?,?);";
                        comm.Parameters.AddWithValue("@name", bComp.Name);
                        if (bComp.Description == null)
                            bComp.Description = "";
                        comm.Parameters.AddWithValue("@desc", bComp.Description);
                        comm.Parameters.AddWithValue("@projID", projID);
                        comm.Parameters.AddWithValue("@cat", bComp.Category);

                        int saved = comm.ExecuteNonQuery();
                        if (saved < 1)
                            return false;

                        this.ClearCommandData(comm);
                        //gets newly created ID from previous statement
                        comm.CommandText = "SELECT @@IDENTITY";

                        int id = -1;
                        object obj = comm.ExecuteScalar();
                        if (obj != null && !(obj is DBNull))
                            id = (int)obj;

                        if (id > 0)
                        {
                            this.ClearCommandData(comm);

                            foreach (Assembly assem in bComp.Assemblies)
                            {

                                comm.Parameters.Clear();
                                comm.CommandText = "(Select ID FROM Assembly WHERE AssemName = ? and AssemblyCode = ?)";
                                comm.Parameters.AddWithValue("@assemName", assem.AssemblyName);
                                comm.Parameters.AddWithValue("@assemCode", assem.AssemblyCode);
                                obj = comm.ExecuteScalar();

                                int assemID = -1;
                                if (obj != null && !(obj is DBNull))
                                    assemID = (int)obj;

                                this.ClearCommandData(comm);
                                comm.CommandText = "INSERT INTO Comp_Assem (ComponentID, AssemblyID) " +
                                                   "values (?, ?);";
                                comm.Parameters.AddWithValue("@compid", id);
                                comm.Parameters.AddWithValue("@assemid", assemID);

                                saved = comm.ExecuteNonQuery();
                                if (saved < 1)
                                    return false;
                            }
                        }
                    }
                }
                conn.Close();
            }
            return true;
        }
        public Boolean saveDesignOption(DesignOption designOp, String projectName)
        {
            Boolean saved = false;
            using (OleDbConnection conn = this.getConnection())
            {
                int DesignOptID = -1;
                conn.Open();
                using (OleDbTransaction trans = conn.BeginTransaction())
                {
                    using (OleDbCommand comm = conn.CreateCommand())
                    {
                        DesignOptID = this.getDesignOptionID(designOp, projectName);

                        ClearCommandData(comm);
                        //No design option found.  Add a new one
                        if (DesignOptID < 0)
                        {
                            comm.CommandText = "INSERT INTO DesignOption (OptionName, Description, ProjectID)" +
                                               " values (?, ?, (Select ID FROM Project WHERE Project Name = ?));";
                            comm.Parameters.AddWithValue("@optName", designOp.Name);
                            comm.Parameters.AddWithValue("@desc", designOp.Description);
                            comm.Parameters.AddWithValue("@pName", projectName);

                            comm.ExecuteNonQuery();
                        }
                    }
                    //DesignOption inserted.
                    trans.Commit();
                }
                using (OleDbTransaction trans = conn.BeginTransaction())
                {
                    DesignOptID = this.getDesignOptionID(designOp, projectName);

                    using (OleDbCommand comm = conn.CreateCommand())
                    {
                        comm.CommandType = CommandType.Text;
                        for (int i = 0; i < designOp.Components.Count(); i++)
                        {
                            BuildingComponent bComp = designOp.Components[i];
                            ClearCommandData(comm);
                            if (bComp.ToDelete)
                            {
                                comm.CommandText = "DELETE FROM BuildingComponent WHERE ComponentName = ?";
                                comm.Parameters.AddWithValue("@name", bComp.Name);
                                comm.ExecuteNonQuery();
                            }
                            else
                            {
                                comm.CommandText = "UPDATE BuildingComponent SET Description = ? WHERE ID =" +
                                                   "(SELECT ID FROM BuildingComponent WHERE ComponentName = ?);";
                                int updated = comm.ExecuteNonQuery();

                                //component not found; add it.
                                if (updated == 0)
                                {
                                    ClearCommandData(comm);
                                    comm.CommandText = "INSERT INTO BuildingComponent (ComponentName, Description, OptionID) " +
                                                        "values (?, ?, ?);";
                                    comm.Parameters.AddWithValue("@name", bComp.Name);
                                    comm.Parameters.AddWithValue("@desc", bComp.Description);
                                    comm.Parameters.AddWithValue("@name", DesignOptID);

                                    comm.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    trans.Commit();
                    saved = true;
                }
                conn.Close();
            }
            return saved;
        }
        public Boolean saveAssembly(Assembly assem)
        {
            Boolean saved = false;
            using (OleDbConnection conn = this.getConnection())
            {
                int assemblyID = -1;
                conn.Open();

                //Save the Assembly information to the databaseS
                using (OleDbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        using (OleDbCommand comm = conn.CreateCommand())
                        {
                            comm.Transaction = trans;
                            comm.CommandType = CommandType.Text;

                            comm.CommandText = "SELECT ID FROM Assembly WHERE AssemName = ?";
                            comm.Parameters.AddWithValue("@name", assem.AssemblyName);

                            object obj = comm.ExecuteScalar();
                            if (obj != null && !(obj is DBNull))
                                assemblyID = (int)obj;

                            if (assemblyID < 0)
                            {
                                ClearCommandData(comm);
                                comm.CommandText = "INSERT INTO Assembly(AssemName, Description, AssemblyCode, Category) VALUES (?,?,?,?)";
                                comm.Parameters.AddWithValue("@name", assem.AssemblyName);
                                if (String.IsNullOrEmpty(assem.Description))
                                    comm.Parameters.AddWithValue("@desc", "");
                                else
                                    comm.Parameters.AddWithValue("@desc", assem.Description);
                                comm.Parameters.AddWithValue("@code", assem.AssemblyCode);
                                comm.Parameters.AddWithValue("@cat", assem.Category);

                                comm.ExecuteNonQuery();

                                comm.CommandText = "SELECT @@IDENTITY";
                                obj = comm.ExecuteScalar();
                                if (obj != null && !(obj is DBNull))
                                    assemblyID = (int)obj;
                            }
                        }
                        //DesignOption inserted.
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        saved = false;
                    }
                }

                int matID = -1;
                //Save any new Materials to the database.
                //Includes Labor data and Material Summary
                //Associate each material with the given assembly
                using (OleDbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (AssemMaterial mat in assem.Materials)
                        {
                            using (OleDbCommand comm = conn.CreateCommand())
                            {
                                comm.Transaction = trans;
                                comm.CommandType = CommandType.Text;
                                comm.CommandText = "SELECT ID FROM Material WHERE MatName = ? and Description = ?;";
                                comm.Parameters.AddWithValue("@name", mat.Name);
                                comm.Parameters.AddWithValue("@desc", mat.Description);

                                Object obj = comm.ExecuteScalar();

                                if (!(obj is DBNull) && (obj != null))
                                    matID = (int)obj;

                                if (matID < 0)
                                {
                                    ClearCommandData(comm);
                                    comm.CommandText = "INSERT INTO Material (MatName, Description, CostPerUnit, CO2PerUnit, Unit, "
                                                     + "R_Value) values (?,?,?,?,?,?)";
                                    comm.Parameters.AddWithValue("@name", mat.Name);
                                    comm.Parameters.AddWithValue("@desc", mat.Description);
                                    comm.Parameters.AddWithValue("@cost", mat.CostPerUnit);
                                    comm.Parameters.AddWithValue("@c02", mat.CO2PerUnit);
                                    comm.Parameters.AddWithValue("@unit", mat.Unit);
                                    comm.Parameters.AddWithValue("@rval", mat.RValue);

                                    comm.ExecuteNonQuery();

                                    ClearCommandData(comm);
                                    comm.CommandText = "SELECT @@IDENTITY";

                                    obj = comm.ExecuteScalar();

                                    if (!(obj is DBNull) && (obj != null))
                                        matID = (int)obj;


                                    //insert Labor Data
                                    ClearCommandData(comm);
                                    comm.CommandText = "Insert into Labor (LaborCost, LaborHours, MaterialID, DailyOutput) "
                                                        + "values (?, ?, ?, ?)";
                                    comm.Parameters.AddWithValue("@cost", mat.Labor.Cost);
                                    comm.Parameters.AddWithValue("@hours", mat.Labor.Hours);
                                    comm.Parameters.AddWithValue("@mat", matID);
                                    comm.Parameters.AddWithValue("@out", mat.Labor.DailyOutPut);
                                    comm.ExecuteNonQuery();

                                    //insert material summaries (usually 8)
                                    for (int i = 0; i < 8; i++)
                                    {
                                        List<double> phases = mat.Summary.GetSummaryByType((MaterialSummary.SummaryType)i);
                                        if (phases.Count != 5)
                                            continue;
                                        ClearCommandData(comm);
                                        int typeID = -1;
                                        comm.CommandText = "SELECT ID FROM SummaryType WHERE SummaryName=?";
                                        comm.Parameters.AddWithValue("@type", (MaterialSummary.summaries[i]));
                                        Object typeObj = null;
                                        typeObj = comm.ExecuteScalar();

                                        if (!(typeObj is DBNull) && (typeObj != null))
                                            typeID = (int)typeObj;
                                        if (typeID < 0)
                                            continue;

                                        ClearCommandData(comm);
                                        comm.CommandText = "Insert into MaterialSummary (MaterialID, SummaryTypeID, Manufacturing, "
                                                            + "Construction, Maintenance, EndofLife, Operation) "
                                                            + "values (?, ?, ?, ?, ?, ?, ?)";
                                        comm.Parameters.AddWithValue("@mat", matID);
                                        comm.Parameters.AddWithValue("@type", typeID);
                                        comm.Parameters.AddWithValue("@manu", phases[(int)MaterialSummary.SummaryPhase.MANUFACTURING]);
                                        comm.Parameters.AddWithValue("@const", phases[(int)MaterialSummary.SummaryPhase.CONSTRUCTION]);
                                        comm.Parameters.AddWithValue("@main", phases[(int)MaterialSummary.SummaryPhase.MAINTENANCE]);
                                        comm.Parameters.AddWithValue("@end", phases[(int)MaterialSummary.SummaryPhase.END_OF_LIFE]);
                                        comm.Parameters.AddWithValue("@oper", phases[(int)MaterialSummary.SummaryPhase.OPERATION]);
                                        comm.ExecuteNonQuery();
                                    }
                                }

                                ClearCommandData(comm);

                                comm.CommandText = "INSERT INTO Assem_Mat (MaterialID, AssemblyID) values (?,?);";
                                comm.Parameters.AddWithValue("@mat", matID);
                                comm.Parameters.AddWithValue("@assem", assemblyID);
                                comm.ExecuteNonQuery();
                            }
                        }
                        trans.Commit();
                        saved = true;
                    }
                    catch
                    {
                        trans.Rollback();
                        saved = false;
                    }
                }
                conn.Close();
            }

            return saved;
        }
        public List<String> getExistingCategories()
        {
            List<String> cats = null;
            using (OleDbConnection conn = getConnection())
            using (OleDbCommand comm = conn.CreateCommand())
            {
                conn.Open();
                comm.CommandType = CommandType.Text;
                comm.CommandText = "SELECT DISTINCT Category FROM Assembly;";

                using (OleDbDataReader reader = comm.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        cats = new List<string>();
                        while (reader.Read())
                        {
                            cats.Add(reader["Category"].ToString());
                        }
                    }
                }
                conn.Close();
            }
            return cats;
        }
        private void ClearCommandData(OleDbCommand command)
        {
            command.Parameters.Clear();
            command.CommandText = "";
        }
    }
}