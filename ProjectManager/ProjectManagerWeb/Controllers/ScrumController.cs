using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManagerLibrary.Models;
using ProjectManagerBLL.Scrum;
namespace ProjectManagerWeb.Controllers
{
    public class ScrumController
    {
        public bool InputNewScrum(ScrumModel scrum)
        {
            return new ScrumBLL().InputNewScrum(scrum);
        }
        public bool EditScrum(ScrumModel scrum)
        {
            return new ScrumBLL().EditScrum(scrum);
        }
        public ScrumModel ViewScrumData(int userId)
        {
            return new ScrumBLL().ViewScrumData(userId);
        }
        public ScrumModel GetScrumDetails(int answerKey)
        {
            return new ScrumBLL().GetScrumDetails(answerKey);
        }
        public ScrumModel GetScrumQuestions()
        {
            return new ScrumBLL().GetScrumQuestions();
        }
        public ScrumModel ScrumByDate(string date, string nextDay)
        {
            return new ScrumBLL().ViewScrumDataByDate(date, nextDay);

        }
        public bool ViewTeamMembersScrum()
        {
            return true;
        }
    }
}