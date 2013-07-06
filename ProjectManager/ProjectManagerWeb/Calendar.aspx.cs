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

namespace ProjectManagerWeb
{
    public partial class Calendar : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
                InitPanel.Visible = true;
                CreatePanel.Visible = false;
                EditPanel.Visible = false;
                DeleteCalendarPanel.Visible = false;

                System.Diagnostics.Trace.WriteLine("Page_Load");

                if (!Page.IsPostBack)
                {
                    populateCalendarDropDown(CalendarDropDown);
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
        }

        protected void CancelCalendar(object sender, EventArgs e)
        {
            CreatePanel.Visible = false;
            InitPanel.Visible = true;
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
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            String calendarToDelete = DeleteDropDown.SelectedValue;
            CalendarBLL calendarBLL = new CalendarBLL();
            if (TopMostMessageBox.Show("Are you sure you want to delete " + calendarToDelete + "?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                calendarBLL.deleteCalendar(calendarToDelete);
                return;
            }
        }

        protected void ViewCalendarClick(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.Write("Pressed View calendar");

        }
    }
}