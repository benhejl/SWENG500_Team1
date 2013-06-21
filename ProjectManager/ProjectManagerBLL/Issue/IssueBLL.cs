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
    }
}
