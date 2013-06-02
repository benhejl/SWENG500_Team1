using ProjectManagerLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ProjectManagerTest
{
    
    
    /// <summary>
    ///This is a test class for ProjectTest and is intended
    ///to contain all ProjectTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProjectTest
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

        int DEFAULT_PROJECTID = 1;
        string DEFAULT_NAME = "Project Name";
        DateTime DEFAULT_START_DATE = DateTime.Today;
        DateTime DEFAULT_END_DATE = DateTime.Today + new TimeSpan(1, 0, 0, 0);
        DateTime DEFAULT_DUE_DATE = DateTime.Today + new TimeSpan(2, 0, 0, 0);
        string DEFAULT_STATUS = "Open";
        string DEFAULT_DESCRIPTION = "Project Status";
        string DEFAULT_CATEGORY = "Project Category";

        private Project BuildDefaultProject()
        {
            return new Project(DEFAULT_PROJECTID, DEFAULT_NAME, DEFAULT_START_DATE, DEFAULT_END_DATE, DEFAULT_STATUS, DEFAULT_DESCRIPTION, DEFAULT_CATEGORY, DEFAULT_DUE_DATE);
        }

        /// <summary>
        ///A test for Project Constructor
        ///</summary>
        [TestMethod()]
        public void ProjectConstructorTest()
        {
            Project target = BuildDefaultProject();   

            Assert.AreEqual(target.Name, DEFAULT_NAME);
            Assert.AreEqual(target.Description, DEFAULT_DESCRIPTION);
            Assert.AreEqual(target.Category, DEFAULT_CATEGORY);
            Assert.AreEqual(target.StartDate, DEFAULT_START_DATE);
            Assert.AreEqual(target.EndDate, DEFAULT_END_DATE);
            Assert.AreEqual(target.DueDate, DEFAULT_DUE_DATE);
            Assert.AreEqual(target.Status, DEFAULT_STATUS);
            Assert.AreEqual(target.Issues.Count, 0);

            int openIssues = target.OpenIssues();
            int resolvedIssues = target.ResovledIssues();
            Assert.AreEqual(openIssues, 0);
            Assert.AreEqual(resolvedIssues, 0);
        }

        /// <summary>
        ///A test for AddIssue
        ///</summary>
        [TestMethod()]
        public void AddIssueTest()
        {
            Project project = BuildDefaultProject();
            Issue issue = new Issue();
            project.AddIssue(issue);
            Assert.AreEqual(project.Issues.Count, 1);
            Assert.AreSame(project.Issues[0], issue);

            issue = new Issue();
            project.AddIssue(issue);
            Assert.AreEqual(project.Issues.Count, 2);
            Assert.AreNotSame(project.Issues[0], issue);
            Assert.AreSame(project.Issues[1], issue);
        }

        /// <summary>
        ///A test for OpenIssues
        ///</summary>
        [TestMethod()]
        public void OpenIssuesTest()
        {
            Project project = BuildDefaultProject();
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ResovledIssues
        ///</summary>
        [TestMethod()]
        public void ResovledIssuesTest()
        {
            Project project = BuildDefaultProject();
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        /// Verify a project is not created with an end date before the start date
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ProjectConstructorInvalidEndDate()
        {
            Project project = new Project(1, "", new DateTime(2013, 5, 26), new DateTime(2013, 5, 25), "Open", "", "", new DateTime(2013, 5, 27));
        }

        /// <summary>
        /// Verify a project is not created with an due date before the start date
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ProjectConstructorInvalidDueDate()
        {
            Project project = new Project(1, "", new DateTime(2013, 5, 26), new DateTime(2013, 5, 27), "Open", "", "", new DateTime(2013, 5, 25));
        }

        /// <summary>
        /// Verify a project is not created with an empty name
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ProjectConstructorInvalidName()
        {
            Project project = new Project(1, "", new DateTime(2013, 5, 25), new DateTime(2013, 5, 26), "Open", "", "", new DateTime(2013, 5, 27));
        }

        /// <summary>
        /// Verify a null issue cannot be added to a project.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ProjectAddIssueNullIssue()
        {
            Project project = BuildDefaultProject();
            project.AddIssue(null);
        }
    }
}
