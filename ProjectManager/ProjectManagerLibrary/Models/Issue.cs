using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerLibrary.Models
{
    class Issue
    {
        public enum IssuePriority
        {
            High,
            Medium,
            Low
        }
        public enum IssueStatus
        {
            Unresolved
        }

        public string Subject {get; set;}
        public IssuePriority CurrentPriority { get; set; }
        public IssueStatus CurrentStatus { get; set; }
        public string Description { get; set; }
        public Project Project { get; set; } 
        public int Milestone { get; set; }  // TODO: This probably wants to be an object

        public Issue()
        {
            CurrentPriority = IssuePriority.Medium;
            CurrentStatus = IssueStatus.Unresolved;
        }
    }
}
