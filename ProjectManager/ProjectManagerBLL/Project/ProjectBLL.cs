using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagerDAL;
using ProjectManagerLibrary.Models;

namespace ProjectManagerBLL
{
    public class ProjectBLL 
    {

        /// <summary>
        /// GetProject
        /// </summary>
        /// <param name="projectID">int</param>
        /// <returns>ProjectManagerLibrary.Models.Project</returns>
        public static ProjectManagerLibrary.Models.Project GetProject(int projectID)
        {
            try
            {
                return ProjectDAL.GetProject(projectID);
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// GetProjectList
        /// </summary>
        /// <returns>List of ProjectManagerLibrary.Models.Project</returns>
        public static List<ProjectManagerLibrary.Models.Project> GetProjectList()
        {
            try
            {
                return ProjectDAL.GetProjectList();
            }
            catch (Exception)
            {
                
                throw;
            }


        }

        /// <summary>
        /// GetProjectListForView
        /// </summary>
        /// <returns>List of Project ID and Name KeyValuePair values</returns>
        public static List<KeyValuePair<string, int>> GetProjectListForView()
        {
            try
            {
                return ProjectDAL.GetProjectListForView();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
