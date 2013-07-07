using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagerLibrary;
using ProjectManagerLibrary.Models;
using System.Collections;
using System.Data.SqlClient;

namespace ProjectManagerDAL
{
    public partial class ProjectDAL
    {

        /// <summary>
        /// GetProject
        /// </summary>
        /// <param name="projectID">int</param>
        /// <returns>Project</returns>
        public static Project GetProject(int projectID)
        {
            try
            {   // get the project info from database.
                using (var db = new ProjectManagerEntities())
                {
                    var query = (from p in db.ProjectDALs
                                 where p.ProjectID == projectID
                                select p).FirstOrDefault();

                    if (query != null)
                    {
                        var proj = new Project
                                 (
                                      query.ProjectID,
                                      query.Name,
                                      DateTime.Parse(query.StartDate.ToString()),
                                      DateTime.Parse(query.EndDate.ToString()),
                                      query.Status,
                                      query.Description,
                                      query.ProjectCategoryID.ToString(),
                                      DateTime.Parse(query.DueDate.ToString())
                                 );

                        return proj;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return null;

        }

        /// <summary>
        /// GetProjectList
        /// </summary>
        /// <returns>List<IssueModel></returns>
        public static List<Project> GetProjectList()
        {
            List<Project> projects = new List<Project>();

            try
            {
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

            }
            catch (Exception)
            {
                throw;
            }
            return projects;
        }



        /// <summary>
        /// GetProjectListForView
        /// </summary>
        /// <returns>List of Project ID and Name KeyValuePair values</returns>
        public static List<KeyValuePair<string, int>> GetProjectListForView()
        {
            try
            {
                // key value pair list.
                var projectsList = new List<KeyValuePair<string, int>>();

                using (var db = new ProjectManagerEntities())
                {
                    var query = from p in db.ProjectDALs
                                select p;

                    if (query != null)
                    {
                        foreach (var q in query)
                        {
                            // add project id and name to the list.
                            projectsList.Add(new KeyValuePair<string, int>(q.Name, q.ProjectID));
                        }
                    }

                    return projectsList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Functions for calendar
        public static ArrayList getProjectNames()
        {
            ArrayList projectNames = new ArrayList();
            using (SqlConnection sqlConnection = new SqlConnection(Constants.DATABASE.CONNECTION_STRING))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT Name FROM Projects", sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            while (sqlDataReader.Read())
                            {
                                projectNames.Add(Convert.ToString(sqlDataReader["Name"]));
                            }
                        }
                        sqlDataReader.Close();
                    }
                }
                sqlConnection.Close();
            }
            return projectNames;
        }

    }
}
