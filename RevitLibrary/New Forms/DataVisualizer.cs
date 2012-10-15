using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using RevitLibrary.DataClasses;

namespace RevitLibrary.New_Forms
{
    public partial class DataVisualizer : Form
    {
        public enum Comparison
        {
            TIMEVCOST,
            TIMEVEI,
            COSTVEI            
        }
        private const int TIME_BUFFER_ZONE = 25;
        private const int COST_BUFFER_ZONE = 10000;
        private const int EI_BUFFER_ZONE = 10000;
        public List<ProjectResult> Projects { get; set; }
        public Comparison CompareType { get; set; }
        public DataVisualizer()
        {
            InitializeComponent();
        }

        private int calculateMaxCost()
        {
            int max = 0;
            foreach (ProjectResult res in this.Projects)
            {
                if (res.TotalCost > max)
                    max = (int)res.TotalCost;
            }

            return max + COST_BUFFER_ZONE;
        }
        private int calculateMaxEI()
        {
            int max = 0;
            foreach (ProjectResult res in this.Projects)
            {
                if (res.TotalEI > max)
                    max = (int)res.TotalEI;
            }

            return max + EI_BUFFER_ZONE;
        }
        private int calculateMaxDuration()
        {
            int max = 0;
            foreach (ProjectResult res in this.Projects)
            {
                if (res.TotalDuration > max)
                    max = (int)res.TotalDuration;
            }

            return max + TIME_BUFFER_ZONE;
        }
        private void DataVisualizer_Load(object sender, EventArgs e)
        {
            chtData.Series.Add("Projects");
            chtData.Series["Projects"].ChartType = SeriesChartType.Point;
            chtData.Series["Projects"].MarkerStyle = MarkerStyle.Diamond;
            chtData.Series["Projects"].MarkerColor = Color.Blue;
            chtData.Series["Projects"].MarkerSize = 5;
            chtData.Series["Projects"].YValuesPerPoint = 1;
            switch (this.CompareType)
            {
                case Comparison.TIMEVCOST:
                {
                    chtData.ChartAreas[0].AxisX.Maximum = calculateMaxDuration();
                    chtData.ChartAreas[0].AxisY.Maximum = calculateMaxCost();
                    chtData.ChartAreas[0].AxisX.Title = "Duration";
                    chtData.ChartAreas[0].AxisY.Title = "Cost";

                    Projects.Sort(new CostComparer());
                    foreach (ProjectResult proj in Projects)
                    {
                        chtData.Series["Projects"].Points.AddXY(proj.TotalDuration, proj.TotalCost);
                    }
                    break;
                }
                case Comparison.TIMEVEI:
                {
                    chtData.ChartAreas[0].AxisX.Maximum = calculateMaxDuration();
                    chtData.ChartAreas[0].AxisY.Maximum = calculateMaxEI();
                    chtData.ChartAreas[0].AxisX.Title = "Duration";
                    chtData.ChartAreas[0].AxisY.Title = "EI";

                    Projects.Sort(new EIComparer());
                    foreach (ProjectResult proj in Projects)
                    {
                        chtData.Series["Projects"].Points.AddXY(proj.TotalDuration, proj.TotalEI);
                    }
                    break;
                }
                case Comparison.COSTVEI:
                {
                    chtData.ChartAreas[0].AxisX.Maximum = calculateMaxCost();
                    chtData.ChartAreas[0].AxisY.Maximum = calculateMaxEI();
                    chtData.ChartAreas[0].AxisX.Title = "Cost";
                    chtData.ChartAreas[0].AxisY.Title = "EI";

                    Projects.Sort(new CostComparer());
                    foreach (ProjectResult proj in Projects)
                    {
                        chtData.Series["Projects"].Points.AddXY(proj.TotalCost, proj.TotalEI);
                    }
                    break;
                }
                default:
                    break;
            }
        }


        private class CostComparer : IComparer<ProjectResult>
        {
            public int Compare(ProjectResult x, ProjectResult y)
            {
                int result = 0;

                if (x == null && y == null)
                    result = 0;
                else if (x == null && y != null)
                    result = -42;
                else if (x != null && y == null)
                    result = 42;
                else if (x.TotalCost > y.TotalCost)
                    result = 42;
                else if (x.TotalCost < y.TotalCost)
                    result = -42;
                return result;
            }
        }
        private class DurationComparer : IComparer<ProjectResult>
        {
            public int Compare(ProjectResult x, ProjectResult y)
            {
                int result = 0;

                if (x == null && y == null)
                    result = 0;
                else if (x == null && y != null)
                    result = -42;
                else if (x != null && y == null)
                    result = 42;
                else if (x.TotalDuration > y.TotalDuration)
                    result = 42;
                else if (x.TotalDuration < y.TotalDuration)
                    result = -42;
                return result;
            }
        }
        private class EIComparer : IComparer<ProjectResult>
        {
            public int Compare(ProjectResult x, ProjectResult y)
            {
                int result = 0;

                if (x == null && y == null)
                    result = 0;
                else if (x == null && y != null)
                    result = -42;
                else if (x != null && y == null)
                    result = 42;
                else if (x.TotalEI > y.TotalEI)
                    result = 42;
                else if (x.TotalEI < y.TotalEI)
                    result = -42;
                return result;
            }
        }
    }
}
