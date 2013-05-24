using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerLibrary.Models
{
    public class ScrumModel 
    {
        public int UserId { get; set; }
        public Dictionary<int, string> QuestionsTable { get; set; }
    }
}
