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
    public partial class AddIssue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
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
                ddlAssignee.DataSource = userList; 
                ddlAssignee.DataTextField = "Key";
                ddlAssignee.DataValueField = "Value";
                // set "Unassigned" as default selection.
                if (!Page.IsPostBack) 
                    ddlAssignee.SelectedValue = "0";
                ddlAssignee.DataBind();

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
                if (!String.IsNullOrEmpty(txtSubject.Text) && !String.IsNullOrEmpty(txtDescription.Text))
                {
                    var issue = new Issue();
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

                    // add new issue.
                    success = IssueBLL.AddIssue(issue);

                    if (success) Response.Redirect("~/Issues.aspx");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}