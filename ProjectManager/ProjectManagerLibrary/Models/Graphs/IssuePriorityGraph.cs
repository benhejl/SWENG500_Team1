using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.DataVisualization.Charting;

namespace ProjectManagerLibrary.Models.Graphs
{
    class IssuePriorityGraph : ProjectData
    {
        static string HighSeriesName = "High";
        static string MediumSeriesName = "Medium";
        static string LowSeriesName = "Low";

        private ChartArea chartArea;
        private Legend legend;
        private Title title;

        public bool RequiresDateRange { get { return false; } }
        public DateRange CurrentDateRange { get; private set; }
        public int SortOrder { get { return 1; } }

        public IssuePriorityGraph()
        {
            CurrentDateRange = new DateRange(DateTime.Now, DateTime.Now);
        }


        public System.Web.UI.Control Display(Project project, DateRange range)
        {
            Chart chart = new Chart();
            chart.ImageStorageMode = ImageStorageMode.UseImageLocation;

            chartArea = new ChartArea();
            chartArea.Area3DStyle.Enable3D = true;
            chart.ChartAreas.Clear();
            chart.ChartAreas.Add(chartArea);

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

            int[] counts = new int[3];
            string[] titles = { HighSeriesName, MediumSeriesName, LowSeriesName };
            Series data = new Series();

            foreach (Issue issue in project.Issues)
            {
                counts[(int)issue.CurrentPriority]++;
            }

            data.Points.DataBindXY(titles, counts);
            data.ChartType = SeriesChartType.Pie;
            data["PieLabelStyle"] = "Disabled";

            CurrentDateRange = range;

            return new List<Series>(new Series[] {data});
        }

        public string DataTitle { get { return "Issues By Priority"; } }
    }
}
