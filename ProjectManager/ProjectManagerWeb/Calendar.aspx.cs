using System;
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
                    populateDropDown(CalendarDropDown);
                }
        }

        protected void CreateNewCalendarClick(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Pressed create new calendar button");

            InitPanel.Visible = false;
            populateUsersList();
            populateProjectsDropDown();
            CreatePanel.Visible = true;
        }

        private void populateProjectsDropDown()
        {
            /**CalendarBLL calendarBLL = new CalendarBLL();
            List<KeyValuePair<string, int>> projects = calendarBLL.getProjects();

            String[] projectNames = new String[projects.Count];
            int i = 0;
            foreach (KeyValuePair<string, int> pair in projects)
            {
                projectNames[i] = pair.Key;
                i++;
            }**/

            String[] projectNames = new String[3];
            projectNames[0] = "test1";
            projectNames[1] = "test2";
            projectNames[2] = "test3";
            ProjectsDropDown.DataSource = projectNames;
            ProjectsDropDown.DataBind();
        }

        private void populateUsersList()
        {
            /**CalendarBLL calendarBLL = new CalendarBLL();
            List<KeyValuePair<string, int>> users = calendarBLL.getUsers();

            String[] usernames = new String[users.Count];
            int i = 0;
            foreach (KeyValuePair<string, int> pair in users)
            {
                usernames[i] = pair.Key;
                i++;
            }**/

            String[] usernames = new String[3];
            usernames[0] = "user1";
            usernames[1] = "user2";
            usernames[2] = "user3";
            RegisteredUsers.DataSource = usernames;
            RegisteredUsers.DataBind();
        }

        protected void DeleteCalendarClick(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Pressed delete calendar button");

            InitPanel.Visible = false;
            populateDropDown(DeleteDropDown);
            DeleteCalendarPanel.Visible = true;
        }

        protected void EditCalendarInformationClick(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Pressed edit calendar information calendar button");

            InitPanel.Visible = false;
            populateDropDown(CalendarDropDown);
            EditPanel.Visible = true;
        }

        protected void SaveNewCalendar(object sender, EventArgs e)
        {
            CalendarBLL temp = new CalendarBLL();
            temp.createCalendar(calendarName.Text);
        }

        protected void CancelCalendar(object sender, EventArgs e)
        {
            CreatePanel.Visible = false;
            InitPanel.Visible = true;
        }

        private void populateDropDown(DropDownList temp)
        {
            CalendarBLL calendarBLL = new CalendarBLL();
            DataRowCollection rows = calendarBLL.getCalendars();

            String[] calendarNames = new String[rows.Count];
            int i = 0;
            foreach (DataRow row in rows)
            {
                calendarNames[i] = (string)row["Name"];
                i ++;
            }

            temp.DataSource = calendarNames;
            temp.DataBind();
        }

        protected void SaveEdit_Click(object sender, EventArgs e)
        {
            String calendarToEdit = CalendarDropDown.SelectedValue;
            String newName = EditNameTextBox.Text;
            CalendarBLL calendarBLL = new CalendarBLL();
            if (calendarBLL.updateCalendarInfo(calendarToEdit, newName))
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
    }
}