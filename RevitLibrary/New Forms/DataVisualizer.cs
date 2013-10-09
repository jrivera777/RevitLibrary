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
        private const int TIME_BUFFER_ZONE = 100;
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

            return FindBound(max, true);
        }
        private int calculateMaxEI()
        {
            int max = 0;
            foreach (ProjectResult res in this.Projects)
            {
                if (res.TotalEI > max)
                    max = (int)res.TotalEI;
            }

            return FindBound(max, true);
        }
        private int calculateMaxDuration()
        {
            int max = 0;
            foreach (ProjectResult res in this.Projects)
            {
                if (res.TotalDuration > max)
                    max = (int)res.TotalDuration;
            }

            return FindBound(max, true);
        }
        private int calculateMinCost()
        {
            int Min = int.MaxValue;
            foreach (ProjectResult res in this.Projects)
            {
                if (res.TotalCost < Min)
                    Min = (int)res.TotalCost;
            }

            return FindBound(Min, false);
        }
        private int calculateMinEI()
        {
            int Min = int.MaxValue;
            foreach (ProjectResult res in this.Projects)
            {
                if (res.TotalEI < Min)
                    Min = (int)res.TotalEI;
            }

            return FindBound(Min, false);
        }
        private int calculateMinDuration()
        {
            int Min = int.MaxValue;
            foreach (ProjectResult res in this.Projects)
            {
                if (res.TotalDuration < Min)
                    Min = (int)res.TotalDuration;
            }

            return (int)FindBound(Min, false);
        }
        private void DataVisualizer_Load(object sender, EventArgs e)
        {
            chtData.Series.Add("Projects");
            chtData.Series["Projects"].ChartType = SeriesChartType.Point;
            chtData.Series["Projects"].MarkerStyle = MarkerStyle.Diamond;
            chtData.Series["Projects"].MarkerSize = 7;
            chtData.Series["Projects"].YValuesPerPoint = 32;
            chtData.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
            switch (this.CompareType)
            {
                case Comparison.TIMEVCOST:
                {
                    chtData.Titles.Add("TVC");
                    chtData.Titles[0].Text = "Time vs Cost";
                    chtData.Titles[0].Font = new Font("Arial", 16);
                    chtData.Series["Projects"].MarkerColor = Color.Blue;
                    chtData.ChartAreas[0].AxisX.Maximum = calculateMaxDuration();
                    chtData.ChartAreas[0].AxisX.Minimum = calculateMinDuration();
                    chtData.ChartAreas[0].AxisY.Maximum = calculateMaxCost();
                    chtData.ChartAreas[0].AxisY.Minimum = calculateMinCost();
                    chtData.ChartAreas[0].AxisX.Title = "Time (days)";
                    chtData.ChartAreas[0].AxisY.Title = "Cost ($)";
                    //chtData.ChartAreas[0].AxisX.Interval = 10;
                    //chtData.ChartAreas[0].AxisY.Interval = 10000;
                    Projects.Sort(new CostComparer());
                    foreach (ProjectResult proj in Projects)
                    {
                        //chtData.Series["Projects"].Points.AddXY(proj.TotalDuration, proj.TotalCost);
                        DataPoint pt = new DataPoint(proj.TotalDuration, proj.TotalCost);
                        pt.ToolTip = String.Format("Time = {0}, Cost = {1}", proj.TotalDuration, proj.TotalCost);
                        chtData.Series["Projects"].Points.Add(pt);
                    }
                    break;
                }
                case Comparison.TIMEVEI:
                {
                    chtData.Titles.Add("TVE");
                    chtData.Titles[0].Text = "Time vs EI";
                    chtData.Titles[0].Font = new Font("Arial", 16);
                    chtData.Series["Projects"].MarkerColor = Color.Red;
                    chtData.ChartAreas[0].AxisX.Maximum = calculateMaxDuration();
                    chtData.ChartAreas[0].AxisX.Minimum = calculateMinDuration();
                    chtData.ChartAreas[0].AxisY.Maximum = RoundToNearest(calculateMaxEI() + 20000, 10000);
                    chtData.ChartAreas[0].AxisY.Minimum = calculateMinEI();
                    chtData.ChartAreas[0].AxisX.Title = "Time (days)";
                    chtData.ChartAreas[0].AxisY.Title = "EI (CO2)";
                    //chtData.ChartAreas[0].AxisX.Interval = 10;
                    //chtData.ChartAreas[0].AxisY.Interval = 10000;

                    Projects.Sort(new EIComparer());
                    foreach (ProjectResult proj in Projects)
                    {
                        //chtData.Series["Projects"].Points.AddXY(proj.TotalDuration, proj.TotalEI);
                        DataPoint pt = new DataPoint(proj.TotalDuration, proj.TotalEI);
                        pt.ToolTip = String.Format("Time = {0}, EI = {1}", proj.TotalDuration, proj.TotalEI);
                        chtData.Series["Projects"].Points.Add(pt);
                    }
                    break;
                }
                case Comparison.COSTVEI:
                {
                    chtData.Titles.Add("CVE");
                    chtData.Titles[0].Text = "Cost vs EI";
                    chtData.Titles[0].Font = new Font("Arial", 16);
                    chtData.Series["Projects"].MarkerColor = Color.Green;
                    chtData.ChartAreas[0].AxisX.Maximum = calculateMaxCost();
                    chtData.ChartAreas[0].AxisX.Minimum = calculateMinCost();
                    chtData.ChartAreas[0].AxisY.Maximum = RoundToNearest(calculateMaxEI() + 20000, 10000);
                    chtData.ChartAreas[0].AxisY.Minimum = calculateMinEI();
                    chtData.ChartAreas[0].AxisX.Title = "Cost ($)";
                    chtData.ChartAreas[0].AxisY.Title = "EI (CO2)";
                    //chtData.ChartAreas[0].AxisX.Interval = 10000;
                    //chtData.ChartAreas[0].AxisY.Interval = 10000;
                    Projects.Sort(new CostComparer());
                    foreach (ProjectResult proj in Projects)
                    {
                        //chtData.Series["Projects"].Points.AddXY(proj.TotalCost, proj.TotalEI);
                        DataPoint pt = new DataPoint(proj.TotalCost, proj.TotalEI);
                        pt.ToolTip = String.Format("Cost = {0}, EI = {1}", proj.TotalCost, proj.TotalEI);
                        chtData.Series["Projects"].Points.Add(pt);
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
        public double RoundToNearest(double Amount, double RoundTo)
        {
            double ExcessAmount = Amount % RoundTo;
            if (ExcessAmount < (RoundTo / 2))
            {
                Amount -= ExcessAmount;
            }
            else
            {
                Amount += (RoundTo - ExcessAmount);
            }

            return Amount;
        }
        public int FindBound(int val, Boolean upper)
        {
            int res = -1;
            int d = 1;
            int f = val;
            int p = (int)Math.Ceiling(Math.Log10(val));
            
            for (int i = 0; i < p - 1; i++)
                d *= 10;
            for(int i = 0; i < p -1; i++)
                f /= 10;

            res = f * d;
            if (upper)
                res += d;


            //int temp = val;
            //while (temp % 10 != 0)
            //{
            //    if (upper)
            //        temp++;
            //    else
            //        temp--;
            //}

            //return temp;
            return res;
        }
    }
}
