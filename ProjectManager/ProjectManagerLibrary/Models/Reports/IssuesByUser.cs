using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace ProjectManagerLibrary.Models.Reports
{
    class IssuesByUser : SummaryBase
    {
        public override TableRow[] SummaryForProject(Project project)
        {
            List<TableRow> rows = new List<TableRow>(4);
            rows.Add(HeaderRow("Issue Status"));
            rows.Add(CreateRow("Status", "Count", true));
            rows.Add(CreateRow("Open", project.OpenIssues().ToString()));
            rows.Add(CreateRow("Resolved", project.ResolvedIssues().ToString()));
            return rows.ToArray<TableRow>();
        }
    }
}
