using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerLibrary.Models
{
    
    public class CalendarEvent
    {
        private int id;
        private String name;
        private DateTime start;
        private DateTime end;
        private int calendarId;

        public CalendarEvent()
        {
            id = -1;
            name = null;
            start = DateTime.MinValue;
            end = DateTime.MinValue;
            calendarId = -1;
        }

        public CalendarEvent(int _id, String _name, DateTime _start, DateTime _end, int _calendarId)
        {
            id = _id;
            name = _name;
            start = _start;
            end = _end;
            calendarId = _calendarId;
        }

        public void setId(int _id)
        {
            id = _id;
        }

        public void setName(String _name)
        {
            name = _name;
        }

        public void setStart(DateTime _start)
        {
            start = _start;
        }

        public void setEnd(DateTime _end)
        {
            end = _end;
        }

        public void setCalendarId(int _calendarId) 
        {
            calendarId = _calendarId;
        }

        public int getId()
        {
            return id;
        }

        public String getName()
        {
            return name;
        }

        public DateTime getStart()
        {
            return start;
        }

        public DateTime getEnd()
        {
            return end;
        }

        public int getCalendarId()
        {
            return calendarId;
        }
    }
}
