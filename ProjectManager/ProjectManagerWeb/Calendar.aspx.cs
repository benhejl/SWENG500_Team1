using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Windows.Forms;
using ProjectManagerBLL.CalendarBLL;
using ProjectManagerLibrary.Models;

namespace ProjectManagerWeb
{
    public partial class Calendar : System.Web.UI.Page
    {
        private static CurrentCalendar currentCalendar = new CurrentCalendar();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            System.Diagnostics.Trace.WriteLine("Page_load");

            populateViewCalendarDropDown();

            if (!Page.IsPostBack)
            {
                InitPanel.Visible = true;
                CreatePanel.Visible = false;
                EditPanel.Visible = false;
                DeleteCalendarPanel.Visible = false;
                ViewCalendarPanel.Visible = false;
                populateCalendarDropDown(CalendarDropDown);
            }
            else
            {
                System.Diagnostics.Trace.WriteLine("Post back");
            }
        }

        protected void CreateNewCalendarClick(object sender, EventArgs e)
        {
            InitPanel.Visible = false;
            CreatePanel.Visible = true;
            populateUsersList();
            populateProjectsDropDown();
        }

        private void populateProjectsDropDown()
        {
            CalendarBLL calendarBLL = new CalendarBLL();
            ArrayList projects = calendarBLL.getProjectNames();
            ProjectsDropDown.DataSource = projects;
            ProjectsDropDown.DataBind();
        }

        private void populateUsersList()
        {
            CalendarBLL calendarBLL = new CalendarBLL();
            ArrayList users = calendarBLL.getUsers();
            RegisteredUsersList.DataSource = users;
            RegisteredUsersList.DataBind();
        }

        protected void DeleteCalendarClick(object sender, EventArgs e)
        {
            InitPanel.Visible = false;
            DeleteCalendarPanel.Visible = true;
            populateCalendarDropDown(DeleteDropDown);
        }

        protected void EditCalendarInformationClick(object sender, EventArgs e)
        {
            InitPanel.Visible = false;
            populateCalendarDropDown(CalendarDropDown);
            EditPanel.Visible = true;
            populateNewRegisteredUsersDropDown();
            populateNewProjectDropDown();
        }

        private void populateNewRegisteredUsersDropDown()
        {
            CalendarBLL temp = new CalendarBLL();
            NewRegisteredUsersDropDown.DataSource=temp.getUsers();
            NewRegisteredUsersDropDown.DataBind();
        }

        private void populateNewProjectDropDown()
        {
            CalendarBLL temp = new CalendarBLL();
            NewProjectDropDown.DataSource = temp.getProjectNames();
            NewProjectDropDown.DataBind();
        }

        protected void SaveNewCalendar(object sender, EventArgs e)
        {
            CalendarBLL temp = new CalendarBLL();

            String name = calendarName.Text;

            String usernames = "";
            foreach (ListItem item in RegisteredUsersList.Items)
            {
                if (item.Selected)
                {
                    if (usernames.Length != 0)
                    {
                        usernames += ", ";
                    }

                    usernames += item.Text;
                }
            }

            String projectName = ProjectsDropDown.SelectedValue;
         
            temp.createCalendar(name, projectName, usernames);
            InitPanel.Visible = true;
            CreatePanel.Visible = false;
        }

        private void populateCalendarDropDown(DropDownList temp)
        {
            CalendarBLL calendarBLL = new CalendarBLL();
            ArrayList calendarNames = calendarBLL.getCalendars();
            temp.DataSource = calendarNames;
            temp.DataBind();
        }

