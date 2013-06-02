using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagerLibrary.Models
{
    public class Project
    {
        public int ProjectID { get; set; }
        [Required(ErrorMessage = "Project Name field is required.")]
        public string Name { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Status { get; private set; }
        public string Description { get; private set; }
        public string Category { get; private set; }
        public DateTime DueDate { get; private set; }
        public List<Issue> Issues { get; set; }

        public Project(int projectid, string name, DateTime startDate, DateTime endDate, string status, string description, string category, DateTime dueDate)
        {
            if (startDate > endDate || startDate > dueDate || 0 == name.Length)
            {
                throw new ArgumentException("Project start date must proceed the end date and the due date.");
            }
            ProjectID = projectid;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
            Description = description;
            Category = category;
            DueDate = dueDate;
            Issues = new List<Issue>();
        }

        public override string ToString()
        {
            return Name;
        }

        public void AddIssue(Issue issue)
        {
            if (null == issue)
            {
                throw new ArgumentNullException();
            }

            Issues.Add(issue);
        }

        public int OpenIssues()
        {
            int count = 0;
            foreach (Issue issue in Issues)
            {
                if (issue.CurrentStatus == Issue.IssueStatus.Unresolved)
                {
                    count++;
                }
            }
            return count;
        }

        public int ResolvedIssues()
        {
            int count = 0;
            foreach (Issue issue in Issues)
            {
                if (issue.CurrentStatus == Issue.IssueStatus.Resolved)
                {
                    count++;
                }
            }
            return count;
        }
    }

}
