using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManagerLibrary.Models;
using ProjectManagerWeb.Controllers;


namespace ProjectManagerWeb.Scrum
{
    public partial class EnterScrumData : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ScrumController scrumController = new ScrumController();
            ScrumModel scrumModel = scrumController.GetScrumQuestions();

            Label1.Text = ((Questions)scrumModel.QuestionList[0]).Question;
            Label2.Text = ((Questions)scrumModel.QuestionList[1]).Question;
            Label3.Text = ((Questions)scrumModel.QuestionList[2]).Question;

            answer1.ID = Convert.ToString(((Questions)scrumModel.QuestionList[0]).QuestionId);
            answer2.ID = Convert.ToString(((Questions)scrumModel.QuestionList[1]).QuestionId);
            answer3.ID = Convert.ToString(((Questions)scrumModel.QuestionList[2]).QuestionId);
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            ScrumModel scrumModel = new ScrumModel();
            scrumModel.AnswerList = new System.Collections.ArrayList();

            Answers answers = new Answers();
            answers.Answer = answer1.Text;
            answers.QuestionId = Convert.ToInt32(answer1.ID);
            answers.UserId = 1;
            scrumModel.AnswerList.Add(answers);

            answers = new Answers();
            answers.Answer = answer2.Text;
            answers.QuestionId = Convert.ToInt32(answer2.ID);
            answers.UserId = 1;
            scrumModel.AnswerList.Add(answers);

            answers = new Answers();
            answers.Answer = answer3.Text;
            answers.QuestionId = Convert.ToInt32(answer3.ID);
            answers.UserId = 1;
            scrumModel.AnswerList.Add(answers);

            bool dataInserted = new ScrumController().InputNewScrum(scrumModel);
            if (dataInserted)
            {
                Session.Add("Message", "The scrum data was successfully entered.");
                Response.Redirect("~/Scrum/ViewScrumData.aspx");
            }
            else
            {
                Message.Text = "There was an error inserting the scrum data.";
            }
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Scrum/ViewScrumData.aspx");
        }
    }
}