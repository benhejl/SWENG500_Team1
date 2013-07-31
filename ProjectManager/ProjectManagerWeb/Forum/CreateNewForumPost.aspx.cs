using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManagerWeb.Controllers;
using ProjectManagerLibrary.Models;

namespace ProjectManagerWeb.Forum
{
    public partial class CreateNewForumPost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBoxSubject.Text) && !String.IsNullOrEmpty(txtBoxPost.Text))
            {
                ForumModel forumModel = new ForumModel();
                forumModel.Subject = txtBoxSubject.Text;
                forumModel.ForumPost = txtBoxPost.Text;
                User user = (User)Session["User"];
                forumModel.UserId = user.UserId;
                new ForumController().CreateNewForum(forumModel);
                Response.Redirect("~/Forum/Forum.aspx");
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Forum/Forum.aspx");
        }
    }
}