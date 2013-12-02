using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RevitLibrary.DataClasses;

namespace RevitLibrary
{
    public class Assembly : ICloneable
    {
        public String AssemblyName { get; set; }
        public double Duration { get; set; }
        public double Cost { get; set; }
        public double CO2 { get; set; }
        public String AssemblyCode { get; set; }
        public String Description { get; set; }
        public String Category { get; set; }
        public Boolean ToDelete { get; set; }
        public double Area { get; set; }
        public double Volume { get; set; }
        public Crew CurrentCrew { get; set; }
        public List<AssemMaterial> Materials { get; set; }
        public Assembly()
        {
            this.Materials = new List<AssemMaterial>();
        }
        public Assembly(double area, double volume)
        {
            this.Area = area;
            this.Volume = volume;
        }
        /// <summary>
        /// Total cost per unit for the Assembly. May be in S.F. or in C.F.
        /// </summary>
        /// <returns>Sum of material costs for Assembly. -1 if no materials exist</returns>
        public double CalculateCostPerUnit()
        {
            if (this.Materials == null || this.Materials.Count <= 0)
                return -1.0;
            double cost = 0.0;
            foreach (AssemMaterial m in this.Materials)
            {
                //cost of each material per unit = material cost + labor cost 
                switch (m.Unit.ToLower())
                {
                    case "s.f.": //standard measure square feet
                        cost += (m.CostPerUnit +m.Labor.Cost);
                        break;
                    case "c.f.": //cubic yard (mainly for foundations)
                        cost += (m.CostPerUnit + m.Labor.Cost); //standard measure cubic feet
                        break;
                    case "c.y.": //cubic yard (mainly for foundations)
                        cost += (m.CostPerUnit +m.Labor.Cost) / 27; // 1$/c.y. ==> 1$/27 c.f.
                        break;
                    case "sq":   //square ==> 100 s.f.
                        cost += (m.CostPerUnit +m.Labor.Cost) / 100; // 1$/sq ==> 1$/100 c.f.
                        break;
                    default:
                        //assume S.F. measurement for empty string and any other invalid unit
                        cost += cost += (m.CostPerUnit + m.Labor.Cost);
                        break;
                        //throw new Exception(String.Format("Cannot Parse unit of material: {0} for {1} - {2}", m.Unit.ToLower(), m.Name, m.Description));
                }
            }
            return cost;
        }
        /// <summary>
        /// Total CO2 per unit for the Assembly.
        /// </summary>
        /// <returns>Sum of material CO2 emissions for Assembly. -1 if no materials exist</returns>
        public double CalculateCO2PerUnit()
        {
            if (this.Materials == null || this.Materials.Count <= 0)
                return -1.0;
            double co2 = 0.0;
            foreach (AssemMaterial m in this.Materials)
            {
                switch (m.Unit.ToLower())
                {
                    case "s.f.": //standard measure square feet
                        co2 += m.CO2PerUnit;
                        break;
                    case "c.f.": //cubic feet
                        co2 += m.CostPerUnit;//standard measure cubic feet
                        break;
                    case "c.y.": //cubic yard (mainly for foundations)
                        co2 += m.CO2PerUnit / 27; // 1$/c.y. ==> 1$/27 c.f.
                        break;
                    case "sq":   //square ==> 100 s.f.
                        co2 += m.CO2PerUnit / 100; // 1$/sq ==> 1$/100 c.f.
                        break;
                    default:
                        //assume S.F. measurement for empty string and any other invalid unit
                        co2 += m.CO2PerUnit;
                        break;
                        //throw new Exception(String.Format("Cannot Parse unit of material: {0} for {1} - {2}", m.Unit.ToLower(), m.Name, m.Description));
                }
            }
            return co2;
        }
        public double CalculateRoughDuration(double area, double volume)
        {
            if (this.Materials == null || this.Materials.Count <= 0)
                return -1.0;
            double duration = 0;

            foreach (AssemMaterial m in this.Materials)
            {
                if (m.Labor.DailyOutPut > 0)
                {
                    switch (m.Unit.ToLower())
                    {
                        case "s.f.": //standard measure square feet
                            duration += Math.Ceiling(area / m.Labor.DailyOutPut);
                            break;
                        case "c.y.": //cubic yard (mainly for foundations)
                            duration += Math.Ceiling((volume / 27) / m.Labor.DailyOutPut);
                            break;
                        case "c.f.": //cubic feet
                            duration += Math.Ceiling(volume/ m.Labor.DailyOutPut);
                            break;
                        case "sq":   //square ==> 100 s.f.
                            duration += Math.Ceiling((area / 100) / m.Labor.DailyOutPut);
                            break;
                        default:
                            //break;
                            throw new Exception(String.Format("Cannot Parse unit of material: {0} for {1} - {2}", m.Unit.ToLower(), m.Name, m.Description));
                    }
                }
            }

            return duration;
        }
        public override String ToString()
        {
            return this.AssemblyName;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (this.GetType() != obj.GetType())
                return false;

            return this.Equals((Assembly)obj);
        }
        private Boolean Equals(Assembly that)
        {
            if (that == null)
                return false;

            return this.AssemblyName.Equals(that.AssemblyName) && this.AssemblyCode.Equals(that.AssemblyCode);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
