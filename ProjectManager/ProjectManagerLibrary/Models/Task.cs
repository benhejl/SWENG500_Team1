using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerLibrary
{
    class Task
    {
        public enum Status
        {
            Unscheduled,
            InProgress, 
            Complete
        }

        public System.DateTime Created {get;set;}
        public System.DateTime CompletedOn { get; set; }
        public Status CurrentStatus { get; set; }
    }
}
