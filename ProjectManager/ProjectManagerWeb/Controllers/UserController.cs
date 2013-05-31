using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManagerLibrary.Models;
using ProjectManagerBLL;

namespace ProjectManagerWeb.Controllers
{
    public class UserController
    {
        public User GetUserInfo(string userName)
        {
            return new UserBLL().GetUserInfo(userName);
        }
        public bool Login(string username, string password)
        {
            return true;
        }
        public bool Logout(string username)
        {
            return true;
        }
        public bool NewUser(User newUser)
        {
            return true;
        }
        public bool ResetPassword(User newUser)
        {
            return true;
        }
    }
}
