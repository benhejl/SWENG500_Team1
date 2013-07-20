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
        private int project;

        public Calendar()
        {
            calendarName = null;
            calendarId = -1;
            project = -1;
        }

        public Calendar(String _calendarName, int _calendarId, int _project)
        {
            calendarName = _calendarName;
            calendarId = _calendarId;
            project = _project;
        }

        public void setCalendarName(String _calendarName)
        {
            calendarName = _calendarName;
        }

        public void setCalendarId(int _calendarId)
        {
            calendarId = _calendarId;
        }

        public void setProjectId(int _project)
        {
            project = _project;
        }

        public String getCalendarName()
        {
            return calendarName;
        }

        public int getCalendarId()
        {
            return calendarId;
        }

        public int getProjectId()
        {
            return project;
        }
    }
}
