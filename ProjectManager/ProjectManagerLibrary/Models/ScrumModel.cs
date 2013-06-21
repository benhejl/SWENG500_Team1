using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerLibrary.Models
{
    public class ScrumModel
    {
        public int UserId { get; set; }

        public ArrayList QuestionList { get; set; }
        public ArrayList AnswerList { get; set; }
        public ArrayList ScrumList { get; set; }

    }
    public class Questions
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
    }
    public class Answers
    {
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public string Answer { get; set; }

    }
    public class ScrumData
    {
        public DateTime DateEntered { get; set; }
        public DateTime DateModified { get; set; }
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public string Answer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Question { get; set; }
    }
}
