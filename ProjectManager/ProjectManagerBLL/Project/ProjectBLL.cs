using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagerDAL;
using ProjectManagerLibrary.Models;

namespace ProjectManagerBLL.Project
{
    public class ProjectBLL 
    {


        /// <summary>
        /// GetProjectList
        /// </summary>
        /// <returns></returns>
        public List<ProjectManagerLibrary.Models.Project> GetProjectList()
        {
            var projects = new ProjectDAL();

            return projects.GetProjectList();

        }

    }
}
