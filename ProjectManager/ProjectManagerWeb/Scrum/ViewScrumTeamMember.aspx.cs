using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManagerLibrary.Models;
using ProjectManagerWeb.Controllers;

namespace ProjectManagerWeb.Scrum
{
    public partial class ViewScrumTeamMember : System.Web.UI.Page
    {
        public ArrayList ScrumList;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserController userController = new UserController();
                List<KeyValuePair<string, int>> userList = userController.GetAllUserNames();
                foreach (var user in userList)
                {
                    ListItem listItem = new ListItem();
                    listItem.Text = user.Key;
                    listItem.Value = user.Value.ToString();
                    ddlUserList.Items.Add(listItem);
                }
            }
        }

        protected void ddlUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUserList.SelectedIndex != 0)
            {
                ScrumController scrumController = new ScrumController();
                ScrumModel scrumModel = scrumController.ViewScrumData(Convert.ToInt32(ddlUserList.SelectedValue));
                if (scrumModel.ScrumList != null && scrumModel.ScrumList.Count > 0)
                {
                    ScrumList = scrumModel.ScrumList;
                    divData.Visible = true;
                    divNoData.Visible = false;
                }
                else
                {
                    divData.Visible = false;
                    divNoData.Visible = true;
                }

            }
            else
            {
                divData.Visible = false;
                divNoData.Visible = false;
            }
        }
    }
}