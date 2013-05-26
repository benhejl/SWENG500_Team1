using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerLibrary.Models
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
        public List<Issue> Issues { get; private set; }

        public Project(string name, DateTime startDate, DateTime endDate, int status, string description, string category, DateTime dueDate)
        {
            if (startDate > endDate || startDate > dueDate || 0 == name.Length)
            {
                throw new ArgumentException("Project start date must proceed the end date and the due date.");
            }

            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
            Description = description;
            Category = category;
            DueDate = dueDate;
            Issues = new List<Issue>();
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
            return 0;
        }

        public int ResovledIssues()
        {
            return 0;
        }
    }
}
