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


        private IssueStatus _currentStatus;
        public IssueStatus CurrentStatus {
            get
            {
                if (Transitions.Count > 0)
                {
                    return Transitions.ElementAt(Transitions.Count - 1).Value.Status;
                }
                return _currentStatus;
            }
            set
            {
                _currentStatus  = value;
            }
        }

        private SortedList<DateTime, IssueTransition> Transitions;

        public string Description { get; set; }
        //public Project Project { get; set; } 
        public int ProjectID { get; set; }
        public int Milestone { get; set; }  // TODO: This probably wants to be an object
        public User Assignee;
        public string IssueCategoryName { get; set; }
        public DateTime EntryDate { get; set; }

        public Issue()
        {
            CurrentPriority = IssuePriority.Medium;
            CurrentStatus = IssueStatus.Unresolved;

            Transitions = new SortedList<DateTime, IssueTransition>();
        }

        public void UpdateStatus(IssueStatus newStatus, DateTime occurredOn, string comments = "")
        {
            if (occurredOn < EntryDate)
                throw new ArgumentException();

            IssueTransition transition = new IssueTransition(newStatus, occurredOn, comments);
            Transitions.Add(transition.OccurredOn, transition);
        }

        public IssueStatus StatusOn(DateTime dateTime)
        {
            for (int i = Transitions.Count - 1; i >= 0; i--)
            {
                if (Transitions.ElementAt(i).Key <= dateTime) {
                    return Transitions.ElementAt(i).Value.Status;
                }
            }
            throw new ArgumentException();
        }
    }
}
