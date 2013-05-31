﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagerWeb.Controllers;
using ProjectManagerLibrary.Models;

namespace ProjectManagerTest
{
    /// <summary>
    /// Summary description for ScrumTestUnit
    /// </summary>
    [TestClass]
    public class UserTestUnit
    {
        public UserTestUnit()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestGetUserInfo()
        {
            UserController userController = new UserController();
            User user = userController.GetUserInfo("jlw923");
            Assert.IsTrue(user.FirstName.Equals("Jennifer"));
        }
        [TestMethod]
        public void TestLogin()
        {
            UserController userController = new UserController();
            Assert.IsTrue(userController.Login("jlw923", "password"));
        }
        [TestMethod]
        public void TestLogout()
        {
            UserController userController = new UserController();
            Assert.IsTrue(userController.Logout("jlw923"));
        }
        [TestMethod]
        public void TestSignup()
        {
            UserController userController = new UserController();
            Assert.IsTrue(userController.NewUser(new User()));
        }
        [TestMethod]
        public void TestResetPassword()
        {
            UserController userController = new UserController();
            Assert.IsTrue(userController.ResetPassword(new User()));
        }
    }
}
