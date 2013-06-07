using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagerWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var projects = ProjectManagerBLL.ProjectBLL.GetProjectList();

            if (projects.Count > 0)
            {
                foreach (var project in projects)
                {
                    ProjectNames.Items.Add(project.ToString());
                }
                ProjectNames.SelectedIndex = 0;
                ErrorLabel.Visible = false;
            }
            else
            {
                ProjectNames.Visible = false;
                ProjectNameLabel.Visible = false;
            }
        }

        protected void ProjectNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            var projects = ProjectManagerBLL.ProjectBLL.GetProjectList();

            IssuesTable.Visible = false;
            if (projects.Count > 0)
            {
                foreach (var project in projects)
                {
                    if (project.ToString() == ProjectNames.SelectedItem.Text)
                    {
                        LoadProjectReport(project);
                        return;
                    }
                }
            }
        }

        private void LoadProjectReport(ProjectManagerLibrary.Models.Project project)
        {
            OpenIssues.Text = project.OpenIssues().ToString();
            ResolvedIssues.Text = project.ResolvedIssues().ToString();
            IssuesTable.Visible = true;
        }
    }
}