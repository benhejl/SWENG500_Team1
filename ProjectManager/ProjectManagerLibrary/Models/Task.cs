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

        private DateTime completedOn = DateTime.MinValue;

        public System.DateTime Created { get; set; }
        public System.DateTime CompletedOn
        {
            get
            {
                return CurrentStatus == Status.Complete ? completedOn : DateTime.MinValue;
            }
            set
            {
                completedOn = value;
            }
        }
        public Status CurrentStatus { get; set; }
    }
}
