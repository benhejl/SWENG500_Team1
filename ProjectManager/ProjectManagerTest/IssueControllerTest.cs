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
        public void DeleteIssueAttachmentTest()
        {
            IssueController target = new IssueController();
            bool expected = true;
            bool actual;
            actual = target.DeleteIssueAttachment();
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

        /// <summary>
        ///A test for IssueController Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Lauren\\Documents\\GitHub\\SWENG500_Team1\\ProjectManager\\ProjectManagerWeb", "/")]
        [UrlToTest("http://localhost:19961/")]
        public void IssueControllerConstructorTest()
        {
            IssueController target = new IssueController();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for AddAssigneeToIssue
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Lauren\\Documents\\GitHub\\SWENG500_Team1\\ProjectManager\\ProjectManagerWeb", "/")]
        [UrlToTest("http://localhost:19961/")]
        public void AddAssigneeToIssueTest1()
        {
            IssueController target = new IssueController(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.AddAssigneeToIssue();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddNewIssue
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Lauren\\Documents\\GitHub\\SWENG500_Team1\\ProjectManager\\ProjectManagerWeb", "/")]
        [UrlToTest("http://localhost:19961/")]
        public void AddNewIssueTest1()
        {
            IssueController target = new IssueController(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.AddNewIssue();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DeleteAssigneeFromIssue
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Lauren\\Documents\\GitHub\\SWENG500_Team1\\ProjectManager\\ProjectManagerWeb", "/")]
        [UrlToTest("http://localhost:19961/")]
        public void DeleteAssigneeFromIssueTest1()
        {
            IssueController target = new IssueController(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.DeleteAssigneeFromIssue();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DeleteIssue
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Lauren\\Documents\\GitHub\\SWENG500_Team1\\ProjectManager\\ProjectManagerWeb", "/")]
        [UrlToTest("http://localhost:19961/")]
        public void DeleteIssueTest1()
        {
            IssueController target = new IssueController(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.DeleteIssue();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EditIssueDetails
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Lauren\\Documents\\GitHub\\SWENG500_Team1\\ProjectManager\\ProjectManagerWeb", "/")]
        [UrlToTest("http://localhost:19961/")]
        public void EditIssueDetailsTest1()
        {
            IssueController target = new IssueController(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.EditIssueDetails();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ViewIssueList
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Lauren\\Documents\\GitHub\\SWENG500_Team1\\ProjectManager\\ProjectManagerWeb", "/")]
        [UrlToTest("http://localhost:19961/")]
        public void ViewIssueListTest1()
        {
            IssueController target = new IssueController(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.ViewIssueList();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
