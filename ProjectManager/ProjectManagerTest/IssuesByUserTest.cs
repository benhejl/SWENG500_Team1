using ProjectManagerLibrary.Models.Reports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ProjectManagerLibrary.Models;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace ProjectManagerTest
{
    
    
    /// <summary>
    ///This is a test class for IssuesByUserTest and is intended
    ///to contain all IssuesByUserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IssuesByUserTest
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
        ///A test for IssuesByUser Constructor
        ///</summary>
        [TestMethod()]
        public void IssuesByUserConstructorTest()
        {
            IssuesByUser target = new IssuesByUser();
            Assert.IsInstanceOfType(target, typeof(IssuesByUser));
            Assert.IsInstanceOfType(target, typeof(SummaryBase));
        }

        /// <summary>
        ///A test for SummaryForProject
        ///</summary>
        [TestMethod()]
        public void SummaryForProjectTest()
        {
            IssuesByUser target = new IssuesByUser();
            Project project = null;
            TableRow[] actual = target.SummaryForProject(project);
            Assert.AreEqual(actual.Length, 0);

            project = new Project(1, "Test", DateTime.Now.Subtract(TimeSpan.FromDays(5)), DateTime.Now, "Status", "Description", "Category", DateTime.Now);
            actual = target.SummaryForProject(project);
            Assert.AreEqual(actual.Length, 0);

            project = CreateInitialProject();
            actual = target.SummaryForProject(project);
            Assert.AreEqual(3, actual.Length);
            Assert.AreEqual("User1", actual[2].Cells[0].Text);
            Assert.AreEqual("1", actual[2].Cells[1].Text);

            project = CreateSecondTestProject();
            actual = target.SummaryForProject(project);
            Assert.AreEqual(actual.Length, 4);
            Assert.AreEqual(actual[2].Cells[0].Text, "User2");
            Assert.AreEqual(actual[2].Cells[1].Text, "2");
            Assert.AreEqual(actual[3].Cells[0].Text, "User1");
            Assert.AreEqual(actual[3].Cells[1].Text, "1");
        }

        /// <summary>
        ///A test for FindIssuesByUser
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ProjectManagerLibrary.dll")]
        public void FindIssuesByUserTest()
        {
            IssuesByUser_Accessor target = new IssuesByUser_Accessor(); // TODO: Initialize to an appropriate value
            Project project = CreateSecondTestProject();
            Dictionary<string, int> issuesByUser = target.FindIssuesByUser(project);
            Assert.AreEqual(issuesByUser["User1"], 1);
            Assert.AreEqual(issuesByUser["User2"], 2);
        }

        /// <summary>
        ///A test for SortIssuesForDisplay
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ProjectManagerLibrary.dll")]
        public void SortIssuesForDisplayTest()
        {
            IssuesByUser_Accessor target = new IssuesByUser_Accessor();
            Project project = CreateSecondTestProject();
            Dictionary<string, int> dictionary = target.FindIssuesByUser(project);
            List<KeyValuePair<string, int>> actual = target.SortIssuesForDisplay(dictionary);
            Assert.AreEqual(dictionary.Keys.Count, actual.Count);
            Assert.AreEqual(2, actual.Count);
            Assert.IsTrue(actual[0].Value > actual[1].Value);

            project = CreateThirdTestProject();
            dictionary = target.FindIssuesByUser(project);
            actual = target.SortIssuesForDisplay(dictionary);
            Assert.AreEqual(3, actual.Count);
            Assert.IsTrue(actual[0].Value > actual[1].Value);
            Assert.IsTrue(actual[1].Value == actual[2].Value);
            Assert.IsTrue(actual[1].Key.CompareTo(actual[2].Key) < 0);
        }

        
        private Project CreateInitialProject()
        {
            Project project = new Project(1, "Test", DateTime.Now.Subtract(TimeSpan.FromDays(5)), DateTime.Now, "Status", "Description", "Category", DateTime.Now);
            Issue issue = new Issue();
            issue.Assignee = new User(0, "User1", "", "", "", "", "", "", "", "");
            project.AddIssue(issue);
            return project;
        }

        private Project CreateSecondTestProject()
        {
            Project project = CreateInitialProject();
            User user2 = new User(0, "User2", "", "", "", "", "", "", "", "");
            Issue issue = new Issue();
            issue.Assignee = user2;
            project.AddIssue(issue);
            issue = new Issue();
            issue.Assignee = user2;
            project.AddIssue(issue);
            return project;
        }

        private Project CreateThirdTestProject()
        {
            Project project = CreateSecondTestProject();
            User user = new User(0, "AUser", "", "", "", "", "", "", "", "");
            Issue issue = new Issue();
            issue.Assignee = user;
            project.AddIssue(issue);
            return project;
        }
    }
}
