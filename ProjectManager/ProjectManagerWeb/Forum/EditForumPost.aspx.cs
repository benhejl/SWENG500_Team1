using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManagerLibrary.Models;
namespace ProjectManagerWeb.Forum
{
    public partial class EditForumPost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Controllers.ForumController forumController = new Controllers.ForumController();
                ForumModel forumModel = forumController.ReadForumPost(Convert.ToInt32(Request["ForumId"]));
                if (forumModel != null)
                {
                    txtBoxSubject.Text = forumModel.Subject;
                    txtBoxPost.Text = forumModel.ForumPost;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBoxSubject.Text) && !String.IsNullOrEmpty(txtBoxPost.Text))
            {
                ForumModel forumModel = new ForumModel();
                forumModel.ForumPost = txtBoxPost.Text;
                forumModel.ForumId = Convert.ToInt32(Request["ForumId"]);
                new Controllers.ForumController().EditForumPost(forumModel);
                Response.Redirect("~/Forum/ForumPostDetails.aspx?ForumId="+ Request["ForumId"]);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Forum/ForumPostDetails.aspx?ForumId=" + Request["ForumId"]);
        }
    }
}