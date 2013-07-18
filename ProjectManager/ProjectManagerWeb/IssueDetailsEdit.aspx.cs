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
    public partial class IssueDetailsEdit : System.Web.UI.Page
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    // populate project drop down box.
                    ddlProjects.DataSource = ProjectBLL.GetProjectListForView();
                    ddlProjects.DataTextField = "Key";
                    ddlProjects.DataValueField = "Value";
                    ddlProjects.DataBind();

                    // populate Assignee drop down box.
                    var userList = UserBLL.GetUserListForView();
                    // Add "Unassigned" to the list
                    userList.Add(new KeyValuePair<string, int>("-- Unassigned --", 0));

                    // sort list by value.
                    var sortedlist = from pair in userList
                                     orderby pair.Value ascending
                                     select pair;

                    ddlAssignee.DataSource = sortedlist;
                    ddlAssignee.DataTextField = "Key";
                    ddlAssignee.DataValueField = "Value";
                    ddlAssignee.DataBind();

                    // if IssueID is not null - populate issue information.
                    if (!String.IsNullOrEmpty(Request.QueryString["IssueID"]))
                    {
                        // get IssueID from query string.
                        var issueID = Int32.Parse(Request.QueryString["IssueID"]);

                        // get Issue details.
                        Issue issue = IssueBLL.GetIssue(issueID);

                        // get project info for this issue.
                        Project project = ProjectBLL.GetProject(issue.ProjectID);

                        // display values.
                        ddlProjects.SelectedValue = project.Name;
                        txtSubject.Text = issue.Subject;
                        ddlIssuePriority.SelectedValue = issue.CurrentPriority.ToString();
                        ddlIssueStatus.SelectedValue = issue.CurrentStatus.ToString();
                        txtDescription.Text = issue.Description;
                        txtCategory.Text = issue.IssueCategoryName;
                        txtMilestone.Text = issue.Milestone.ToString();
                        ddlAssignee.SelectedValue = issue.Assignee.UserId.ToString();
                        txtEntryDate.Text = issue.EntryDate.ToShortDateString();
                    }
                }

            }
            catch (Exception)
            {
                
                throw;
            }

        }


        /// <summary>
        /// btnSubmit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var success = false;
            try
            {
                if (!String.IsNullOrEmpty(Request.QueryString["IssueID"]) && !String.IsNullOrEmpty(txtSubject.Text) && !String.IsNullOrEmpty(txtDescription.Text))
                {
                    var issue = new Issue();
                    issue.IssueID = Int32.Parse(Request.QueryString["IssueID"]);
                    issue.Subject = txtSubject.Text;
                    issue.ProjectID = Int32.Parse(ddlProjects.SelectedValue);
                    issue.CurrentPriority = (Issue.IssuePriority)Enum.Parse(typeof(Issue.IssuePriority), ddlIssuePriority.SelectedValue);
                    issue.CurrentStatus = (Issue.IssueStatus)Enum.Parse(typeof(Issue.IssueStatus), ddlIssueStatus.SelectedValue);
                    issue.Description = txtDescription.Text;
                    issue.Milestone = 0; //TODO: check where this value comes from.
                    issue.EntryDate = DateTime.Parse(txtEntryDate.Text);
                    issue.IssueCategoryName = txtCategory.Text;

                    // assignee
                    var user = new User();
                    user.UserId = Int32.Parse(ddlAssignee.SelectedItem.Value);
                    issue.Assignee = user;

                    // update issue.
                    success = IssueBLL.EditIssue(issue);

                    if (success) Response.Redirect("~/IssueDetails.aspx?IssueID=" + Int32.Parse(Request.QueryString["IssueID"]));
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}