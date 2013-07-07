using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagerWeb.Controllers;
using ProjectManagerLibrary.Models;

namespace ProjectManagerTest
{
    [TestClass]
    public class ForumTest
    {
        private ForumController forumController = new ForumController();
        private ForumModel forumModel = new ForumModel();

        [TestMethod]
        public void CreateNewForumTest()
        {
            forumModel.Subject = "Create New Forum Test";
            forumModel.ForumPost = "I am testing a new create forum";
            forumModel.UserId = 1;
            Assert.IsTrue(forumController.CreateNewForum(forumModel));
        }
        [TestMethod]
        public void DisplayForumPostsTest()
        {
            Assert.IsTrue(forumController.DisplayForumPosts().Count > 0);
        }
        [TestMethod]
        public void ReadForumPostTest()
        {
            Assert.IsTrue(forumController.ReadForumPost(1) != null);
        }
        [TestMethod]
        public void ReplyForumPostTest()
        {
            ReplyModel replyModel = new ReplyModel();
            replyModel.ForumId = 1;
            replyModel.UserId = 1;
            replyModel.ReplyPost = "I am testing the reply post to a forum";
            Assert.IsTrue(forumController.ReplyForumPost(replyModel) != null);
        }
        [TestMethod]
        public void EditForumPostTest()
        {
            forumModel.ForumId = 1;
            forumModel.ForumPost = "Update My Forum Post";
            Assert.IsTrue(forumController.EditForumPost(forumModel));
        }
        [TestMethod]
        public void DeleteForumPostTest()
        {
            forumModel.ForumId = 1;
            Assert.IsTrue(forumController.DeleteForumPost(forumModel));
        }
    }
}
