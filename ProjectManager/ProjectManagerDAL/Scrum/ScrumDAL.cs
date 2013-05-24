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
                            scrumModel.QuestionsTable = new Dictionary<int,string>();
                            while (sqlDataReader.Read())
                            {
                                scrumModel.QuestionsTable.Add(Convert.ToInt32(sqlDataReader["ScrumQuestionId"]), Convert.ToString(sqlDataReader["ScrumQuestion"]));
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
