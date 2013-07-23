using System;
using System.Collections;
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
        /// GetUserListForView
        /// </summary>
        /// <returns>List of User ID and Name KeyValuePair values</returns>
        public static List<KeyValuePair<string, int>> GetUserListForView()
        {
            try
            {
                // key value pair list.
                var userList = new List<KeyValuePair<string, int>>();

                using (var db = new ProjectManagerEntities())
                {
                    var query = from u in db.UserDALs
                                select u;

                    if (query != null)
                    {
                        foreach (var q in query)
                        {
                            // add user full name and id to the list.
                            userList.Add(new KeyValuePair<string, int>(q.FirstName + " " + q.LastName, q.UserID));
                        }
                    }

                    return userList;
                }
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
            var user = new User();

            try
            {

                using (var db = new ProjectManagerEntities())
                {
                    var query = (from u in db.UserDALs
                                where u.UserName == logonName
                                select u).First();

                    if (query != null)
                    {
                        user.UserId = query.UserID;
                        user.UserName = query.UserName;
                        user.Password = query.Password;
                        user.UserRole = query.UserRole;
                        user.FirstName = query.FirstName;
                        user.LastName = query.LastName;
                        user.Email = query.Email;
                        user.PhoneNumber = query.PhoneNumber;
                        user.Position = query.Position;
                        user.TeamName = query.Position;
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return user;
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
        /// <summary>
        /// GetAllUsers
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>User Object</returns>
        public List<KeyValuePair<string, int>> GetAllUserNames()
        {
            List<KeyValuePair<string, int>> userList = new List<KeyValuePair<string, int>>();
            using (SqlConnection sqlConnection = new SqlConnection(Constants.DATABASE.CONNECTION_STRING))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT FirstName, LastName, UserID FROM USERS", sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            while (sqlDataReader.Read())
                            {
                                userList.Add(new KeyValuePair<string, int>(Convert.ToString(sqlDataReader["FirstName"]) + " " + Convert.ToString(sqlDataReader["LastName"]), Convert.ToInt32(sqlDataReader["UserID"])));
                            }
                        }
                        sqlDataReader.Close();
                    }
                }
                sqlConnection.Close();
            }
            return userList;
        }

        //Functions for the calendar
        public static ArrayList GetUserNamesForCalendar() {
            ArrayList list = new ArrayList();
            using (SqlConnection sqlConnection = new SqlConnection(Constants.DATABASE.CONNECTION_STRING))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT UserName FROM USERS", sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            while (sqlDataReader.Read())
                            {
                                list.Add(Convert.ToString(sqlDataReader["UserName"]));
                            }
                        }
                        sqlDataReader.Close();
                    }
                }
                sqlConnection.Close();
            }
            return list;
        }
    }

}
