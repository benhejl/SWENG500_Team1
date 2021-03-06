﻿using System;
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
            return true;

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
        /// GetUserListForView
        /// </summary>
        /// <returns>List of User ID and Name KeyValuePair values</returns>
        public static List<KeyValuePair<string, int>> GetUserListForView()
        {
            try
            {
                return UserDAL.GetUserListForView();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// GetUserGivenLogonName
        /// </summary>
        /// <param name="logonName"></param>
        /// <returns></returns>
        public static User GetUserGivenLogonName(string logonName)
        {
            try
            {
                return UserDAL.GetUserGivenLogonName(logonName);
            }
            catch (Exception)
            {
                
                throw;
            }
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
        /// <summary>
        /// GetAllUsers
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>User Object</returns>
        public List<KeyValuePair<string, int>> GetAllUserNames()
        {
            try
            {
                return new ProjectManagerDAL.UserDAL().GetAllUserNames();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
