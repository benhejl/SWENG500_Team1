using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using ProjectManagerLibrary;
using ProjectManagerLibrary.Models;

namespace ProjectManagerDAL.Forum
{
    public class ForumDAL
    {
        public bool CreateNewForum(ForumModel forumModel)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Constants.DATABASE.CONNECTION_STRING))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO ForumPost VALUES (@ForumSubject, @ForumPost, @UserId, @DateEntered, @DateModified, @Active)", sqlConnection))
                    {

                        sqlCommand.Parameters.Add(new SqlParameter("ForumSubject", forumModel.Subject));
                        sqlCommand.Parameters.Add(new SqlParameter("ForumPost", forumModel.ForumPost));
                        sqlCommand.Parameters.Add(new SqlParameter("UserId", forumModel.UserId));
                        sqlCommand.Parameters.Add(new SqlParameter("DateEntered", DateTime.Now));
                        sqlCommand.Parameters.Add(new SqlParameter("DateModified", DateTime.Now));
                        sqlCommand.Parameters.Add(new SqlParameter("Active", 1));
                        sqlCommand.ExecuteNonQuery();

                    }
                    sqlConnection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public ArrayList DisplayForumPosts()
        {
            try
            {
                ArrayList forumList = new ArrayList();
                using (SqlConnection sqlConnection = new SqlConnection(Constants.DATABASE.CONNECTION_STRING))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ForumPost INNER JOIN Users ON Users.UserID = ForumPost.UserId WHERE Active=1 Order By DateModified DESC", sqlConnection))
                    {
                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            if (sqlDataReader.HasRows)
                            {

                                while (sqlDataReader.Read())
                                {
                                    ForumModel forumModel = new ForumModel();
                                    forumModel.ForumId = Convert.ToInt32(sqlDataReader["ForumId"]);
                                    forumModel.Subject = Convert.ToString(sqlDataReader["ForumSubject"]);
                                    forumModel.UserId = Convert.ToInt32(sqlDataReader["UserId"]);
                                    forumModel.DateEntered = Convert.ToDateTime(sqlDataReader["DateEntered"]);
                                    forumModel.DateModified = Convert.ToDateTime(sqlDataReader["DateModified"]);
                                    forumModel.FirstName = Convert.ToString(sqlDataReader["FirstName"]);
                                    forumModel.LastName = Convert.ToString(sqlDataReader["LastName"]);
                                    forumList.Add(forumModel);
                                }
                            }
                            sqlDataReader.Close();
                        }
                    }
                    sqlConnection.Close();

                }
                return forumList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ForumModel ReadForumPost(int forumId)
        {
            try
            {
                ForumModel forumModel = new ForumModel();
                using (SqlConnection sqlConnection = new SqlConnection(Constants.DATABASE.CONNECTION_STRING))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ForumPost " +
                        " INNER JOIN Users ON ForumPost.UserId = Users.UserID" + 
                        " WHERE ForumPost.ForumId=" + forumId + " Order By DateModified DESC", sqlConnection))
                    {
                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            if (sqlDataReader.HasRows)
                            {
                                forumModel.ReplyList = new ArrayList();
                                sqlDataReader.Read();
                                forumModel.ForumId = Convert.ToInt32(sqlDataReader["ForumId"]);
                                forumModel.Subject = Convert.ToString(sqlDataReader["ForumSubject"]);
                                forumModel.ForumPost = Convert.ToString(sqlDataReader["ForumPost"]);
                                forumModel.UserId = Convert.ToInt32(sqlDataReader["UserId"]);
                                forumModel.DateEntered = Convert.ToDateTime(sqlDataReader["DateEntered"]);
                                forumModel.DateModified = Convert.ToDateTime(sqlDataReader["DateModified"]);
                                forumModel.FirstName = Convert.ToString(sqlDataReader["FirstName"]);
                                forumModel.LastName = Convert.ToString(sqlDataReader["LastName"]); 
                                
                            }
                            sqlDataReader.Close();
                        }
                       
                        
                    }
                    using (SqlCommand sqlCommand = new SqlCommand("Select * from ReplyForumPost " +
                            " INNER JOIN Users ON ReplyForumPost.ReplyUserId = Users.UserID" +
                            " WHERE ReplyForumPost.ForumId=" + forumId + " Order By ReplyDateModified ASC", sqlConnection))
                    {
                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            if (sqlDataReader.HasRows)
                            {
                                while (sqlDataReader.Read())
                                {
                                    ReplyModel replyModel = new ReplyModel();
                                    replyModel.ReplyPost = Convert.ToString(sqlDataReader["ReplyPost"]);
                                    replyModel.UserId = Convert.ToInt32(sqlDataReader["ReplyUserId"]);
                                    replyModel.DateEntered = Convert.ToDateTime(sqlDataReader["ReplyDateEntered"]);
                                    replyModel.DateModified = Convert.ToDateTime(sqlDataReader["ReplyDateModified"]);
                                    replyModel.FirstName = Convert.ToString(sqlDataReader["FirstName"]);
                                    replyModel.LastName = Convert.ToString(sqlDataReader["LastName"]); 
                                    forumModel.ReplyList.Add(replyModel);
                                }
                            }
                            sqlDataReader.Close();
                        }
                    }
                    sqlConnection.Close();
                   
                }
                return forumModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ForumModel ReplyForumPost(ReplyModel replyModel)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Constants.DATABASE.CONNECTION_STRING))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO ReplyForumPost VALUES (@ForumId, @ReplyPost, @ReplyUserId, @ReplyDateEntered, @ReplyDateModified, @Active)", sqlConnection))
                    {

                        sqlCommand.Parameters.Add(new SqlParameter("ForumId", replyModel.ForumId));
                        sqlCommand.Parameters.Add(new SqlParameter("ReplyPost", replyModel.ReplyPost));
                        sqlCommand.Parameters.Add(new SqlParameter("ReplyUserId", replyModel.UserId));
                        sqlCommand.Parameters.Add(new SqlParameter("ReplyDateEntered", DateTime.Now));
                        sqlCommand.Parameters.Add(new SqlParameter("ReplyDateModified", DateTime.Now));
                        sqlCommand.Parameters.Add(new SqlParameter("Active", 1));
                        sqlCommand.ExecuteNonQuery();

                    }
                    sqlConnection.Close();
                }
                return ReadForumPost(replyModel.ForumId);
            }
            catch
            {
                return null;
            }
        }
    }
}
