using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.DataVisualization.Charting;

namespace ProjectManagerLibrary.Models.Graphs
{
    public class OpenVsResolvedStrategy : ProjectData
    {
        static string OpenSeriesName = "Open";
        static string ResolvedSeriesName = "Resolved";

        public List<Series> EvaluateProject(Project project, DateRange range)
        {
            if ((null == project) || (null == range))
                throw new ArgumentNullException();

            List<Series> data = new List<Series>(2);
            data.Add(new Series(OpenSeriesName));
            data.Add(new Series(ResolvedSeriesName));

            for (int i = 0; i < 5; i++)
            {
                data[0].Points.AddY(4 - i);
                data[1].Points.AddY(i);
            }

            data[0].ChartType = SeriesChartType.Line;
            data[1].ChartType = SeriesChartType.Line;

            return data;
        }
    }
}
