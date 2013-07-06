using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ProjectManagerDAL.CalendarDAL;
using ProjectManagerDAL.CalendarDAL.CalendarTableAdapters;
using ProjectManagerDAL;
using ProjectManagerLibrary.Models;

namespace ProjectManagerBLL.CalendarBLL
{
    public class CalendarBLL
    {
        public bool createCalendar(String name, String projectName, String usernames)
        {
            return CalendarDAL.insertNewCalendar(name, projectName, usernames);
        }

        public ArrayList getCalendars()
        {
            return CalendarDAL.getCalendarNames();
        }

        public ArrayList getProjectNames()
        {
            return ProjectDAL.getProjectNames();
        }

        public bool updateCalendarInfo(String currentName, String newName, String newProject, String newUsers)
        {
            return CalendarDAL.updateCalendar(currentName, newName, newProject, newUsers);
        }

        public bool deleteCalendar(String calendarToDelete)
        {
            return CalendarDAL.deleteCalendar(calendarToDelete);
        }

        public ArrayList getUsers()
        {
            ArrayList usernames = UserDAL.GetUserNamesForCalendar();
            return usernames;
        }
    }
}
