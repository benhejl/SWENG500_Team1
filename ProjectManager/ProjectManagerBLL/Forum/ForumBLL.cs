using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagerLibrary.Models;
using ProjectManagerDAL.Forum;

namespace ProjectManagerBLL.Forum
{
    public class ForumBLL
    {
        public bool CreateNewForum(ForumModel forumModel)
        {
            return new ForumDAL().CreateNewForum(forumModel);
        }
        public ArrayList DisplayForumPosts()
        {
            return new ForumDAL().DisplayForumPosts();
        }
        public ForumModel ReadForumPost(int forumId)
        {
            return new ForumDAL().ReadForumPost(forumId);
        }
        public ForumModel ReplyForumPost(ReplyModel replyModel)
        {
            return new ForumDAL().ReplyForumPost(replyModel);
        }
    }
}
