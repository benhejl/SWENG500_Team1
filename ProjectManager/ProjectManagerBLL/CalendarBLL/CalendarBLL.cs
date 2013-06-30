using System;
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
        public bool createCalendar(String name)
        {
            CalendarTableAdapter newCalendar = new CalendarTableAdapter();
            System.Diagnostics.Trace.WriteLine("HERE: " + newCalendar.InsertQuery(name) + " " + name);
            return true;
        }

        public DataRowCollection getCalendars()
        {
            CalendarTableAdapter currentCalendars = new CalendarTableAdapter();
            Calendar.CalendarDataTable data = currentCalendars.GetData();

            return data.Rows;
        }

        public DataRowCollection getCalendarData(String calendarName)
        {
            CalendarTableAdapter calendarData = new CalendarTableAdapter();
            Calendar.CalendarDataTable data = calendarData.GetCalendarInfo(calendarName);

            return data.Rows;
        }

        public bool updateCalendarInfo(String currentName, String newName)
        {
            CalendarTableAdapter calendarToUpdate = new CalendarTableAdapter();
            int ret = calendarToUpdate.UpdateQuery(newName, currentName);
            if (ret > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool deleteCalendar(String calendarToDelete)
        {
            CalendarTableAdapter adapter = new CalendarTableAdapter();
            int ret = adapter.DeleteQuery(calendarToDelete);
            if (ret > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /**public List<KeyValuePair<string, int>> getUsers()
        {
            List<KeyValuePair<string, int>> users = UserDAL.GetUserListForView();
            return users;
        }

        public List<KeyValuePair<string, int>> getProjects()
        {
            List<KeyValuePair<string, int>> projects = ProjectDAL.GetProjectListForView();
            return projects;
        }**/
    }
}
