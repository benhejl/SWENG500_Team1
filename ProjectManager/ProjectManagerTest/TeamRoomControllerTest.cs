using ProjectManagerWeb.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using ProjectManagerLibrary.Models;

namespace ProjectManagerTest
{
    
    
    /// <summary>
    ///This is a test class for TeamRoomControllerTest and is intended
    ///to contain all TeamRoomControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TeamRoomControllerTest
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
        ///A test for TeamRoomController Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Lauren\\Documents\\GitHub\\SWENG500_Team1\\ProjectManager\\ProjectManagerWeb", "/")]
        [UrlToTest("http://localhost:19961/")]
        public void TeamRoomControllerConstructorTest()
        {
            TeamRoomController target = new TeamRoomController();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for CreateTeamRoom
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Lauren\\Documents\\GitHub\\SWENG500_Team1\\ProjectManager\\ProjectManagerWeb", "/")]
        [UrlToTest("http://localhost:19961/")]
        public void CreateTeamRoomTest()
        {
            TeamRoomController target = new TeamRoomController(); // TODO: Initialize to an appropriate value
            TeamRoom teamRoom = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.CreateTeamRoom(teamRoom);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EnterTeamRoom
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Lauren\\Documents\\GitHub\\SWENG500_Team1\\ProjectManager\\ProjectManagerWeb", "/")]
        [UrlToTest("http://localhost:19961/")]
        public void EnterTeamRoomTest()
        {
            TeamRoomController target = new TeamRoomController(); // TODO: Initialize to an appropriate value
            TeamRoom teamRoom = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.EnterTeamRoom(teamRoom);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LeaveTeamRoom
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Lauren\\Documents\\GitHub\\SWENG500_Team1\\ProjectManager\\ProjectManagerWeb", "/")]
        [UrlToTest("http://localhost:19961/")]
        public void LeaveTeamRoomTest()
        {
            TeamRoomController target = new TeamRoomController(); // TODO: Initialize to an appropriate value
            TeamRoom teamRoom = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.LeaveTeamRoom(teamRoom);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ViewTeamRoomConversations
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Lauren\\Documents\\GitHub\\SWENG500_Team1\\ProjectManager\\ProjectManagerWeb", "/")]
        [UrlToTest("http://localhost:19961/")]
        public void ViewTeamRoomConversationsTest()
        {
            TeamRoomController target = new TeamRoomController(); // TODO: Initialize to an appropriate value
            TeamRoom teamRoom = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.ViewTeamRoomConversations(teamRoom);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
