using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagerLibrary;
using System.Data.SqlClient;

namespace ProjectManagerDAL.CalendarDAL
{
    public class CalendarDAL
    {
        public static bool insertNewCalendar(String calendarName, String users, String projectName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.DATABASE.CONNECTION_STRING))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO Calendar (Name, Project, Users) VALUES ('" + calendarName + "','" + users + "','" + projectName + "')", sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        sqlDataReader.Close();
                    }
                }
                sqlConnection.Close();
            }
            return true;
        }

        public static ArrayList getCalendarNames()
        {
            ArrayList calendarNames = new ArrayList();
            using (SqlConnection sqlConnection = new SqlConnection(Constants.DATABASE.CONNECTION_STRING))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT Name FROM Calendar", sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            while (sqlDataReader.Read())
                            {
                                calendarNames.Add(Convert.ToString(sqlDataReader["Name"]));
                            }
                        }
                        sqlDataReader.Close();
                    }
                }
                sqlConnection.Close();
            }
            return calendarNames;
        }

        public static bool updateCalendar(String currentName, String newName, String projectName, String users)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.DATABASE.CONNECTION_STRING))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE Calendar SET Name='" +  newName + "',Project='" +
                    projectName + "',Users='" + users + "' WHERE Name='" + currentName + "'", sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        sqlDataReader.Close();
                    }
                }
                sqlConnection.Close();
            }
            return true;
        }

        public static bool deleteCalendar(String name)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.DATABASE.CONNECTION_STRING))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM Calendar WHERE Name='" + name + "'", sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        sqlDataReader.Close();
                    }
                }
                sqlConnection.Close();
            }
            return true;
        }

    }
}
