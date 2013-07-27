using ProjectManagerLibrary.Models.Reports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ProjectManagerLibrary.Models;
using System.Web.UI.WebControls;

namespace ProjectManagerTest
{
    
    
    /// <summary>
    ///This is a test class for IssuePriorityReportTest and is intended
    ///to contain all IssuePriorityReportTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IssuePriorityReportTest
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
        ///A test for IssuePriorityReport Constructor
        ///</summary>
        [TestMethod()]
        public void IssuePriorityReportConstructorTest()
        {
            IssuePriorityReport target = new IssuePriorityReport();
            Assert.IsInstanceOfType(target, typeof(IssuePriorityReport));
        }

        private Issue CreateIssue(Issue.IssuePriority priority)
        {
            Issue issue = new Issue();
            issue.CurrentPriority = priority;
            return issue;
        }

        /// <summary>
        ///A test for SummaryForProject
        ///</summary>
        [TestMethod()]
        public void SummaryForProjectTest()
        {
            IssuePriorityReport target = new IssuePriorityReport(); // TODO: Initialize to an appropriate value
            Project project = new Project(1, "Test", DateTime.Now, DateTime.Now.AddDays(1), "", "", "", DateTime.Now.AddDays(1));

            TableRow[] result = target.SummaryForProject(null);
            Assert.AreEqual(result.Length, 0);

            result = target.SummaryForProject(project);
            Assert.AreEqual(result.Length, 5);
            Assert.AreEqual("Issues by Priority", result[0].Cells[0].Text);
            Assert.AreEqual("Priority", result[1].Cells[0].Text);
            Assert.AreEqual("Count", result[1].Cells[1].Text);
            Assert.AreEqual("High", result[2].Cells[0].Text);
            Assert.AreEqual("Medium", result[3].Cells[0].Text);
            Assert.AreEqual("Low", result[4].Cells[0].Text);
            Assert.AreEqual("0", result[2].Cells[1].Text);
            Assert.AreEqual("0", result[3].Cells[1].Text);
            Assert.AreEqual("0", result[4].Cells[1].Text);

            project.AddIssue(CreateIssue(Issue.IssuePriority.High));
            result = target.SummaryForProject(project);
            Assert.AreEqual("1", result[2].Cells[1].Text);

            project.AddIssue(CreateIssue(Issue.IssuePriority.Medium));
            result = target.SummaryForProject(project);
            Assert.AreEqual("1", result[3].Cells[1].Text);

            project.AddIssue(CreateIssue(Issue.IssuePriority.Low));
            result = target.SummaryForProject(project);
            Assert.AreEqual("1", result[4].Cells[1].Text);
        }
    }
}
