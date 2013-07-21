using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.DataVisualization.Charting;

namespace ProjectManagerLibrary.Models.Graphs
{
    public class OpenVsResolvedGraph : ProjectData
    {
        static string OpenSeriesName = "Open";
        static string ResolvedSeriesName = "Resolved";

        private ChartArea chartArea;
        private Legend legend;
        private Title title;

        public bool RequiresDateRange { get { return false; } }
        public DateRange CurrentDateRange { get; private set; }
        public int SortOrder { get { return 1; } }

        public OpenVsResolvedGraph()
        {
            CurrentDateRange = new DateRange(DateTime.Now, DateTime.Now);
        }

        /// <summary>
        /// Add and format the selected data to the current chart object.  
        /// </summary>
        /// <param name="chartData">A list of Series objects to plot.</param>
        private void DisplayChartData(Chart chart, List<Series> chartData)
        {
            chart.Series.Clear();
            foreach (Series series in chartData)
            {
                chart.Series.Add(series);
                series.BorderWidth = 2;
                series.BorderDashStyle = ChartDashStyle.Dot;
                series.MarkerStyle = MarkerStyle.Circle;
                series.MarkerSize = 6;
            }
        }


        /// <summary>
        /// Update the appearance of the target axis.
        /// </summary>
        /// <param name="axis">Axis to update the appearance of.</param>
        private void ConfigureAxis(Axis axis)
        {
            axis.LineColor = System.Drawing.Color.LightGray;
            axis.MajorTickMark.LineColor = axis.LineColor;
            axis.MinorTickMark.LineColor = axis.LineColor;
            axis.MajorGrid.Enabled = false;
            axis.MinorGrid.Enabled = false;
        }

        public System.Web.UI.Control Display(Project project, DateRange range)
        {
            Chart chart = new Chart();
            chart.ImageStorageMode = ImageStorageMode.UseImageLocation;

            chartArea = new ChartArea();
            chart.ChartAreas.Clear();
            chart.ChartAreas.Add(chartArea);
            chartArea.AxisX.IsMarginVisible = false;
            chartArea.AxisX.LabelStyle.Enabled = false;
            chartArea.BorderDashStyle = ChartDashStyle.NotSet;

            ConfigureAxis(chartArea.AxisX);
            ConfigureAxis(chartArea.AxisY);

            legend = new Legend();
            chart.Legends.Clear();
            chart.Legends.Add(legend);
            legend.LegendStyle = LegendStyle.Row;
            legend.Docking = Docking.Bottom;
            legend.Alignment = System.Drawing.StringAlignment.Center;

            title = new Title();
            chart.Titles.Clear();
            chart.Titles.Add(title);
            title.Docking = Docking.Top;
            title.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            title.Font = new System.Drawing.Font(legend.Font.FontFamily, 18);

            List<Series> data = EvaluateProject(project, range);
            foreach (Series series in data)
            {
                chart.Series.Add(series);
            }

            return chart;
        }


        public List<Series> EvaluateProject(Project project, DateRange range)
        {
            if ((null == project) || (null == range))
                throw new ArgumentNullException();

            DateTime current = DateTime.Now;
            DateTime first = current.Subtract(TimeSpan.FromDays(9));

            int open = 0;
            int resolved = 0;

            List<Series> data = new List<Series>(2);
            data.Add(new Series(OpenSeriesName));
            data.Add(new Series(ResolvedSeriesName));

            foreach (Issue issue in project.Issues)
            {
                if (issue.CurrentStatus == Issue.IssueStatus.Unresolved)
                {
                    open++;
                }
                else if (issue.CurrentStatus == Issue.IssueStatus.Resolved)
                {
                    resolved++;
                }
            }

            data[0].Points.AddY(open);
            data[0].ChartType = SeriesChartType.Column;

            data[1].Points.AddY(resolved);
            data[1].ChartType = SeriesChartType.Column;

            CurrentDateRange = range;

            return data;
        }

        public string DataTitle { get { return "Open vs. Resolved Defects"; } }
    }
}
