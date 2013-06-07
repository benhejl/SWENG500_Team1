using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ProjectManagerBLL;
using ProjectManagerLibrary.Models;
using System.Web.UI.HtmlControls;

namespace ProjectManagerWeb
{
    public partial class Issues : System.Web.UI.Page
    {
        /// <summary>
        /// Page_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // get the project list
                var projects = ProjectManagerBLL.ProjectBLL.GetProjectList();

                for (int i = 0; i < projects.Count; i++)
                {

                    //get the list of issues for the project
                    var issues = projects[i].Issues;

                    for (int j = 0; j < issues.Count; j++)
                    {
                        var trow = new HtmlTableRow();
                        Table1.Rows.Add(trow);

                        // IssueID
                        var tcell1 = new HtmlTableCell();
                        tcell1.InnerText = issues[j].IssueID.ToString();
                        trow.Cells.Add(tcell1);
                        // Project Name
                        var tcell2 = new HtmlTableCell();
                        tcell2.InnerText = projects[i].Name;
                        trow.Cells.Add(tcell2);
                        // issue subject
                        var tcell3 = new HtmlTableCell();

                        var link = new HtmlAnchor();
                        link.InnerText = issues[j].Subject;
                        link.HRef = "~/IssueDetails.aspx?IssueID=" + issues[j].IssueID.ToString();
                        tcell3.Controls.Add(link);

                        trow.Cells.Add(tcell3);
                        // issue Assignee
                        var tcell4 = new HtmlTableCell();
                        tcell4.InnerText = issues[j].Assignee.FirstName + " " + issues[j].Assignee.LastName;
                        trow.Cells.Add(tcell4);
                        // issue priority
                        var tcell5 = new HtmlTableCell();
                        tcell5.InnerText = issues[j].CurrentPriority.ToString();
                        trow.Cells.Add(tcell5);

                    }

                }


            }
            catch (Exception)
            {
                
                throw;
            }

        }
    }
}