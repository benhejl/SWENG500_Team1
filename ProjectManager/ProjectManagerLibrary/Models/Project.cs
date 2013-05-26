using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerBLL.Project
{
    class Project
    {
        public string Name { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public int Status { get; private set; }
        public string Description { get; private set; }
        public string Category { get; private set; }
        public DateTime DueDate { get; private set; }

        public Project(string name, string startDate, string endDate, int status, string description, string category, DateTime dueDate)
        {
        }

        
    }
}
