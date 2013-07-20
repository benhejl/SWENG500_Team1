﻿using System;
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
        public bool createCalendar(String name, String projectName)
        {
            int id = CalendarDAL.getProjectIdByName(projectName);
            if (id > 0)
            {
                return CalendarDAL.insertNewCalendar(name, id);
            }
            else
            {
                return false;
            }
        }

        public ArrayList getCalendars()
        {
            return CalendarDAL.getCalendarNames();
        }

        public ArrayList getProjectNames()
        {
            return CalendarDAL.getProjectNames();
        }

        public bool updateCalendarInfo(String currentName, String newName, String newProject)
        {
            int id = CalendarDAL.getProjectIdByName(newProject);
            return CalendarDAL.updateCalendar(currentName, newName, id);
        }

        public bool deleteCalendar(String calendarToDelete)
        {
            int id = -1;
            if ((id = CalendarDAL.getCalendarIdByName(calendarToDelete)) > 0) {
                if (deleteEventsByCalendarId(id))
                {
                    return CalendarDAL.deleteCalendar(calendarToDelete);
                }
            }
            return false;
        }

        public ArrayList getUsers()
        {
            ArrayList usernames = UserDAL.GetUserNamesForCalendar();
            return usernames;
        }

        public bool deleteEventsByCalendarId(int calendarToDelete)
        {
            return CalendarDAL.deleteEventsByCalendarId(calendarToDelete);
        }

        public ArrayList getEventsByDate(DateTime date, int calendarId)
        {
            ArrayList qualEvents = new ArrayList();
            ArrayList events = CalendarDAL.getEventsByCalendarId(calendarId);
            System.Diagnostics.Trace.WriteLine("Date Day: " + date.Day);
            System.Diagnostics.Trace.WriteLine("Number of events: " + events.Count);
            foreach (CalendarEvent e in events)
            {
                DateTime start = e.getStart();
                DateTime end = e.getEnd();
                System.Diagnostics.Trace.WriteLine("Date Day: " + date.Day);
                System.Diagnostics.Trace.WriteLine("Start Day: " + start.Day);
                System.Diagnostics.Trace.WriteLine("End Day: " + end.Day);
                if (start.Day.Equals(date.Day) || end.Day.Equals(date.Day))
                {
                    qualEvents.Add(e);
                }
            }
            return qualEvents;
        }

        public int getCalendarIdByName(String calendarName)
        {
            return CalendarDAL.getCalendarIdByName(calendarName);
        }

        public ProjectManagerLibrary.Models.Calendar getCalendarByName(String calendarName)
        {
            return CalendarDAL.getCalendarByName(calendarName);
        }

        public bool addCalendarEvent(CalendarEvent e)
        {
            return CalendarDAL.addNewEvent(e);
        }

        public ArrayList getCalendarEvents(int calendarId)
        {
            return CalendarDAL.getEventsByCalendarId(calendarId);
        }

        public bool deleteEventsByName(String eventName)
        {
            return CalendarDAL.deleteEventsByName(eventName);
        }
    }
}
