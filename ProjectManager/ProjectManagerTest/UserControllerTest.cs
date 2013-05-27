using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagerWeb.Controllers;
using System.Web.Mvc;

namespace ProjectManagerMVC.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {

        ProjectManagerWeb.Controllers.UserController _userController;


        [TestInitialize]
        public void Setup()
        {
            _userController = new ProjectManagerWeb.Controllers.UserController();
        }


        /// <summary>
        /// This test is to verify the view name.
        /// </summary>
        [TestMethod]
        public void Index()
        {
            // Arrange
            ProjectManagerWeb.Controllers.UserController controller = new ProjectManagerWeb.Controllers.UserController();
 
            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("", result.ViewName);

        }


        /// <summary>
        /// This test is to verify when there is a validation error the controller should return the same login view.
        /// </summary>
        [TestMethod]
        public void LogOn_Action_Invalid_Input_Test()
        {
            //** Arrange
            _userController.ModelState.AddModelError("UserName", "UserName is Required.");

            //** Act
            var actual = _userController.LogIn(new ProjectManagerWeb.Models.UserModel());

            //** Assert

            // verify ViewResult is returned from action
            Assert.IsInstanceOfType(actual, typeof(ViewResult));
        }




    }



}