        protected void SaveEdit_Click(object sender, EventArgs e)
        {
            CalendarBLL calendarBLL = new CalendarBLL();

            String calendarToEdit = CalendarDropDown.SelectedValue;
            String newName = EditNameTextBox.Text;

            String newProject = NewProjectDropDown.SelectedValue;

            String newUsers = "";
            foreach (ListItem item in NewRegisteredUsersDropDown.Items)
            {
                if (item.Selected)
                {
                    if (newUsers.Length != 0)
                    {
                        newUsers += ", ";
                    }
                    newUsers += item.Text;
                }
            }

            if (calendarBLL.updateCalendarInfo(calendarToEdit, newName, newProject, newUsers))
            {
                TopMostMessageBox.Show("Successfully updated " + newName, "Message", MessageBoxButtons.OKCancel);
            }

            InitPanel.Visible = true;
            EditPanel.Visible = false;
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            String calendarToDelete = DeleteDropDown.SelectedValue;
            CalendarBLL calendarBLL = new CalendarBLL();
            if (TopMostMessageBox.Show("Are you sure you want to delete " + calendarToDelete + "?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                calendarBLL.deleteCalendar(calendarToDelete);
            }

            DeleteCalendarPanel.Visible = false;
            InitPanel.Visible = true;
        }

        protected void ViewCalendarClick(object sender, EventArgs e)
        {
            CalendarBLL calendarBLL = new CalendarBLL();
            String calendarToView = ViewDropDown.SelectedValue;
            ProjectManagerLibrary.Models.Calendar calendar = calendarBLL.getCalendarByName(calendarToView);
            currentCalendar.setCalendarName(calendarToView);
            currentCalendar.setCalendarId(calendar.getCalendarId());
            currentCalendar.setProjectName(calendar.getProjectName());
            currentCalendar.setUsers(calendar.getUsers());
            
            InitPanel.Visible = false;
            ViewCalendarPanel.Visible = true;
        }

        private void populateViewCalendarDropDown()
        {
            CalendarBLL calendarBLL = new CalendarBLL();
            ArrayList calendarNames = calendarBLL.getCalendars();
            ViewDropDown.DataSource = calendarNames;
            ViewDropDown.DataBind();
        }

        protected void PMCalendar_SelectionChanged(object sender, EventArgs e)
        {
            CalendarBLL calendarBLL = new CalendarBLL();
            ArrayList events = calendarBLL.getEventsByDate(PMCalendar.SelectedDate);
            if (events.Count == 0)
            {
                TopMostMessageBox.Show("There are no events for this date.", PMCalendar.SelectedDate.ToString());
            }
            else
            {
                String eventsString = "";
                foreach (CalendarEvent calEvent in events)
                {
                    eventsString += calEvent.getName() + ": " + calEvent.getStart().Date + " - " +
                            calEvent.getEnd().Date + System.Environment.NewLine;
                }
                TopMostMessageBox.Show(eventsString, PMCalendar.SelectedDate.ToString());
            }
        }

        protected void CancelNewCalendar_Click(object sender, EventArgs e)
        {
            InitPanel.Visible = true;
            CreatePanel.Visible = false;
        }

        protected void CancelDelete_Click(object sender, EventArgs e)
        {
            InitPanel.Visible = true;
            DeleteCalendarPanel.Visible = false;
        }

        protected void CancelEdit_Click(object sender, EventArgs e)
        {
            InitPanel.Visible = true;
            EditPanel.Visible = false;
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            InitPanel.Visible = true;
            ViewCalendarPanel.Visible = false;
        }

        protected void AddEvent_Click(object sender, EventArgs e)
        {
            ViewCalendarPanel.Visible = false;
            AddEventPanel.Visible = true;
        }

        protected void SaveNewEvent_Click(object sender, EventArgs e)
        {
            CalendarEvent newEvent = new CalendarEvent();
            newEvent.setName(NewEventNameTextBox.Text);
            newEvent.setStart(Convert.ToDateTime(NewEventStartTextBox.Text));
            newEvent.setEnd(Convert.ToDateTime(NewEventEndTextBox.Text));
            newEvent.setCalendarId(currentCalendar.getCalendarId());

            CalendarBLL calendarBLL = new CalendarBLL();
            calendarBLL.addCalendarEvent(newEvent);

            ViewCalendarPanel.Visible = true;
            AddEventPanel.Visible = false;
        }

        protected void CancelNewEvent_Click(object sender, EventArgs e)
        {

            ViewCalendarPanel.Visible = true;
            AddEventPanel.Visible = false;
        }
    }

}