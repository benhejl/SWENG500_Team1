using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerLibrary.Models
{
    class Calendar
    {
        public string Name {get; set;}
        public Project Project {get; set;}
        public CalendarEvent[] Events {get; set;}
        public User[] Users {get; set;}

        public Calendar()
        {
            Name = null;
            Project = null;
            Events = null;
            Users = null;
        }

        public Calendar(string Name, Project Project, CalendarEvent[] Events, User[] Users)
        {
            this.Name = Name;
            this.Project = Project;
            this.Events = Events;
            this.Users = Users;
        }
    }
}
