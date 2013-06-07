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
    }
}
