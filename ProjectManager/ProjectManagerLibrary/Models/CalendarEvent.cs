using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerLibrary.Models
{
    class CalendarEvent
    {
        public enum EventType
        {
            MileStone,
            Demo,
            Vacation,
            Task,
            Sprint,
            Custom
        }

        public string Name {get; set;}
        public DateRange StartEndDate {get; set;}
        public EventType Type {get; set;}

        public CalendarEvent()
        {
            Name = null;
            StartEndDate = null;
        }

        public CalendarEvent(string Name, DateRange StartEndDate, EventType Type)
        {
            this.Type = Type;
            this.Name = Name;
            this.StartEndDate = StartEndDate;
        }
    }
}
