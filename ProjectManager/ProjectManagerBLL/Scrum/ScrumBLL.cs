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
    }
}
