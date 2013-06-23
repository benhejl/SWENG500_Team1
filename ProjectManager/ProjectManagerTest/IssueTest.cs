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
    ///This is a test class for DefectTest and is intended
    ///to contain all DefectTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IssueTest
    {


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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Issue Constructor
        ///</summary>
        [TestMethod()]
        public void IssueConstructorTest()
        {
            Issue target = new Issue();
            Assert.IsInstanceOfType(target, typeof(Issue));
            Assert.AreEqual(target.CurrentPriority, Issue.IssuePriority.Medium);
            Assert.AreEqual(target.CurrentStatus, Issue.IssueStatus.Unresolved);
        }


        /// <summary>
        /// Required Issue Subject field test.
        /// </summary>
        [TestMethod]
        public void RequiredPasswordFieldTest()
        {
            var issue = new Issue()
            {
                Subject = ""
                
            };

            var context = new ValidationContext(issue, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(issue, context, results);

            var sb = new StringBuilder();

            if (!isValid)
            {
                foreach (var validationResult in results)
                {
                    // add validation error message to string builder.
                    sb.Append(validationResult.ErrorMessage);
                }
            }

            // check if "The Subject field is required." is in the error message.
            Assert.IsTrue(sb.ToString().Contains("The Subject field is required."));

        }


        /// <summary>
        ///A test for UpdateStatus
        ///</summary>
        [TestMethod()]
        public void UpdateStatusTest()
        {
            Issue target = new Issue();
            target.UpdateStatus(Issue.IssueStatus.Unresolved, DateTime.Now);
            Assert.AreEqual(target.CurrentStatus, Issue.IssueStatus.Unresolved);

            target.UpdateStatus(Issue.IssueStatus.Resolved, DateTime.Now.AddMinutes(1));
            Assert.AreEqual(target.CurrentStatus, Issue.IssueStatus.Resolved);

            target.UpdateStatus(Issue.IssueStatus.Unresolved, DateTime.Now.Subtract(TimeSpan.FromDays(1)));
            Assert.AreEqual(target.CurrentStatus, Issue.IssueStatus.Resolved);

            target.UpdateStatus(Issue.IssueStatus.Unresolved, DateTime.Now.Add(TimeSpan.FromDays(1)));
            Assert.AreEqual(target.CurrentStatus, Issue.IssueStatus.Unresolved);
        }

        /// <summary>
        /// Test that modifying an issue status to the date before it was created throws an exception.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateStatusBeforeCreatedTest()
        {
            Issue issue = new Issue();
            issue.EntryDate = DateTime.Now;
            issue.UpdateStatus(Issue.IssueStatus.Unresolved, DateTime.Now.Subtract(TimeSpan.FromDays(1)));
        }

        /// <summary>
        ///A test for StatusOn
        ///</summary>
        [TestMethod()]
        public void StatusOnTest()
        {
            Issue issue = new Issue();
            issue.EntryDate = DateTime.Now;
            DateTime statusTime = DateTime.Now;
            issue.UpdateStatus(Issue.IssueStatus.Unresolved, statusTime);

            Issue.IssueStatus status = issue.StatusOn(statusTime.AddDays(1));
            Assert.AreEqual(status, Issue.IssueStatus.Unresolved);

            issue.UpdateStatus(Issue.IssueStatus.Resolved, statusTime.AddDays(2));
            status = issue.StatusOn(statusTime.AddDays(3));
            Assert.AreEqual(status, Issue.IssueStatus.Resolved);

            issue = new Issue();
            issue.EntryDate = DateTime.Now;
            DateTime testBoundary = DateTime.Now.AddDays(10);
            issue.UpdateStatus(Issue.IssueStatus.Resolved, DateTime.Now);
            issue.UpdateStatus(Issue.IssueStatus.Unresolved, testBoundary);
            Assert.AreEqual(issue.StatusOn(DateTime.Now), Issue.IssueStatus.Resolved);
            Assert.AreEqual(issue.StatusOn(DateTime.Now.AddDays(5)), Issue.IssueStatus.Resolved);
            Assert.AreEqual(issue.StatusOn(testBoundary.Subtract(TimeSpan.FromMilliseconds(100))), Issue.IssueStatus.Resolved);
            Assert.AreEqual(issue.StatusOn(testBoundary), Issue.IssueStatus.Unresolved);
            Assert.AreEqual(issue.StatusOn(testBoundary.AddMilliseconds(100)), Issue.IssueStatus.Unresolved);
            Assert.AreEqual(issue.StatusOn(testBoundary.AddDays(1)), Issue.IssueStatus.Unresolved);
        }
    }
}

