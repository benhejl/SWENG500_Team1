using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace ProjectManagerLibrary.Models.Reports
{
    abstract class SummaryBase
    {
        public abstract TableRow[] SummaryForProject(Project project);

        protected TableRow CreateRow(string description, string value, bool isHeader = false)
        {
            TableRow row = new TableRow();
            row.Cells.Add(CreateCell(description, true || isHeader));
            row.Cells.Add(CreateCell(value, isHeader));
            return row;
        }

        protected TableCell CreateCell(string value, bool bold = false)
        {
            TableCell cell = new TableCell();
            cell.Text = value;
            cell.Font.Bold = bold;
            return cell;
        }

        protected TableRow HeaderRow(string description)
        {
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            cell.Text = description;
            cell.Font.Bold = true;
            cell.Font.Size = 14;
            row.Cells.Add(cell);
            return row;
        }
    }
}
