using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagerLibrary.Models
{
    public class Issue
    {
        public enum IssuePriority
        {
            High,
            Medium,
            Low
        }
        public enum IssueStatus
        {
            Unresolved,
            Resolved
        }

        public int IssueID { get; set; }
        [Required(ErrorMessage = "The Subject field is required.")]
        public string Subject {get; set;}
        public IssuePriority CurrentPriority { get; set; }
        public IssueStatus CurrentStatus { get; set; }
        public string Description { get; set; }
        //public Project Project { get; set; } 
        public int ProjectID { get; set; }
        public int Milestone { get; set; }  // TODO: This probably wants to be an object
        public User Assignee;

        public Issue()
        {
            CurrentPriority = IssuePriority.Medium;
            CurrentStatus = IssueStatus.Unresolved;
        }
    }
}
