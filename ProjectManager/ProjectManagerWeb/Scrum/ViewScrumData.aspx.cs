﻿using System;
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
    public partial class ViewScrumData : System.Web.UI.Page
    {
        public ArrayList ScrumList;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScrumController scrumController = new ScrumController();
            ScrumModel scrumModel = scrumController.ViewScrumData(1);

            if (scrumModel.ScrumList != null)
            {
                ScrumList = scrumModel.ScrumList;
            }
        }
    }
}