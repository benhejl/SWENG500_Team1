using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManagerBLL.CalendarBLL;

namespace ProjectManagerWeb
{
    public partial class Calendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPanel.Visible = true;
            CreatePanel.Visible = false;
        }

        protected void CreateNewCalendarClick(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Pressed create new calendar button");

            CalendarBLL temp = new CalendarBLL();
            temp.createCalendar(CalendarName.Text);

            InitPanel.Visible = false;
            CreatePanel.Visible = true;
        }

        protected void DeleteCalendarClick(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Pressed delete calendar button");

            InitPanel.Visible = false;
            CreatePanel.Visible = true;
        }

        protected void EditCalendarInformationClick(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Pressed edit calendar information calendar button");

            InitPanel.Visible = false;
            CreatePanel.Visible = true;
        }

        protected void SaveNewCalendar(object sender, EventArgs e)
        {
            //do something with the calendar information... (name, users, and project)
        }

        protected void CancelCalendar(object sender, EventArgs e)
        {
            CreatePanel.Visible = false;
            InitPanel.Visible = true;
        }
    }
}