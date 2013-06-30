using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManagerLibrary.Models;
namespace ProjectManagerWeb.Forum
{
    public partial class ForumPostDetails : System.Web.UI.Page
    {
        public ForumModel ForumModel;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["ForumId"] != null)
            {
                Controllers.ForumController forumController = new Controllers.ForumController();
                ForumModel = forumController.ReadForumPost(Convert.ToInt32(Request["ForumId"]));
            }
            else
            {
                Response.Redirect(Request.UrlReferrer.AbsolutePath);
            }
            
        }

        protected void btnReply_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBoxReply.Text))
            {
                Controllers.ForumController forumController = new Controllers.ForumController();
                ReplyModel replyModel = new ReplyModel();
                replyModel.UserId = 1;
                replyModel.ForumId = ForumModel.ForumId;
                replyModel.ReplyPost = txtBoxReply.Text;
                ForumModel = forumController.ReplyForumPost(replyModel);
                txtBoxReply.Text = "";
            }
        }
    }
}