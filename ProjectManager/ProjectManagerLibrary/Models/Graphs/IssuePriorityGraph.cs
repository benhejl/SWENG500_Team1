using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.DataVisualization.Charting;

namespace ProjectManagerLibrary.Models.Graphs
{
    class IssuePriorityGraph : GraphBase, ProjectData
    {
        static string HighSeriesName = "High";
        static string MediumSeriesName = "Medium";
        static string LowSeriesName = "Low";

        public bool RequiresDateRange { get { return false; } }
        public DateRange CurrentDateRange { get; private set; }
        public int SortOrder { get { return 1; } }
        public string DataTitle { get { return "Issues By Priority"; } }

        public IssuePriorityGraph()
        {
            CurrentDateRange = new DateRange(DateTime.Now, DateTime.Now);
        }


        public System.Web.UI.Control Display(Project project, DateRange range)
        {
            return BuildChart(project, range);
        }


        override protected List<Series> EvaluateProject(Project project, DateRange range)
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


        override protected ChartArea CreateChartArea()
        {
            ChartArea chartArea = new ChartArea();
            chartArea.Area3DStyle.Enable3D = true;
            return chartArea;
        }
    }
}
