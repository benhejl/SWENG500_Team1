using ProjectManagerLibrary.Models.Reports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ProjectManagerLibrary.Models;
using System.Web.UI.WebControls;

namespace ProjectManagerTest
{
    
    
    /// <summary>
    ///This is a test class for IssueStatusTest and is intended
    ///to contain all IssueStatusTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IssueStatusTest
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
        ///A test for IssueStatus Constructor
        ///</summary>
        [TestMethod()]
        public void IssueStatusConstructorTest()
        {
            IssueStatus target = new IssueStatus();
            Assert.IsInstanceOfType(target, typeof(IssueStatus));
            Assert.IsInstanceOfType(target, typeof(SummaryBase));
        }

        /// <summary>
        ///A test for SummaryForProject
        ///</summary>
        [TestMethod()]
        public void SummaryForProjectTest()
        {
            IssueStatus target = new IssueStatus();
            Project project = null;
            TableRow[] actual = target.SummaryForProject(project);
            Assert.AreEqual(actual.Length, 0);

            project = new Project(1, "Test", DateTime.Now.Subtract(TimeSpan.FromDays(5)), DateTime.Now, "Status", "Description", "Category", DateTime.Now);
            actual = target.SummaryForProject(project);
            Assert.AreEqual(actual.Length, 4);
            Assert.AreEqual(actual[2].Cells[1].Text, "0");
            Assert.AreEqual(actual[3].Cells[1].Text, "0");

            project.AddIssue(new Issue());
            Issue issue = new Issue();
            issue.UpdateStatus(Issue.IssueStatus.Resolved, DateTime.Now);
            project.AddIssue(issue);
            actual = target.SummaryForProject(project);
            Assert.AreEqual(actual.Length, 4);
            Assert.AreEqual(actual[2].Cells[1].Text, "1");
            Assert.AreEqual(actual[3].Cells[1].Text, "1");
        }
    }
}
