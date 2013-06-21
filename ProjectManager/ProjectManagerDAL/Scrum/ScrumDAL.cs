using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using ProjectManagerLibrary;
using ProjectManagerLibrary.Models;
namespace ProjectManagerDAL.Scrum
{
    public class ScrumDAL
    {

        public ScrumModel GetScrumQuestions()
        {
            ScrumModel scrumModel = new ScrumModel();
            using (SqlConnection sqlConnection = new SqlConnection(Constants.DATABASE.CONNECTION_STRING))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ScrumQuestions WHERE Active=" + 1, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            scrumModel.QuestionList = new System.Collections.ArrayList();
                            while (sqlDataReader.Read())
                            {
                                Questions question = new Questions();
                                question.QuestionId = Convert.ToInt32(sqlDataReader["ScrumQuestionId"]);
                                question.Question = Convert.ToString(sqlDataReader["ScrumQuestion"]);
                                scrumModel.QuestionList.Add(question);
                            }
                        }
                        sqlDataReader.Close();
                    }
                }
                sqlConnection.Close();
            }
            return scrumModel;
        }

        public bool InputNewScrum(ScrumModel scrumModel)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Constants.DATABASE.CONNECTION_STRING))
                {
                    sqlConnection.Open();
                    foreach (Answers answer in scrumModel.AnswerList)
                    {
                        using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO ScrumAnswers VALUES (@Answer, @QuestionId, @UserId, @DateEntered, @DateModified)", sqlConnection))
                        {

                            sqlCommand.Parameters.Add(new SqlParameter("Answer", answer.Answer));
                            sqlCommand.Parameters.Add(new SqlParameter("QuestionId", answer.QuestionId));
                            sqlCommand.Parameters.Add(new SqlParameter("UserId", answer.UserId));
                            sqlCommand.Parameters.Add(new SqlParameter("DateEntered", DateTime.Now));
                            sqlCommand.Parameters.Add(new SqlParameter("DateModified", DateTime.Now));
                            sqlCommand.ExecuteNonQuery();

                        }
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
        public ScrumModel ViewScrumData()
        {
            ScrumModel scrumModel = new ScrumModel();
            using (SqlConnection sqlConnection = new SqlConnection(Constants.DATABASE.CONNECTION_STRING))
            {
                sqlConnection.Open();
                string sqlString = "SELECT Users.FirstName, Users.LastName, dbo.ScrumQuestions.ScrumQuestion, ScrumAnswers. * " +
                                   "FROM ScrumAnswers " +
                                   "INNER JOIN dbo.ScrumQuestions ON dbo.ScrumQuestions.ScrumQuestionId = dbo.ScrumAnswers.QuestionId " +
                                   "INNER JOIN dbo.Users ON dbo.Users.UserID = dbo.ScrumAnswers.UserId " +
                                   "ORDER BY ScrumAnswers.DateEntered, Users.LastName, ScrumAnswers.QuestionId";
                using (SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            scrumModel.ScrumList = new System.Collections.ArrayList();
                            while (sqlDataReader.Read())
                            {
                                ScrumData scrumData = new ScrumData();
                                scrumData.FirstName = Convert.ToString(sqlDataReader["FirstName"]);
                                scrumData.LastName = Convert.ToString(sqlDataReader["LastName"]);
                                scrumData.Question = Convert.ToString(sqlDataReader["ScrumQuestion"]);
                                scrumData.AnswerId = Convert.ToInt32(sqlDataReader["AnswerId"]);
                                scrumData.Answer = Convert.ToString(sqlDataReader["Answer"]);
                                scrumData.QuestionId = Convert.ToInt32(sqlDataReader["QuestionId"]);
                                scrumData.UserId = Convert.ToInt32(sqlDataReader["UserId"]);
                                scrumData.DateEntered = Convert.ToDateTime(sqlDataReader["DateEntered"]);
                                scrumData.DateModified = Convert.ToDateTime(sqlDataReader["DateModified"]);
                                scrumModel.ScrumList.Add(scrumData);
                            }
                        }
                        sqlDataReader.Close();
                    }
                }
                sqlConnection.Close();
            }
            return scrumModel;
        }

    }
}
