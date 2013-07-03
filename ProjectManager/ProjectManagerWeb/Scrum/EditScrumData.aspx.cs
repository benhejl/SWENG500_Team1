using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManagerLibrary.Models;
namespace ProjectManagerWeb.Scrum
{
    public partial class EditScrumData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Controllers.ScrumController scrumController = new Controllers.ScrumController();
                ScrumModel scrumModel = scrumController.GetScrumDetails(Convert.ToInt32(Request["AnswerKey"]));
                foreach(Answers answer in scrumModel.AnswerList)
                {
                    if (answer.QuestionId == 1)
                    {
                        txtBoxAnswer1.Text = answer.Answer;
                    }
                    if (answer.QuestionId == 2)
                    {
                        txtBoxAnswer2.Text = answer.Answer;
                    }
                    if (answer.QuestionId == 3)
                    {
                        txtBoxAnswer3.Text = answer.Answer;
                    }
                }
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            
            ScrumModel scrumModel = new ScrumModel();
            scrumModel.AnswerList = new System.Collections.ArrayList();

            Answers answer = new Answers();
            answer.QuestionId = 1;
            answer.AnswerKey = Convert.ToInt32(Request["AnswerKey"]);
            answer.Answer = txtBoxAnswer1.Text;
            scrumModel.AnswerList.Add(answer);

            answer = new Answers();
            answer.QuestionId = 2;
            answer.AnswerKey = Convert.ToInt32(Request["AnswerKey"]);
            answer.Answer = txtBoxAnswer2.Text;
            scrumModel.AnswerList.Add(answer);

            answer = new Answers();
            answer.QuestionId = 3;
            answer.AnswerKey = Convert.ToInt32(Request["AnswerKey"]);
            answer.Answer = txtBoxAnswer3.Text;
            scrumModel.AnswerList.Add(answer);

            new Controllers.ScrumController().EditScrum(scrumModel);
            Response.Redirect("~/Scrum/ViewScrumData.aspx");
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Scrum/ViewScrumData.aspx");
        }
    }
}