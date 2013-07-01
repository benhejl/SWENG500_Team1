using ProjectManagerWeb.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace ProjectManagerTest
{
    
    
    /// <summary>
    ///This is a test class for IssueControllerTest and is intended
    ///to contain all IssueControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IssueControllerTest
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

        [TestMethod()]
        public void AddNewIssueTest()
        {
            IssueController target = new IssueController();
            bool expected = true;
            bool actual;
            actual = target.AddNewIssue();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DeleteIssueTest()
        {
            IssueController target = new IssueController();
            bool expected = true;
            bool actual;
            actual = target.DeleteIssue();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddAssigneeToIssueTest()
        {
            IssueController target = new IssueController();
            bool expected = true;
            bool actual;
            actual = target.AddAssigneeToIssue();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DeleteAssigneeFromIssueTest()
        {
            IssueController target = new IssueController();
            bool expected = true;
            bool actual;
            actual = target.DeleteAssigneeFromIssue();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void EditIssueDetailsTest()
        {
            IssueController target = new IssueController();
            bool expected = true;
            bool actual;
            actual = target.EditIssueDetails();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ViewIssueListTest()
        {
            IssueController target = new IssueController();
            bool expected = true;
            bool actual;
            actual = target.ViewIssueList();
            Assert.AreEqual(expected, actual);
        }
    }
}
