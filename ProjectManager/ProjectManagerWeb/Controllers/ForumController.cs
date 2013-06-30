using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManagerLibrary.Models;
using ProjectManagerBLL.Forum;

namespace ProjectManagerWeb.Controllers
{
    public class ForumController
    {
        public bool CreateNewForum(ForumModel forumModel)
        {
            return new ForumBLL().CreateNewForum(forumModel);
        }
        public ArrayList DisplayForumPosts()
        {
            return new ForumBLL().DisplayForumPosts();
        }
        public ForumModel ReadForumPost(int forumId)
        {
            return new ForumBLL().ReadForumPost(forumId);
        }
        public ForumModel ReplyForumPost(ReplyModel replyModel)
        {
            return new ForumBLL().ReplyForumPost(replyModel);
        }
    }
}