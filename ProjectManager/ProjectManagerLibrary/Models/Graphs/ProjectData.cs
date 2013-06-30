using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.DataVisualization.Charting;

namespace ProjectManagerLibrary.Models.Graphs
{
    public interface ProjectData
    {
        System.Web.UI.Control Display(Project project, DateRange range);
        string DataTitle {get;}
        bool RequiresDateRange { get; }
        DateRange CurrentDateRange { get; }
    }
}
