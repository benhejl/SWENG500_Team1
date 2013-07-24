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


            populateCalendarDropDown(CalendarDropDown);
            populateDeleteEventDropDown();

            if (!Page.IsPostBack)
            {
                InitPanel.Visible = true;
                CreatePanel.Visible = false;
                EditPanel.Visible = false;
                DeleteCalendarPanel.Visible = false;
                ViewCalendarPanel.Visible = false;
                DeleteEventPanel.Visible = false;
                AddEventPanel.Visible = false;
                populateViewCalendarDropDown();
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
            //populateProjectsDropDown();
        }

        /*private void populateProjectsDropDown()
        {
            CalendarBLL calendarBLL = new CalendarBLL();
            ArrayList projects = calendarBLL.getProjectNames();
            ProjectsDropDown.DataSource = projects;
            ProjectsDropDown.DataBind();
        }*/

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
            //populateNewProjectDropDown();
        }

        /*private void populateNewProjectDropDown()
        {
            CalendarBLL temp = new CalendarBLL();
            NewProjectDropDown.DataSource = temp.getProjectNames();
            NewProjectDropDown.DataBind();
        }*/

        protected void SaveNewCalendar(object sender, EventArgs e)
        {
            CalendarBLL calendarBLL = new CalendarBLL();
            ArrayList currentCalendars = null;

            String name = calendarName.Text;
            if (name == null || name.Length == 0)
            {
                TopMostMessageBox.Show("Name cannot be empty", "Error");
                return;
            }

            if ((currentCalendars = calendarBLL.getCalendars()) != null)
            {
                foreach (String n in currentCalendars)
                {
                    if (name.Equals(n))
                    {
                        TopMostMessageBox.Show("A calendar with that name already exists.", "Error");
                        return;
                    }
                }
            }

            /*String projectName = ProjectsDropDown.SelectedValue;

            if (projectName == null || projectName.Length == 0)
            {
                TopMostMessageBox.Show("Project cannot be empty", "Error");
                return;
            }*/

            calendarBLL.createCalendar(name);
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

            ArrayList currentCalendars = new ArrayList();
            if ((currentCalendars = calendarBLL.getCalendars()) != null)
            {
                foreach (String n in currentCalendars)
                {
                    if (newName.Equals(n))
                    {
                        TopMostMessageBox.Show("A calendar with that name already exists.", "Error");
                        return;
                    }
                }
            }

            if (newName.Length == 0) 
            {
                TopMostMessageBox.Show("Please enter a calendar name.", "Error");
                return;
            }


            /*String newProject = NewProjectDropDown.SelectedValue;

            if (calendarBLL.updateCalendarInfo(calendarToEdit, newName, newProject))
            {
                TopMostMessageBox.Show("Successfully updated " + newName, "Message", MessageBoxButtons.OKCancel);
            }*/

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
            //currentCalendar.setProjectId(calendar.getProjectId());

            System.Diagnostics.Trace.WriteLine("Current calendar set at " + currentCalendar.getCalendarId());

            InitPanel.Visible = false;
            ViewCalendarPanel.Visible = true;
        }

        private void populateViewCalendarDropDown()
        {
            CalendarBLL calendarBLL = new CalendarBLL();
            ArrayList calendarNames = calendarBLL.getCalendars();
            foreach (String name in calendarNames)
            {
                System.Diagnostics.Trace.WriteLine(name);
            }
            ViewDropDown.DataSource = calendarNames;
            ViewDropDown.DataBind();
        }

        protected void PMCalendar_SelectionChanged(object sender, EventArgs e)
        {
            CalendarBLL calendarBLL = new CalendarBLL();
            ArrayList events = calendarBLL.getEventsByDate(PMCalendar.SelectedDate, currentCalendar.getCalendarId());
            if (events.Count == 0)
            {
                TopMostMessageBox.Show("There are no events for this date.", PMCalendar.SelectedDate.ToString());
            }
            else
            {
                String eventsString = "";
                foreach (CalendarEvent calEvent in events)
                {
                    eventsString += calEvent.getName() + ": " + calEvent.getStart().ToString() + " - " +
                            calEvent.getEnd().ToString() + System.Environment.NewLine;
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
            populateTypeDropDown();
        }

        protected void populateTypeDropDown()
        {
            ArrayList typesList = new ArrayList();
            typesList.Add("Sprint Closeout");
            typesList.Add("Demo");
            typesList.Add("Out of Office");
            typesList.Add("Sprint Planning");
            typesList.Add("Sprint Retrospective");
            typesList.Add("Sprint Review");
            typesList.Add("Scrum");
            typesList.Add("Sprint");
            typesList.Add("Vacation");
            TypeDropDownList.DataSource = typesList;
            TypeDropDownList.DataBind();
        }

        protected void SaveNewEvent_Click(object sender, EventArgs e)
        {
            CalendarEvent newEvent = new CalendarEvent();

            if (NewEventNameTextBox.Text.Length == 0) 
            {
                TopMostMessageBox.Show("Please enter an event name.", "Error", MessageBoxButtons.RetryCancel);
                return;
            }
            newEvent.setName(NewEventNameTextBox.Text);

            if (StartYear.Text.Length == 0)
            {
                TopMostMessageBox.Show("Please enter a start year.", "Error", MessageBoxButtons.RetryCancel);
                return;
            }
            else if (StartMonth.Text.Length == 0)
            {
                TopMostMessageBox.Show("Please enter a start month.", "Error", MessageBoxButtons.RetryCancel);
                return;
            }
            else if (StartDay.Text.Length == 0)
            {
                TopMostMessageBox.Show("Please enter a start day.", "Error", MessageBoxButtons.RetryCancel);
                return;
            }
            else if (StartHour.Text.Length == 0)
            {
                TopMostMessageBox.Show("Please enter a start hour.", "Error", MessageBoxButtons.RetryCancel);
                return;
            }
            else if (StartMinute.Text.Length == 0)
            {
                TopMostMessageBox.Show("Please enter a start minute.", "Error", MessageBoxButtons.RetryCancel);
                return;
            }

            if (EndYear.Text.Length == 0)
            {
                TopMostMessageBox.Show("Please enter a end year.", "Error", MessageBoxButtons.RetryCancel);
                return;
            }
            else if (EndMonth.Text.Length == 0)
            {
                TopMostMessageBox.Show("Please enter a end month.", "Error", MessageBoxButtons.RetryCancel);
                return;
            }
            else if (EndDay.Text.Length == 0)
            {
                TopMostMessageBox.Show("Please enter a end day.", "Error", MessageBoxButtons.RetryCancel);
                return;
            }
            else if (EndHour.Text.Length == 0)
            {
                TopMostMessageBox.Show("Please enter a end hour.", "Error", MessageBoxButtons.RetryCancel);
                return;
            }
            else if (EndMinute.Text.Length == 0)
            {
                TopMostMessageBox.Show("Please enter a end minute.", "Error", MessageBoxButtons.RetryCancel);
                return;
            }

            int startYear = Convert.ToInt32(StartYear.Text);
            int startMonth = Convert.ToInt32(StartMonth.Text);
            int startDay = Convert.ToInt32(StartDay.Text);
            int startHour = Convert.ToInt32(StartHour.Text);
            int startMinute = Convert.ToInt32(StartMinute.Text);
            int endYear = Convert.ToInt32(EndYear.Text);
            int endMonth = Convert.ToInt32(EndMonth.Text);
            int endDay = Convert.ToInt32(EndDay.Text);
            int endHour = Convert.ToInt32(EndHour.Text);
            int endMinute = Convert.ToInt32(EndMinute.Text);

            DateTime startTime = new DateTime(startYear, startMonth, startDay, startHour, startMinute, 0);
            DateTime endTime = new DateTime(endYear, endMonth, endDay, endHour, endMinute, 0);

            System.Diagnostics.Trace.WriteLine(startTime.ToString());
            System.Diagnostics.Trace.WriteLine(endTime.ToString());

            newEvent.setStart(startTime);
            newEvent.setEnd(endTime);
            newEvent.setCalendarId(currentCalendar.getCalendarId());
            newEvent.setType(TypeDropDownList.SelectedValue);

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

        protected void DeleteEventPageClick(object sender, EventArgs e)
        {
            CalendarBLL calendarBLL = new CalendarBLL();
            String calendarToDeleteEvents = DeleteEventDropDown.SelectedValue;
            System.Diagnostics.Trace.WriteLine(calendarToDeleteEvents);
            ProjectManagerLibrary.Models.Calendar calendar = calendarBLL.getCalendarByName(calendarToDeleteEvents);
            currentCalendar.setCalendarName(calendarToDeleteEvents);
            currentCalendar.setCalendarId(calendar.getCalendarId());
            //currentCalendar.setProjectId(calendar.getProjectId());

            populateDeleteEventCheckBox();

            DeleteEventPanel.Visible = true;
            InitPanel.Visible = false;
        }

        protected void DeleteEvent(object sender, EventArgs e)
        {
            for (int i = 0; i < DeleteEventCheckBox.Items.Count; i ++) {
                if (DeleteEventCheckBox.Items[i].Selected) {
                    String eventName = DeleteEventCheckBox.Items[i].Text;
                    CalendarBLL calendarBLL = new CalendarBLL();
                    System.Diagnostics.Trace.WriteLine(eventName);
                    if (calendarBLL.deleteEventsByName(eventName))
                    {
                        TopMostMessageBox.Show(eventName + " successfully deleted.", "message");
                    }
                    else
                    {
                        TopMostMessageBox.Show("Could not delete " + eventName + ".", "message");
                    }
                }
            }

            DeleteEventPanel.Visible = false;
            InitPanel.Visible = true;
        }

        protected void populateDeleteEventDropDown()
        {
            CalendarBLL calendarBLL = new CalendarBLL();
            ArrayList calendarNames = calendarBLL.getCalendars();
            DeleteEventDropDown.DataSource = calendarNames;
            DeleteEventDropDown.DataBind();
        }

        protected void populateDeleteEventCheckBox()
        {
            CalendarBLL calendarBLL = new CalendarBLL();
            ArrayList events = calendarBLL.getCalendarEvents(currentCalendar.getCalendarId());

            ArrayList names = new ArrayList();
            foreach (CalendarEvent e in events)
            {
                names.Add(e.getName());
            }

            DeleteEventCheckBox.DataSource = names;
            DeleteEventCheckBox.DataBind();
        }

        protected void CancelDeleteEventClick(object sender, EventArgs e)
        {
            InitPanel.Visible = true;
            DeleteEventPanel.Visible = false;
        }
    }
}