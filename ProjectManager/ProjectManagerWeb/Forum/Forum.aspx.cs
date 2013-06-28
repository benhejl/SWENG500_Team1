using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagerWeb.Forum
{
    public partial class Forum : System.Web.UI.Page
    {
        public ArrayList ForumList;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controllers.ForumController forumController = new Controllers.ForumController();
            ForumList = forumController.DisplayForumPosts();
        }
    }
}