using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerLibrary.Models
{
    [Serializable]
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public string FirstName { get; set;}
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public string TeamName { get; set; }
    }
}
