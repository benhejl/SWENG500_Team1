using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagerDAL;
using ProjectManagerLibrary.Models;


namespace ProjectManagerBLL
{
    public class UserBLL
    {

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="user"></param>
        /// <returns>bool</returns>
        public bool Login(string Username, string Password)
        {
            var isValid = false;
            try
            {
                if (Username != null && Password != null)
                {
                    // inistantiate a UserDAL object & authenticate
                    var userDAL = new ProjectManagerDAL.UserDAL();
                    isValid = userDAL.Authenticate(Username, Password);
                }
            }
            catch (Exception)
            {
                
                throw;
            }

            return isValid;
        }

        /// <summary>
        /// GetUserInfo
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>User</returns>
        public User GetUserInfo(string userName)
        {
            try
            {
                return new ProjectManagerDAL.UserDAL().GetUserInfo(userName);
            }
            catch (Exception)
            {
                
                throw;
            }
            

        }

    }
}
