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
            return true;
        }
        public bool EditScrum(ScrumModel scrum)
        {
            return true;
        }
        public bool ViewScrum(ScrumModel scrum)
        {
            return true;
        }
        public bool ViewScrumDetails(ScrumModel scrum)
        {
            return true;
        }
        public ScrumModel GetScrumQuestions()
        {
            return new ScrumBLL().GetScrumQuestions();
        }
    }
}