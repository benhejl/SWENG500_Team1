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
                if (!Page.IsPostBack)
                    // Get Issues List.
                    GetIssuesList(null, null);

            }
            catch (Exception)
            {
                
                throw;
            }

        }


        /// <summary>
        /// 
        /// </summary>
        private void GetIssuesList(string filterBy, string filter)
        {
            // get the project list
            var projects = ProjectManagerBLL.ProjectBLL.GetProjectList();

            // clear table before populating.
            for (int k = 1; k < Table1.Rows.Count; k++)
            {
                Table1.Rows.RemoveAt(k);
            }

            for (int i = 0; i < projects.Count; i++)
            {
                //get the list of issues for the project
                var issues = projects[i].Issues;

                IEnumerable<Issue> issuesFiltered = issues;

                // apply filter if it exists
                if (!string.IsNullOrEmpty(filterBy))
                {
                    if (filterBy == "status")       // Filter by status.
                    {
                        var enumStatus = (Issue.IssueStatus)Enum.Parse(typeof(Issue.IssueStatus),filter);
                        issuesFiltered = issues.Where(Issue => Issue.CurrentStatus == enumStatus);
                    }
                    else if (filterBy == "owner")   // Filter by owner.
                        issuesFiltered = issues.Where(Issue => Issue.Assignee.UserId == Int32.Parse(filter));
                }

                // build the table rows dynamically.
                foreach (Issue issue in issuesFiltered)
                {

                    var trow = new HtmlTableRow();
                    Table1.Rows.Add(trow);

                    // IssueID
                    var tcell1 = new HtmlTableCell();
                    tcell1.InnerText = issue.IssueID.ToString();
                    trow.Cells.Add(tcell1);

                    // Project Name
                    var tcell2 = new HtmlTableCell();
                    tcell2.InnerText = projects[i].Name;
                    trow.Cells.Add(tcell2);

                    // issue subject
                    var tcell3 = new HtmlTableCell();
                    var link = new HtmlAnchor();
                    link.InnerText = issue.Subject;
                    link.HRef = "~/IssueDetails.aspx?IssueID=" + issue.IssueID.ToString();
                    tcell3.Controls.Add(link);
                    trow.Cells.Add(tcell3);

                    // issue Assignee
                    var tcell4 = new HtmlTableCell();
                    tcell4.InnerText = issue.Assignee.FirstName + " " + issue.Assignee.LastName;
                    trow.Cells.Add(tcell4);

                    // issue priority
                    var tcell5 = new HtmlTableCell();
                    tcell5.InnerText = issue.CurrentPriority.ToString();
                    trow.Cells.Add(tcell5);

                    // issue status
                    var tcell6 = new HtmlTableCell();
                    var enumStatus = (Issue.IssueStatus)Enum.Parse(typeof(Issue.IssueStatus), issue.CurrentStatus.ToString());
                    tcell6.InnerText = enumStatus.ToString();
                    trow.Cells.Add(tcell6);

                }

            }
        }

        /// <summary>
        /// ddlFilterBy_SelectedIndexChanged - Filter by Status or Owner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Get Issues List.
                GetIssuesList(null, null);

                // first clear ddlFiltered list.
                ddlFiltered.Items.Clear();
                

                if (ddlFilterBy.SelectedValue == "status")      // Filter by Status
                {
                    ddlFiltered.Items.Add("---Select Status---");
                    // populate dropdown list with IssueStatus enum values.
                    foreach (int value in Enum.GetValues(typeof(Issue.IssueStatus)))
                    {
                        ddlFiltered.Items.Add(new ListItem(Enum.GetName(typeof(Issue.IssueStatus), value), value.ToString()));
                    }
                }
                else if (ddlFilterBy.SelectedValue == "owner")  // Filter by Owner
                {
                    // populate Assignee drop down box.
                    var userList = UserBLL.GetUserListForView();

                    userList.Add(new KeyValuePair<string, int>("---Select Owner---", 0));

                    // sort list by value.
                    var sortedlist = from pair in userList
                                orderby pair.Value ascending
                                select pair;

                    ddlFiltered.DataSource = sortedlist;
                    ddlFiltered.DataTextField = "Key";
                    ddlFiltered.DataValueField = "Value";
                    ddlFiltered.DataBind();
                }
                else
                    // default setting - Select Filter is selected.
                    ddlFiltered.Items.Add("-------------");

            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// ddlFiltered_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlFiltered_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(ddlFiltered.SelectedValue))
                    // get the filter Issues List.
                    GetIssuesList(ddlFilterBy.SelectedValue, ddlFiltered.SelectedValue);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}