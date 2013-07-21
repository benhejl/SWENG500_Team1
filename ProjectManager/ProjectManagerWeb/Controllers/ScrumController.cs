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
        public ScrumModel ViewScrumData()
        {
            return new ScrumBLL().ViewScrumData();
        }
        public ScrumModel GetScrumDetails(int answerKey)
        {
            return new ScrumBLL().GetScrumDetails(answerKey);
        }
        public ScrumModel GetScrumQuestions()
        {
            return new ScrumBLL().GetScrumQuestions();
        }
        public bool ScrumByDate()
        {
            return true;
        }
        public bool ViewTeamMembersScrum()
        {
            return true;
        }
    }
}