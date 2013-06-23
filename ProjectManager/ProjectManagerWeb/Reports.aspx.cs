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
        private ChartArea chartArea;
        private Legend legend;
        private Title title;

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

            ProjectChart.Visible = false;

            chartArea = new ChartArea();
            ProjectChart.ChartAreas.Clear();
            ProjectChart.ChartAreas.Add(chartArea);
            chartArea.AxisX.IsMarginVisible = false;
            chartArea.BorderDashStyle = ChartDashStyle.NotSet;

            ConfigureAxis(chartArea.AxisX);
            ConfigureAxis(chartArea.AxisY);

            legend = new Legend();
            ProjectChart.Legends.Clear();
            ProjectChart.Legends.Add(legend);
            legend.LegendStyle = LegendStyle.Row;
            legend.Docking = Docking.Bottom;
            legend.Alignment = System.Drawing.StringAlignment.Center;

            title = new Title();
            ProjectChart.Titles.Clear();
            ProjectChart.Titles.Add(title);
            title.Docking = Docking.Top;
            title.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            title.Font = new System.Drawing.Font(legend.Font.FontFamily, 18);
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
                        title.Text = data.DataTitle;
                        //DisplayChartData(data.EvaluateProject(project, new DateRange(DateTime.Now, DateTime.Now)));
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


        /// <summary>
        /// Add and format the selected data to the current chart object.  
        /// </summary>
        /// <param name="chartData">A list of Series objects to plot.</param>
        private void DisplayChartData(List<Series> chartData)
        {
            ProjectChart.Series.Clear();
            foreach (Series series in chartData)
            {
                ProjectChart.Series.Add(series);
                series.BorderWidth = 2;
                series.BorderDashStyle = ChartDashStyle.Dot;
                series.MarkerStyle = MarkerStyle.Circle;
                series.MarkerSize = 6;
            }
        }


        /// <summary>
        /// Update the appearance of the target axis.
        /// </summary>
        /// <param name="axis">Axis to update the appearance of.</param>
        private void ConfigureAxis(Axis axis)
        {
            axis.LineColor = System.Drawing.Color.LightGray;
            axis.MajorTickMark.LineColor = axis.LineColor;
            axis.MinorTickMark.LineColor = axis.LineColor;
            axis.MajorGrid.Enabled = false;
            axis.MinorGrid.Enabled = false;
        }
    }
}