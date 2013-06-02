using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagerLibrary;
using ProjectManagerLibrary.Models;


namespace ProjectManagerDAL
{
    public partial class IssueDAL
    {

        /// <summary>
        /// GetIssueList
        /// </summary>
        /// <returns></returns>
        public List<Issue> GetIssueList(int projectID)
        {
            List<Issue> issues = new List<Issue>();

            using (var db = new ProjectManagerEntities())
            {
                // get the list of issues for a specific ProjectID.
                var query = (from i in db.IssueDALs
                             join ia in db.IssueAssignmentDALs on i.IssueID equals ia.IssueID into IandIA
                             from iaJoin in IandIA.DefaultIfEmpty()
                             join u in db.UserDALs on iaJoin.UserID equals u.UserID into IAandU
                             from uJoin in IAandU.DefaultIfEmpty()
                             where i.ProjectID == projectID
                             select new
                             {
                                 IssueID = iaJoin.IssueID,
                                 Subject = i.Subject,
                                 Priority = i.Priority,
                                 ProjectID = i.ProjectID,
                                 UserID = uJoin.UserID,
                                 Username = uJoin.UserName,
                                 Password = uJoin.Password,
                                 UserRole = uJoin.UserRole,
                                 FirstName = uJoin.FirstName,
                                 LastName = uJoin.LastName,
                                 Email = uJoin.Email,
                                 PhoneNumber = uJoin.PhoneNumber,
                                 Position = uJoin.Position,
                                 TeamName = uJoin.TeamName

                             });


                foreach (var item in query)
                {
                    // build the issue object.
                    var myissue = new Issue()
                    {
                        IssueID = item.IssueID,
                        Subject = item.Subject,
                        CurrentPriority = (Issue.IssuePriority)Enum.Parse(typeof(Issue.IssuePriority), item.Priority),
                        ProjectID = item.ProjectID
                     };

                    // Get the Issue Assignee
                    var user = new User(item.UserID, item.Username, item.Password, item.UserRole, item.FirstName, item.LastName, item.Email, item.PhoneNumber, item.Position, item.TeamName);
                    user.FirstName = item.FirstName;
                    user.LastName = item.LastName;
                    myissue.Assignee = user;

                    issues.Add(myissue);
                }

            }
            return issues;
        }

    }
}
