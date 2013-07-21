using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.DataVisualization.Charting;

namespace ProjectManagerLibrary.Models.Graphs
{
    abstract class GraphBase
    {
        abstract protected ChartArea CreateChartArea();
        abstract protected List<Series> EvaluateProject(Project project, DateRange range);


        protected Chart BuildChart(Project project, DateRange range, string title)
        {
            Chart chart = CreateChart();
            FormatLegend(chart);
            FormatTitle(chart, title);

            chart.ChartAreas.Clear();
            chart.ChartAreas.Add(CreateChartArea());

            List<Series> data = EvaluateProject(project, range);
            AddChartData(chart, data);

            return chart;
        }

        
        private Chart CreateChart()
        {
            Chart chart = new Chart();
            chart.ImageStorageMode = ImageStorageMode.UseImageLocation;
            return chart;
        }


        private Chart FormatLegend(Chart chart)
        {
            Legend legend = new Legend();
            chart.Legends.Clear();
            chart.Legends.Add(legend);
            legend.LegendStyle = LegendStyle.Row;
            legend.Docking = Docking.Bottom;
            legend.Alignment = System.Drawing.StringAlignment.Center;
            return chart;
        }


        private Chart FormatTitle(Chart chart, string titleText)
        {
            Title title = new Title(titleText);
            chart.Titles.Clear();
            chart.Titles.Add(title);
            title.Docking = Docking.Top;
            title.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            title.Font = new System.Drawing.Font(title.Font.FontFamily, 18);
            return chart;
        }

        virtual protected void AddChartData(Chart chart, List<Series> data)
        {
            foreach (Series series in data)
            {
                chart.Series.Add(series);
            }
        }
    }
}
