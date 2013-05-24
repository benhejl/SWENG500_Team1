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
    }
}