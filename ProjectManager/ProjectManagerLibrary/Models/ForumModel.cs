using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerLibrary.Models
{
    public class ForumModel
    {
        public ArrayList ReplyList { get; set; }
        public DateTime DateEntered { get; set; }
        public DateTime DateModified { get; set; }
        public int UserId { get; set; }
        public int ReplyId { get; set; }
        public int ForumId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }
        public string ForumPost { get; set; }
        
    }
    public class ReplyModel
    {
        public DateTime DateEntered { get; set; }
        public DateTime DateModified { get; set; }
        public int ForumId { get; set; }
        public int ReplyId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ReplyPost { get; set; }
    }
}
