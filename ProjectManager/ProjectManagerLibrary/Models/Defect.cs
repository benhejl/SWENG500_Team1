using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerLibrary.Models
{
    class Defect
    {
        public enum DefectPriority
        {
            High,
            Medium,
            Low
        }
        public enum DefectStatus
        {
            Unresolved
        }

        public string Subject {get; set;}
        public DefectPriority CurrentPriority { get; set; }
        public DefectStatus CurrentStatus { get; set; }
        public string Description { get; set; }
        public int Project { get; set; } // TODO: This probably wants to be an object
        public int Milestone { get; set; }  // TODO: This probably wants to be an object

        public Defect()
        {
        }
    }
}
