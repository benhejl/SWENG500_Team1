using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.DataVisualization.Charting;

namespace ProjectManagerLibrary.Models.Graphs
{
    public interface ProjectData
    {
        List<Series> EvaluateProject(Project project, DateRange range);
    }
}
