using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerLibrary.Models
{
    public class Calendar
    {
        private String calendarName;
        private int calendarId;
        private String projectName;
        private String users;

        public Calendar()
        {
            calendarName = null;
            calendarId = -1;
            projectName = null;
            users = null;
        }

        public Calendar(String _calendarName, int _calendarId, String _projectName, String _users)
        {
            calendarName = _calendarName;
            calendarId = _calendarId;
            projectName = _projectName;
            users = _users;
        }

        public void setCalendarName(String _calendarName)
        {
            calendarName = _calendarName;
        }

        public void setCalendarId(int _calendarId)
        {
            calendarId = _calendarId;
        }

        public void setProjectName(String _projectName)
        {
            projectName = _projectName;
        }

        public void setUsers(String _users)
        {
            users = _users;
        }

        public String getCalendarName()
        {
            return calendarName;
        }

        public int getCalendarId()
        {
            return calendarId;
        }

        public String getProjectName()
        {
            return projectName;
        }

        public String getUsers()
        {
            return users;
        }
    }
}
