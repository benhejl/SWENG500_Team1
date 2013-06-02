using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagerWeb.Controllers;
using ProjectManagerLibrary.Models;
using ProjectManagerBLL;
using System.ComponentModel.DataAnnotations;


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

        /// <summary>
        /// A test case for user successful login (string username, string password)
        /// </summary>
        [TestMethod]
        public void LoginTest()
        {
            string username = "jlw923";
            string password = "password";

            var user = new UserBLL();
            var isValidUser = user.Login(username, password);

            Assert.IsTrue(isValidUser);

        }

        /// <summary>
        /// Required password test.
        /// </summary>
        [TestMethod]
        public void RequiredPasswordFieldTest()
        {
            var user = new User() 
            {
                UserName = "test",
                Password = ""
            };

            var context = new ValidationContext(user, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(user, context, results);

            var sb = new StringBuilder();

            if (!isValid)
            {
                foreach (var validationResult in results)
                {
                    // add validation error message to string builder.
                    sb.Append(validationResult.ErrorMessage);
                }
            }

            // check if "The Password field is required." is in the error message.
            Assert.IsTrue(sb.ToString().Contains("The Password field is required."));

        }
    }
}
