using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManagerLibrary.Models;
using ProjectManagerBLL;

namespace ProjectManagerWeb.Controllers
{
    public class UserController
    {
        public User GetUserInfo(string userName)
        {
            return new UserBLL().GetUserInfo(userName);
        }
        /// <summary>
        /// GetUserListForView
        /// </summary>
        /// <returns>List of User ID and Name KeyValuePair values</returns>
        public List<KeyValuePair<string, int>> GetUserListForView()
        {
            try
            {
                return UserBLL.GetUserListForView();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// GetAllUsers
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>User Object</returns>
        public List<KeyValuePair<string, int>> GetAllUserNames()
        {
            try
            {
                return new ProjectManagerBLL.UserBLL().GetAllUserNames();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
