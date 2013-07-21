using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.DataVisualization.Charting;

namespace ProjectManagerLibrary.Models.Graphs
{
    class OpenVsResolvedGraph : GraphBase, ProjectData
    {
        static string OpenSeriesName = "Open";
        static string ResolvedSeriesName = "Resolved";

        public bool RequiresDateRange { get { return false; } }
        public DateRange CurrentDateRange { get; private set; }
        public int SortOrder { get { return 1; } }
        public string DataTitle { get { return "Open vs. Resolved Issues"; } }


        public OpenVsResolvedGraph()
        {
            CurrentDateRange = new DateRange(DateTime.Now, DateTime.Now);
        }


        public System.Web.UI.Control Display(Project project, DateRange range)
        {
            return BuildChart(project, range, DataTitle);
        }


        override protected ChartArea CreateChartArea()
        {
            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.IsMarginVisible = false;
            chartArea.AxisX.LabelStyle.Enabled = false;
            chartArea.BorderDashStyle = ChartDashStyle.NotSet;

            ConfigureAxis(chartArea.AxisX);
            ConfigureAxis(chartArea.AxisY);

            return chartArea;
        }


        override protected List<Series> EvaluateProject(Project project, DateRange range)
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
    }
}
