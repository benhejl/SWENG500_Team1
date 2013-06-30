using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace ProjectManagerLibrary.Models.Graphs
{
    class ProjectSummary : ProjectData
    {
        public System.Web.UI.Control Display(Project project, DateRange range)
        {
            Table table = new Table();
            if (project != null)
            {
                table.Rows.Add(CreateRow("Issue Type", "Count", true));
                table.Rows.Add(CreateRow("Open Issues", project.OpenIssues().ToString()));
                table.Rows.Add(CreateRow("Resolved Issues", project.ResolvedIssues().ToString()));
            }
            return table;
        }

        public string DataTitle { get { return "Summary"; } }
        public bool RequiresDateRange { get { return false; } }
        public DateRange CurrentDateRange { get { return null; } }

        private TableRow CreateRow(string description, string value, bool isHeader = false)
        {
            TableRow row = new TableRow();
            row.Cells.Add(CreateCell(description, true || isHeader));
            row.Cells.Add(CreateCell(value, isHeader));
            return row;
        }

        private TableCell CreateCell(string value, bool bold = false)
        {
            TableCell cell = new TableCell();
            cell.Text = value;
            cell.Font.Bold = bold;
            return cell;
        }
    }
}
