using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using ProjectManagerLibrary.Models;
using ProjectManagerLibrary.Models.Graphs;
using ProjectManagerBLL.Report;

namespace ProjectManagerWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        private Dictionary<string, ProjectData> reportTypes;
        Project selectedProject = null;

        public WebForm1()
        {
            List<Type> availableReports = ReportBLL.ReportTypes();
            reportTypes = new Dictionary<string, ProjectData>(availableReports.Count);
            foreach (Type report in availableReports)
            {
                ProjectData obj = (ProjectData)Activator.CreateInstance(report);
                reportTypes.Add(obj.DataTitle, obj);
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            var projects = ProjectManagerBLL.ProjectBLL.GetProjectList();

            ProjectNames.Items.Clear();
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

            ReportMenu.Items.Clear();
            foreach (string menu in reportTypes.Keys)
                ReportMenu.Items.Add(new MenuItem(menu));
        }


        protected void ProjectNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Project> projects = ProjectManagerBLL.ProjectBLL.GetProjectList();
            if (projects.Count > 0)
            {
                selectedProject = null;
                foreach (var project in projects)
                {
                    if (project.ToString() == ProjectNames.SelectedItem.Text)
                    {
                        selectedProject = project;
                    }
                }
            }
            ContentPanel.Visible = selectedProject != null;
        }

        protected void ReportMenuClick(object sender, MenuEventArgs e)
        {
            ProjectData data = reportTypes[e.Item.Text];
            ContentPanel.Controls.Clear();
            ContentPanel.Controls.Add(data.Display(selectedProject, new DateRange(DateTime.Now, DateTime.Now)));
            DateRange.Visible = data.RequiresDateRange;
        }
    }
}