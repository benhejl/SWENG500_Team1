using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace ProjectManagerLibrary.Models.Reports
{
    class IssueStatus : SummaryBase
    {
        public override TableRow[] SummaryForProject(Project project)
        {
            if (null == project)
                return new TableRow[0];

            List<TableRow> rows = new List<TableRow>(4);
            rows.Add(HeaderRow("Issues by Status"));
            rows.Add(CreateRow("Status", "Count", true));
            rows.Add(CreateRow("Open", project.OpenIssues().ToString()));
            rows.Add(CreateRow("Resolved", project.ResolvedIssues().ToString()));
            return rows.ToArray<TableRow>();
        }
    }  
}
