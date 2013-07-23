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
    public partial class SearchScrumByDate : System.Web.UI.Page
    {
        List<String> thirtyOneList = new List<String>{ "1", "3", "5", "7", "8", "10", "12" };
        List<String> thirtyList = new List<String> { "4", "6", "9", "11" };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListItem listItem = new ListItem();
                listItem.Text = "";
                listItem.Value = "";
                ddlMonth.Items.Add(listItem);

                listItem = new ListItem();
                listItem.Text = "January";
                listItem.Value = "1";
                ddlMonth.Items.Add(listItem);

                listItem = new ListItem();
                listItem.Text = "February";
                listItem.Value = "2";
                ddlMonth.Items.Add(listItem);

                listItem = new ListItem();
                listItem.Text = "March";
                listItem.Value = "3";
                ddlMonth.Items.Add(listItem);

                listItem = new ListItem();
                listItem.Text = "April";
                listItem.Value = "4";
                ddlMonth.Items.Add(listItem);

                listItem = new ListItem();
                listItem.Text = "May";
                listItem.Value = "5";
                ddlMonth.Items.Add(listItem);

                listItem = new ListItem();
                listItem.Text = "June";
                listItem.Value = "6";
                ddlMonth.Items.Add(listItem);

                listItem = new ListItem();
                listItem.Text = "July";
                listItem.Value = "7";
                ddlMonth.Items.Add(listItem);

                listItem = new ListItem();
                listItem.Text = "August";
                listItem.Value = "8";
                ddlMonth.Items.Add(listItem);

                listItem = new ListItem();
                listItem.Text = "September";
                listItem.Value = "9";
                ddlMonth.Items.Add(listItem);

                listItem = new ListItem();
                listItem.Text = "October";
                listItem.Value = "10";
                ddlMonth.Items.Add(listItem);

                listItem = new ListItem();
                listItem.Text = "November";
                listItem.Value = "11";
                ddlMonth.Items.Add(listItem);

                listItem = new ListItem();
                listItem.Text = "December";
                listItem.Value = "12";
                ddlMonth.Items.Add(listItem);
            }

        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMonth.SelectedIndex > 0)
            {
                ddlDay.Items.Clear();
                if (thirtyOneList.Contains(ddlMonth.SelectedValue))
                {
                    for (int x = 1; x <= 31; x++)
                    {
                        ddlDay.Items.Add(x.ToString());
                    }
                }
                else if (thirtyList.Contains(ddlMonth.SelectedValue))
                {
                    for (int x = 1; x <= 30; x++)
                    {
                        ddlDay.Items.Add(x.ToString());
                    }
                }
                else
                {
                    for (int x = 1; x <= 28; x++)
                    {
                        ddlDay.Items.Add(x.ToString());
                    }
                }
            }
        }
        public ArrayList ScrumList;
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(ddlMonth.SelectedIndex > 0 && ddlDay.SelectedIndex > 0)
            {
                string date = ddlYear.SelectedValue + "-" + ddlMonth.SelectedValue + "-" + ddlDay.SelectedValue;
                string nextDay = ddlYear.SelectedValue + "-" + ddlMonth.SelectedValue + "-" + (Convert.ToInt32(ddlDay.SelectedValue) + 1).ToString();
                ScrumController scrumController = new ScrumController();
                ScrumModel scrumModel = scrumController.ScrumByDate(date, nextDay);
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
        }
    }
}