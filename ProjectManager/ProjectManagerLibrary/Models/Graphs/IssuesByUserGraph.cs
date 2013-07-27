using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.DataVisualization.Charting;

namespace ProjectManagerLibrary.Models.Graphs
{
    class IssuesByUserGraph : GraphBase, ProjectData
    {
        public bool RequiresDateRange { get { return false; } }
        public DateRange CurrentDateRange { get; private set; }
        public int SortOrder { get { return 1; } }
        public string DataTitle { get { return "Issues By User"; } }

        public IssuesByUserGraph()
        {
            CurrentDateRange = new DateRange(DateTime.MinValue, DateTime.MaxValue);
        }


        public System.Web.UI.Control Display(Project project, DateRange range)
        {
            return BuildChart(project, range, DataTitle);
        }


        override protected List<Series> EvaluateProject(Project project, DateRange range)
        {
            if ((null == project) || (null == range))
                throw new ArgumentNullException();

            Series data = new Series();

            List<string> users = new List<string>(project.Issues.Select(x => x.Assignee.UserName).Distinct());
            List<int> counts = new List<int>(users.Count);
            foreach (string user in users)
            {
                counts.Add(project.Issues.Count(x => x.Assignee.UserName == user));
            }

            data.Points.DataBindXY(users, counts);
            data.ChartType = SeriesChartType.Pie;
            data["PieLabelStyle"] = "Disabled";

            CurrentDateRange = range;

            return new List<Series>(new Series[] { data });
        }


        override protected ChartArea CreateChartArea()
        {
            ChartArea chartArea = new ChartArea();
            chartArea.Area3DStyle.Enable3D = true;
            return chartArea;
        }
    }
}
