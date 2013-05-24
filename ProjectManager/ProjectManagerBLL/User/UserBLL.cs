using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagerDAL;
using ProjectManagerLibrary.Models;

namespace ProjectManagerBLL
{
    public class UserBLL
    {
        public User GetUserInfo(string userName)
        {
            return new ProjectManagerDAL.UserDAL().GetUserInfo(userName);
        }
    }
}
