using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagerLibrary;
using ProjectManagerLibrary.Models;
using System.Transactions;

namespace ProjectManagerDAL
{
    public partial class IssueDAL
    {

        /// <summary>
        /// Get Issue
        /// </summary>
        /// <param name="issueID">int</param>
        /// <returns>Issue</returns>
        public static Issue GetIssue(int issueID)
        {
            var issue = new Issue();

            try
            {
                // get issue information from database.
                using (var db = new ProjectManagerEntities())
                {
                    var query = (from i in db.IssueDALs
                                 join ia in db.IssueAssignmentDALs on i.IssueID equals ia.IssueID into IandIA
                                 from iaJoin in IandIA.DefaultIfEmpty()
                                 join u in db.UserDALs on iaJoin.UserID equals u.UserID into IAandU
                                 from uJoin in IAandU.DefaultIfEmpty()
                                 where i.IssueID == issueID
                                 select new
                                 {
                                     IssueID = iaJoin.IssueID,
                                     Subject = i.Subject,
                                     Priority = i.Priority,
                                     Status = i.Status,
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
                                     TeamName = uJoin.TeamName,
                                     IssueCategoryName = i.IssueCategoryName,
                                     EntryDate = i.EntryDate,
                                     Description = i.Description

                                 }).FirstOrDefault();

                    if (query != null)
                    {
                        // build the issue object.
                        issue = new Issue()
                        {
                            IssueID = query.IssueID,
                            Subject = query.Subject,
                            CurrentStatus = (Issue.IssueStatus)Enum.Parse(typeof(Issue.IssueStatus), query.Status),
                            CurrentPriority = (Issue.IssuePriority)Enum.Parse(typeof(Issue.IssuePriority), query.Priority),
                            ProjectID = query.ProjectID,
                            IssueCategoryName = query.IssueCategoryName,
                            EntryDate = query.EntryDate ?? DateTime.MinValue,
                            Description = query.Description

                        };

                        // Get the Issue Assignee
                        var user = new User(query.UserID, query.Username, query.Password, query.UserRole, query.FirstName, query.LastName, query.Email, query.PhoneNumber, query.Position, query.TeamName);
                        user.FirstName = query.FirstName;
                        user.LastName = query.LastName;
                        issue.Assignee = user;

                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            
            return issue;
        }

        /// <summary>
        /// GetIssueList
        /// </summary>
        /// <returns></returns>
        public List<Issue> GetIssueList(int projectID)
        {
            List<Issue> issues = new List<Issue>();

            try
            {
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
                                     Status = i.Status,
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
                                     TeamName = uJoin.TeamName,
                                     IssueCategoryName = i.IssueCategoryName,
                                     EntryDate = i.EntryDate,
                                     Description = i.Description

                                 });


                    foreach (var item in query)
                    {
                        // build the issue object.
                        var myissue = new Issue()
                        {
                            IssueID = item.IssueID,
                            Subject = item.Subject,
                            CurrentStatus = (Issue.IssueStatus)Enum.Parse(typeof(Issue.IssueStatus), item.Status),
                            CurrentPriority = (Issue.IssuePriority)Enum.Parse(typeof(Issue.IssuePriority), item.Priority),
                            ProjectID = item.ProjectID,
                            IssueCategoryName = item.IssueCategoryName,
                            EntryDate = item.EntryDate ?? DateTime.MinValue,
                            Description = item.Description
                        };

                        // Get the Issue Assignee
                        var user = new User(item.UserID, item.Username, item.Password, item.UserRole, item.FirstName, item.LastName, item.Email, item.PhoneNumber, item.Position, item.TeamName);
                        user.FirstName = item.FirstName;
                        user.LastName = item.LastName;
                        myissue.Assignee = user;

                        issues.Add(myissue);
                    }

                }

            }
            catch (Exception)
            {
                throw;
            }

            return issues;
        }


        /// <summary>
        /// GetIssueAttachmentsList
        /// </summary>
        /// <param name="issueID"></param>
        /// <returns></returns>
        public static List<IssueAttachment> GetIssueAttachmentsList(int issueID)
        {
            List<IssueAttachment> issueAttachments = new List<IssueAttachment>();

            try
            {
                using (var db = new ProjectManagerEntities())
                {
                    // get the list of file attachments for a specific Issue.
                    var query = from i in db.IssueAttachmentDALs
                                where i.IssueID == issueID
                                select i;

                    foreach (var item in query)
                    {
                        // build the issue  attachment object.
                        var fileAttachment = new IssueAttachment()
                        {
                            IssueAttachmentID = item.IssueAttachmentID,
                            FileName = item.Filename,
                            EntryDate = item.EntryDate,
                            Description = item.Description,
                            UserID = item.UserID,
                            IssueID = item.IssueID,
                            MimeType = item.MimeType
                        };

                        issueAttachments.Add(fileAttachment);
                    }

                }

            }
            catch (Exception)
            {
                throw;
            }

            return issueAttachments;

        }


