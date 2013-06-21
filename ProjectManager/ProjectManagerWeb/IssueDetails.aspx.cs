using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManagerBLL;
using ProjectManagerLibrary.Models;

namespace ProjectManagerWeb
{
    public partial class IssueDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // get issue info and display.
            GetIssueDetails();

        }

        /// <summary>
        /// GetIssueDetails
        /// </summary>
        private void GetIssueDetails()
        {
            try
            {
                if (!String.IsNullOrEmpty(Request.QueryString["IssueID"]))
                {
                    // get IssueID from query string.
                    var issueID = Int32.Parse(Request.QueryString["IssueID"]);

                    // get Issue details.
                    Issue issue = IssueBLL.GetIssue(issueID);

                    // get project info for this issue.
                    Project project = ProjectBLL.GetProject(issue.ProjectID);

                    // display values.
                    lblIssueID.Text = issue.IssueID.ToString();
                    lblProjectName.Text = project.Name;
                    lblSubject.Text = issue.Subject;
                    lblIssuePriority.Text = issue.CurrentPriority.ToString();
                    lblIssueStatus.Text = issue.CurrentStatus.ToString();
                    lblDescription.Text = issue.Description;
                    lblCategory.Text = issue.IssueCategoryName;
                    lblMilestone.Text = issue.Milestone.ToString();
                    lblAssignee.Text = issue.Assignee.FirstName + " " + issue.Assignee.LastName;
                    lblEntryDate.Text = issue.EntryDate.ToShortDateString();

                    // add Edit Issue Details link.
                    lnkEditDetails.NavigateUrl = "~/IssueDetailsEdit.aspx?IssueID=" + issueID.ToString();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}