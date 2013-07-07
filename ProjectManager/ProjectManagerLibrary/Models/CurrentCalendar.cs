using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerLibrary.Models
{
    public class CurrentCalendar
    {
        private String currentCalendarName;
        private int currentCalendarId;
        private String currentProjectName;
        private String currentUsers;

        public CurrentCalendar()
        {
            currentCalendarName = null;
            currentCalendarId = -1;
            currentProjectName = null;
            currentUsers = null;
        }

        public CurrentCalendar(String _calendarName, int _calendarId, String _projectName, String _users)
        {
            currentCalendarName = _calendarName;
            currentCalendarId = _calendarId;
            currentProjectName = _projectName;
            currentUsers = _users;
        }

        public void setCalendarName(String _calendarName)
        {
            currentCalendarName = _calendarName;
        }

        public void setCalendarId(int _calendarId)
        {
            currentCalendarId = _calendarId;
        }

        public void setProjectName(String _projectName)
        {
            currentProjectName = _projectName;
        }

        public void setUsers(String _users)
        {
            currentUsers = _users;
        }

        public String getCalendarName()
        {
            return currentCalendarName;
        }

        public int getCalendarId()
        {
            return currentCalendarId;
        }

        public String getProjectName()
        {
            return currentProjectName;
        }

        public String getUsers()
        {
            return currentUsers;
        }
    }
}
