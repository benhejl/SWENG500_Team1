using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using ProjectManagerLibrary.Models;
using ProjectManagerLibrary.Models.Graphs;

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
                ProjectChart.Visible = false;
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

                        ProjectData data = new OpenVsResolvedStrategy();
                        DisplayChart(data.EvaluateProject(project, new DateRange(DateTime.Now, DateTime.Now)));
                        return;
                    }
                }
            }
        }

        private void LoadProjectReport(Project project)
        {
            OpenIssues.Text = project.OpenIssues().ToString();
            ResolvedIssues.Text = project.ResolvedIssues().ToString();
            IssuesTable.Visible = true;
        }


        private void DisplayChart(List<Series> chartData)
        {
            ProjectChart.ChartAreas.Add(new ChartArea("ChartArea1"));

            ProjectChart.Series.Clear();
            foreach (Series series in chartData)
                ProjectChart.Series.Add(series);

            ProjectChart.ChartAreas["ChartArea1"].AxisX.IsMarginVisible = false;

            ProjectChart.Legends.Add(new Legend("Default"));
            ProjectChart.Legends["Default"].LegendStyle = LegendStyle.Row;
            ProjectChart.Legends["Default"].Docking = Docking.Bottom;
            ProjectChart.Legends["Default"].Alignment = System.Drawing.StringAlignment.Center;
        }
    }
}