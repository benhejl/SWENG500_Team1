using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using ProjectManagerLibrary.Models.Graphs;

namespace ProjectManagerLibrary.Models.Reports
{
    class ProjectSummary : ProjectData
    {
        public System.Web.UI.Control Display(Project project, DateRange range)
        {
            Table table = new Table();
            if (project != null)
            {
                string[] SummaryNames = new string[] { "IssuesByUser", "IssueStatus", "IssuePriorityReport" };
                foreach (string name in SummaryNames)
                {
                    SummaryBase summary = Activator.CreateInstance("ProjectManagerLibrary", "ProjectManagerLibrary.Models.Reports." + name).Unwrap() as SummaryBase;
                    table.Rows.AddRange(summary.SummaryForProject(project));
                }
            }
            return table;
        }

        public string DataTitle { get { return "Summary"; } }
        public bool RequiresDateRange { get { return false; } }
        public DateRange CurrentDateRange { get { return new DateRange(DateTime.Now, DateTime.Now); } }
        public int SortOrder { get { return 0; } }
    }
}
