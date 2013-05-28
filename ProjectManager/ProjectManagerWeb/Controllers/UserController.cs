using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ProjectManagerLibrary.Models;
using ProjectManagerBLL;

namespace ProjectManagerWeb.Controllers
{
    public class UserController : Controller
    {

        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// Login
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult LogIn(ProjectManagerWeb.Models.UserModel user)
        {
            if (user.UserName  != null && user.Password != null) 
            {
                if (IsValid(user.UserName, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, user.rememberme);
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError("", "The username and password provided is incorrect.");
                }

            }
            return View(user);
        }

        /// <summary>
        /// Registration
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }


        /// <summary>
        /// Registration
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Registration(ProjectManagerWeb.Models.UserModel user)
        {

            if (ModelState.IsValid)
            {
                if (IsUniqueUser(user.UserName))
                {
                    using (var db = new ProjectManagerEntities())
                    {

                        var newuser = db.Users.CreateObject();

                        newuser.UserName = user.UserName;
                        newuser.Password = user.Password;
                        newuser.UserRole = user.UserRole;
                        newuser.FirstName = user.FirstName;
                        newuser.LastName = user.LastName;
                        newuser.Email = user.Email;
                        newuser.PhoneNumber = user.PhoneNumber;
                        newuser.Position = user.Position;
                        newuser.TeamName = user.TeamName;

                        db.Users.AddObject(newuser);
                        db.SaveChanges();

                        FormsAuthentication.SetAuthCookie(user.UserName, false);
                        return RedirectToAction("Index", "Dashboard");


                    }
                }
                else
                {
                    // User already exists.
                    ModelState.AddModelError("", "User account already exists.");

                }
            }
            else
            {
                // error adding new user to database.
                ModelState.AddModelError("", "Registration Information is incorrect.");
            }

            return View();
        }


        /// <summary>
        /// Logout
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }


        /// <summary>
        /// IsUniqueUser
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpPost]
        public bool IsUniqueUser(string userName)
        {
            var isUnique = false;

            using (var db = new ProjectManagerEntities())
            {
                var user = db.Users.FirstOrDefault(u => u.UserName == userName);

                if (user == null) isUnique = true;

            }

            return isUnique;
        }


        /// <summary>
        /// Validate username and password.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>bool</returns>
        private bool IsValid(string username, string password)
        {
            bool isValid = false;

            using (var db = new ProjectManagerEntities())
            {
                var user = db.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);

                if (user != null)
                {
                    isValid = true;
                }

            }

            return isValid;
        }

    }
}
