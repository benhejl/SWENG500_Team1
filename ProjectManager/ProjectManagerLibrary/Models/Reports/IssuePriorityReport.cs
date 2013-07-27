using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace ProjectManagerLibrary.Models.Reports
{
    class IssuePriorityReport : SummaryBase
    {
        public override TableRow[] SummaryForProject(Project project)
        {
            if (null == project)
                return new TableRow[0];

            List<TableRow> rows = new List<TableRow>(4);
            rows.Add(HeaderRow("Issues by Priority"));
            rows.Add(CreateRow("Priority", "Count", true));
            rows.Add(CreateRow("High", project.Issues.Count(x => x.CurrentPriority == Issue.IssuePriority.High).ToString()));
            rows.Add(CreateRow("Medium", project.Issues.Count(x => x.CurrentPriority == Issue.IssuePriority.Medium).ToString()));
            rows.Add(CreateRow("Low", project.Issues.Count(x => x.CurrentPriority == Issue.IssuePriority.Low).ToString()));
            return rows.ToArray<TableRow>();
        }
    }
}
