using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagerDAL;
using ProjectManagerLibrary.Models;

namespace ProjectManagerBLL
{
    public class IssueBLL
    {
        /// <summary>
        /// GetIssue
        /// </summary>
        /// <param name="issueID">int</param>
        /// <returns>ProjectManagerLibrary.Models.Issue</returns>
        public static ProjectManagerLibrary.Models.Issue GetIssue(int issueID)
        {
            try
            {
                return IssueDAL.GetIssue(issueID);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// AddIssue
        /// </summary>
        /// <param name="issue">Issue</param>
        /// <returns>bool</returns>
        public static bool AddIssue(Issue issue)
        {
            try
            {
                return IssueDAL.AddIssue(issue);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        /// <summary>
        /// AddIssueAttachment
        /// </summary>
        /// <param name="issueAttachment">IssueAttachment</param>
        /// <returns>bool</returns>
        public static bool AddIssueAttachment(IssueAttachment issueAttachment)
        {
            try
            {
                return IssueDAL.AddIssueAttachment(issueAttachment);
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
                return IssueDAL.EditIssue(issue);
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// DeleteIssueAttachment
        /// </summary>
        /// <param name="issueAttachmentID">int</param>
        /// <returns>bool</returns>
        public static bool DeleteIssueAttachment(int issueAttachmentID)
        {
            try
            {
                return IssueDAL.DeleteIssueAttachment(issueAttachmentID);
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// GetIssueAttachmentsList
        /// </summary>
        /// <param name="issueID"></param>
        /// <returns></returns>
        public static List<IssueAttachment> GetIssueAttachmentsList(int issueID)
        {
            try
            {
                return IssueDAL.GetIssueAttachmentsList(issueID);
            }
            catch (Exception)
            {
                
                throw;
            }

        }


        /// <summary>
        /// GetIssueAttachment
        /// </summary>
        /// <param name="issueAttachmentID"></param>
        /// <returns></returns>
        public static IssueAttachment GetIssueAttachment(int issueAttachmentID)
        {
            try
            {
                return IssueDAL.GetIssueAttachment(issueAttachmentID);

            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
}
