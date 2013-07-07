using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace ProjectManagerLibrary.Models.Reports
{
    class IssuesByUser : SummaryBase
    {
        public override TableRow[] SummaryForProject(Project project)
        {
            if (null == project || 0 == project.Issues.Count)
                return new TableRow[0];

            List<TableRow> rows = new List<TableRow>(4);
            rows.Add(HeaderRow("Issue Status"));
            rows.Add(CreateRow("Status", "Count", true));

            Dictionary<string, int> issuesByUser = FindIssuesByUser(project);
            List<KeyValuePair<string, int>> sortedIssues = SortIssuesForDisplay(issuesByUser);
            foreach (KeyValuePair<string, int> user in sortedIssues)
            {
                rows.Add(CreateRow(user.Key, user.Value.ToString()));
            }

            return rows.ToArray<TableRow>();
        }

        private Dictionary<string, int> FindIssuesByUser(Project project)
        {
            Dictionary<string, int> assignedIssues = new Dictionary<string, int>();
            foreach (Issue issue in project.Issues)
            {
                if (assignedIssues.ContainsKey(issue.Assignee.UserName))
                {
                    assignedIssues[issue.Assignee.UserName]++;
                }
                else
                {
                    assignedIssues.Add(issue.Assignee.UserName, 1);
                }
            }
            return assignedIssues;
        }

        private List<KeyValuePair<string, int>> SortIssuesForDisplay(Dictionary<string, int> dictionary)
        {
            List<KeyValuePair<string, int>> list = dictionary.ToList();
            list.Sort(delegate(KeyValuePair<string, int> first, KeyValuePair<string, int> second) {
                if (second.Value != first.Value)
                    return second.Value - first.Value;
                return first.Key.CompareTo(second.Key);
            });
            return list;
        }
    }
}
