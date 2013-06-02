using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagerLibrary;
using ProjectManagerLibrary.Models;

namespace ProjectManagerDAL
{
    public partial class ProjectDAL
    {

        /// <summary>
        /// GetProjectList
        /// </summary>
        /// <returns>List<IssueModel></returns>
        public List<Project> GetProjectList()
        {
            List<Project> projects = new List<Project>();

            using (var db = new ProjectManagerEntities())
            {
                var query = from p in db.ProjectDALs
                            select p;

                // get the list of projects.
                foreach (var q in query)
                {
                    var proj = new Project
                             (
                                  q.ProjectID,
                                  q.Name,
                                  DateTime.Parse(q.StartDate.ToString()),
                                  DateTime.Parse(q.EndDate.ToString()),
                                  q.Status,
                                  q.Description,
                                  q.ProjectCategoryID.ToString(),
                                  DateTime.Parse(q.DueDate.ToString())
                             );
                    var issueDals = new IssueDAL();
                    // get the list of issues for the specific projectID.
                    proj.Issues = issueDals.GetIssueList(proj.ProjectID);
                    // add to the project list
                    projects.Add(proj);
 
                }

            }
            return projects;
        }

    }
}
