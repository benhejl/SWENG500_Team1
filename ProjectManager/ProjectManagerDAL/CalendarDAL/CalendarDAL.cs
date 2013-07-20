using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagerLibrary;
using System.Data.SqlClient;
using ProjectManagerLibrary.Models;

namespace ProjectManagerDAL.CalendarDAL
{
    public class CalendarDAL
    {
        private const String CONNECTION_STRING = "Data Source=ProgramManager.db.11222717.hostedresource.com;Initial Catalog=ProgramManager;Persist Security Info=True;User ID=ProgramManager;Password=Asd123!@#";

        public static bool insertNewCalendar(String calendarName, int projectId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO Calendar (Name, Project) VALUES ('" + calendarName + "','" + projectId + "')", sqlConnection))
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
            using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
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

        public static bool updateCalendar(String currentName, String newName, int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE Calendar SET Name='" +  newName + "',Project=" +
                    id + " WHERE Name='" + currentName + "'", sqlConnection))
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
            using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
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

        public static bool deleteEventsByCalendarId(int calendarId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM CalendarEvent WHERE CalendarId=" + calendarId, sqlConnection))
                {
                    try
                    {
                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            sqlDataReader.Close();
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        return true;
                    }
                    catch (System.InvalidOperationException e)
                    {
                        return true;
                    }
                }
                sqlConnection.Close();
            }
            return true;
        }

        public static int getCalendarIdByName(String calendarName)
        {
            int id = -1;
            using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT ID FROM Calendar WHERE Name='" + calendarName + "'", sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            while (sqlDataReader.Read())
                            {
                                id = Convert.ToInt32(sqlDataReader["ID"]);
                            }
                        }
                        sqlDataReader.Close();
                    }
                }
                sqlConnection.Close();
            }
            return id;
        }

        public static ArrayList getEvents()
        {
            ArrayList events = new ArrayList();
            using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM CalendarEvent", sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            while (sqlDataReader.Read())
                            {
                                events.Add(new CalendarEvent(Convert.ToInt32(sqlDataReader["ID"]), Convert.ToString(sqlDataReader["Name"]),
                                    Convert.ToDateTime(sqlDataReader["Start"]), Convert.ToDateTime(sqlDataReader["End"]), 
                                    Convert.ToInt32(sqlDataReader["CalendarId"]), Convert.ToString(sqlDataReader["Type"])));
                            }
                        }
                        sqlDataReader.Close();
                    }
                }
                sqlConnection.Close();
            }

            return events;
        }

        public static bool addNewEvent(CalendarEvent e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO CalendarEvent (Name, Start, [End], CalendarId, Type) "+
                    "VALUES ('" + e.getName() + "','" + e.getStart().ToString() + "','" + e.getEnd().ToString() + "'," + e.getCalendarId() +
                    ",'" + e.getType() + "')", sqlConnection))
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

        public static ProjectManagerLibrary.Models.Calendar getCalendarByName(String calendarName)
        {
            ProjectManagerLibrary.Models.Calendar calendar = new ProjectManagerLibrary.Models.Calendar();
            using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Calendar WHERE Name='" + calendarName + "'", sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            while (sqlDataReader.Read())
                            {
                                calendar.setCalendarId(Convert.ToInt32(sqlDataReader["ID"]));
                                calendar.setCalendarName(Convert.ToString(sqlDataReader["Name"]));
                                calendar.setProjectId(Convert.ToInt32(sqlDataReader["Project"]));
                             }
                        }
                        sqlDataReader.Close();
                    }
                }
                sqlConnection.Close();
            }

            return calendar;
        }

        public static ArrayList getEventsByCalendarId(int calendarId)
        {
            ArrayList events = new ArrayList();
            using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM CalendarEvent WHERE CalendarId=" + calendarId, sqlConnection))
                {
                    System.Diagnostics.Trace.WriteLine(sqlCommand.CommandText);
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            while (sqlDataReader.Read())
                            {
                                events.Add(new CalendarEvent(Convert.ToInt32(sqlDataReader["ID"]), Convert.ToString(sqlDataReader["Name"]),
                                    Convert.ToDateTime(sqlDataReader["Start"]), Convert.ToDateTime(sqlDataReader["End"]),
                                    Convert.ToInt32(sqlDataReader["CalendarId"]), Convert.ToString(sqlDataReader["Type"])));
                            }
                        }
                        sqlDataReader.Close();
                    }
                }
                sqlConnection.Close();
            }

            return events;
        }

        public static bool deleteEventsByName(String eventName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM CalendarEvent WHERE Name=" + eventName, sqlConnection))
                {
                    System.Diagnostics.Trace.WriteLine(sqlCommand.CommandText);
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        sqlDataReader.Close();
                    }
                }
                sqlConnection.Close();
            }

            return true;
        }

        public static ArrayList getProjectNames()
        {
            ArrayList projectInfo = new ArrayList();
            using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT ProjectName FROM Projects", sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            while (sqlDataReader.Read())
                            {
                                projectInfo.Add(Convert.ToString(sqlDataReader["ProjectName"]));
                            }
                        }
                        sqlDataReader.Close();
                    }
                }
                sqlConnection.Close();
            }

            return projectInfo;
        }

        public static int getProjectIdByName(String projectName)
        {
            int id = -1;
            using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT ProjectId FROM Projects WHERE ProjectName='" + projectName + "'", sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            while (sqlDataReader.Read())
                            {
                                id = Convert.ToInt32(sqlDataReader["ProjectId"]);
                            }
                        }
                        sqlDataReader.Close();
                    }
                }
                sqlConnection.Close();
            }

            return id;
        }

    }
}
