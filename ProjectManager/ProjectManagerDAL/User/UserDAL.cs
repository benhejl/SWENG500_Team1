﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using ProjectManagerLibrary;
using ProjectManagerLibrary.Models;

namespace ProjectManagerDAL
{
    public partial class UserDAL
    {

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="user"></param>
        /// <returns>bool</returns>
        public bool Authenticate(string username, string password)
        {
            var isValid = false;

            if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password))
            {
                using (var db = new ProjectManagerDAL.ProjectManagerEntities())
                {
                    var query = db.UserDALs.FirstOrDefault(u => u.UserName == username && u.Password == password);

                    if (query != null)
                    {
                        // username and password matched - valid user.
                        isValid = true;
                    }
                }
            }
            return isValid;
        }


        /// <summary>
        /// GetUserInfo
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>User Object</returns>
        public User GetUserInfo(string userName)
        {
            User user = new User();
            using (SqlConnection sqlConnection = new SqlConnection(Constants.DATABASE.CONNECTION_STRING))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM USERS WHERE UserName='" + userName + "'", sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            while (sqlDataReader.Read())
                            {
                                user.UserId = Convert.ToInt32(sqlDataReader["UserID"]);
                                user.UserName = Convert.ToString(sqlDataReader["UserName"]);
                                user.UserRole = Convert.ToString(sqlDataReader["UserRole"]);
                                user.FirstName = Convert.ToString(sqlDataReader["FirstName"]);
                                user.LastName = Convert.ToString(sqlDataReader["UserID"]);
                                user.Email = Convert.ToString(sqlDataReader["Email"]);
                                user.PhoneNumber = Convert.ToString(sqlDataReader["PhoneNumber"]);
                                user.Position = Convert.ToString(sqlDataReader["Position"]);
                                user.TeamName = Convert.ToString(sqlDataReader["TeamName"]);
                            }
                        }
                        sqlDataReader.Close();
                    }
                }
                sqlConnection.Close();
            }
            return user;
        }
    }
}
