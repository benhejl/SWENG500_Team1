using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagerDAL.Scrum;
using ProjectManagerLibrary.Models;
namespace ProjectManagerBLL.Scrum
{
    public class ScrumBLL
    {
        public ScrumModel GetScrumQuestions()
        {
            return new ScrumDAL().GetScrumQuestions();
        }

        public bool InputNewScrum(ScrumModel scrum)
        {
            return new ScrumDAL().InputNewScrum(scrum);
        }
        public ScrumModel ViewScrumData()
        {
            return new ScrumDAL().ViewScrumData();
        }
    }
}