        /// <summary>
        /// GetIssueAttachment
        /// </summary>
        /// <param name="issueAttachmentID">int</param>
        /// <returns></returns>
        public static IssueAttachment GetIssueAttachment(int issueAttachmentID)
        {
            var issueAttachments = new IssueAttachment();

            try
            {
                using (var db = new ProjectManagerEntities())
                {
                    // get the file attachment.
                    var query = (from i in db.IssueAttachmentDALs
                                 where i.IssueAttachmentID == issueAttachmentID
                                select i).First();

                    if (query != null)
                    {
                        query.IssueAttachmentID = issueAttachments.IssueID;
                        query.Filename = issueAttachments.FileName;
                        query.EntryDate = issueAttachments.EntryDate;
                        query.Description = issueAttachments.Description;
                        query.IssueID = issueAttachments.IssueID;
                        query.UserID = issueAttachments.UserID;
                        query.MimeType = issueAttachments.MimeType;
                        query.FileData = issueAttachments.FileData;
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }

            return issueAttachments;

        }

        /// <summary>
        /// AddIssue - Add New Issue
        /// </summary>
        /// <param name="issue">Issue</param>
        /// <returns>bool</returns>
        public static bool AddIssue(Issue issue)
        {
            try
            {
                var returnValue = false;
                var id = 0;

                // wrap in a TransactionScope since we are updating two tables - Issues and IssueAssignments
                using (TransactionScope transaction = new TransactionScope())
                {

                    using (var db = new ProjectManagerEntities())
                    {

                            db.Connection.Open();
                            var i = new IssueDAL();
                            //i.IssueID = -1;
                            i.Subject = issue.Subject;
                            i.ProjectID = issue.ProjectID;
                            i.Priority = issue.CurrentPriority.ToString();
                            i.Status = issue.CurrentStatus.ToString();
                            i.Description = issue.Description;
                            i.IssueCategoryName = issue.IssueCategoryName;
                            i.EntryDate = issue.EntryDate;

                            // save issue.
                            db.IssueDALs.AddObject(i);
                            db.SaveChanges();

                            // get the newly inserted issueid.
                            id = i.IssueID;

                            // save issue assignment.
                            var issueAssignment = new IssueAssignmentDAL();
                            issueAssignment.IssueID = id;
                            issueAssignment.UserID = issue.Assignee.UserId;
                            db.IssueAssignmentDALs.AddObject(issueAssignment);
                            db.SaveChanges();

                        }

                        transaction.Complete();

                        // successfully inserted.
                        returnValue = true;
                }

                return returnValue;

            }
            catch (TransactionAbortedException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// EditIssue
        /// </summary>
        /// <param name="issue">Issue</param>
        /// <returns>bool</returns>
        public static bool EditIssue(Issue issue)
        {
            try
            {
                var returnValue = false;

                // wrap in a TransactionScope since we are updating two tables - Issues and IssueAssignments
                using (TransactionScope transaction = new TransactionScope())
                {

                    using (var db = new ProjectManagerEntities())
                    {
                        db.Connection.Open();

                        var query = (from i in db.IssueDALs
                                    where i.IssueID == issue.IssueID
                                    select i).First();

                        if (query != null)
                        {
                            query.IssueID = issue.IssueID;
                            query.Subject = issue.Subject;
                            query.ProjectID = issue.ProjectID;
                            query.Priority = issue.CurrentPriority.ToString();
                            query.Status = issue.CurrentStatus.ToString();
                            query.Description = issue.Description;
                            query.IssueCategoryName = issue.IssueCategoryName;
                            query.EntryDate = issue.EntryDate;
                        }


                        // update issue.
                        db.SaveChanges();
                        
                        // get Issue Assignment for this issue.
                        var query2 = (from ia in db.IssueAssignmentDALs
                                     where ia.IssueID == issue.IssueID
                                     select ia).First();

                        if (query2 != null)
                        {
                            query2.IssueID = issue.IssueID;
                            query2.UserID = issue.Assignee.UserId;
                        }

                        // update issue assignment.
                        db.SaveChanges();

                    }

                    transaction.Complete();

                    // successfully inserted.
                    returnValue = true;
                }

                return returnValue;

            }
            catch (TransactionAbortedException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
