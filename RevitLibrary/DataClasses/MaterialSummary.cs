using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RevitLibrary.DataClasses
{
    public class MaterialSummary
    {
        public enum SummaryPhase { MANUFACTURING, CONSTRUCTION, MAINTENANCE, END_OF_LIFE, OPERATION };
        public enum SummaryType { FFC, WRU, GWP, AP, HHREP, EP, ODP, SP};
        public static String[] summaries= {"Fossil Fuel Consumption","Weighted Resource Use","Global Warming Potential",
                                   "Acidification Potential","HH Respiratory Effects Potential",
                                   "Eutrophication Potential","Ozone Depletion Potential", "Smog Potential"};
        private Dictionary<String, List<double>> summData;
        public MaterialSummary()
        {
            summData = new Dictionary<String, List<double>>();
            summData.Add(summaries[(int)SummaryType.FFC], new List<double>());
            summData.Add(summaries[(int)SummaryType.WRU], new List<double>());
            summData.Add(summaries[(int)SummaryType.GWP], new List<double>());
            summData.Add(summaries[(int)SummaryType.AP], new List<double>());
            summData.Add(summaries[(int)SummaryType.HHREP], new List<double>());
            summData.Add(summaries[(int)SummaryType.EP], new List<double>());
            summData.Add(summaries[(int)SummaryType.ODP], new List<double>());
            summData.Add(summaries[(int)SummaryType.SP], new List<double>());
        }

        public void SetSummaryValue(SummaryType type, SummaryPhase phase, double val)
        {
            int str = (int)type;
            int ph = (int)phase;
            String sum = summaries[str];
            List<double> phases = summData[sum];
            if (phases.Count <= ph)
                phases.Add(val);
            else
                phases[ph] = val;
        }
        public List<Double> GetSummaryByType(SummaryType type)
        {
            return summData[summaries[(int)type]];
        }
    }
}
