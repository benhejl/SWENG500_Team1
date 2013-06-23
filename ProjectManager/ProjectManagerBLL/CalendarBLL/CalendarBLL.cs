using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagerDAL.CalendarDAL.CurrentCalendarTableAdapters;

namespace ProjectManagerBLL.CalendarBLL
{
    public class CalendarBLL
    {
        public bool createCalendar(String name)
        {
            CurrentCalendarTableAdapter newCalendar = new CurrentCalendarTableAdapter();
            System.Diagnostics.Trace.WriteLine("HERE: " + newCalendar.insertNewCalendar(name));
            return true;
        }
    }
}
