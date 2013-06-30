using ProjectManagerWeb.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace ProjectManagerTest
{
    
    
    /// <summary>
    ///This is a test class for CalendarControllerTest and is intended
    ///to contain all CalendarControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CalendarControllerTest
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
        public void DeleteEventFromCalendarTest()
        {
            CalendarController target = new CalendarController();
            bool expected = true;
            bool actual;
            actual = target.DeleteEventFromCalendar();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DeleteExistingCalendarTest()
        {
            CalendarController target = new CalendarController();
            bool expected = true;
            bool actual;
            actual = target.DeleteExistingCalendar();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DeleteUsersFromCalendarTest()
        {
            CalendarController target = new CalendarController();
            bool expected = true;
            bool actual;
            actual = target.DeleteUsersFromCalendar();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CreateNewCalendarTest()
        {
            CalendarController target = new CalendarController();
            bool expected = true;
            bool actual;
            actual = target.CreateNewCalendar();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AlterCalendarInformationTest()
        {
            CalendarController target = new CalendarController();
            bool expected = true;
            bool actual;
            actual = target.AlterCalendarInformation();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddNewUsersToCalendarTest()
        {
            CalendarController target = new CalendarController();
            bool expected = true;
            bool actual;
            actual = target.AddNewUsersToCalendar();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddEventToCalendarTest()
        {
            CalendarController target = new CalendarController();
            bool expected = true;
            bool actual;
            actual = target.AddEventToCalendar();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CalendarController Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Lauren\\Documents\\GitHub\\SWENG500_Team1\\ProjectManager\\ProjectManagerWeb", "/")]
        [UrlToTest("http://localhost:19961/")]
        public void CalendarControllerConstructorTest()
        {
            CalendarController target = new CalendarController();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for AddEventToCalendar
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Lauren\\Documents\\GitHub\\SWENG500_Team1\\ProjectManager\\ProjectManagerWeb", "/")]
        [UrlToTest("http://localhost:19961/")]
        public void AddEventToCalendarTest1()
        {
            CalendarController target = new CalendarController(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.AddEventToCalendar();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddNewUsersToCalendar
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Lauren\\Documents\\GitHub\\SWENG500_Team1\\ProjectManager\\ProjectManagerWeb", "/")]
        [UrlToTest("http://localhost:19961/")]
        public void AddNewUsersToCalendarTest1()
        {
            CalendarController target = new CalendarController(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.AddNewUsersToCalendar();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AlterCalendarInformation
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Lauren\\Documents\\GitHub\\SWENG500_Team1\\ProjectManager\\ProjectManagerWeb", "/")]
        [UrlToTest("http://localhost:19961/")]
        public void AlterCalendarInformationTest1()
        {
            CalendarController target = new CalendarController(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.AlterCalendarInformation();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CreateNewCalendar
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Lauren\\Documents\\GitHub\\SWENG500_Team1\\ProjectManager\\ProjectManagerWeb", "/")]
        [UrlToTest("http://localhost:19961/")]
        public void CreateNewCalendarTest1()
        {
            CalendarController target = new CalendarController(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.CreateNewCalendar();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DeleteEventFromCalendar
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Lauren\\Documents\\GitHub\\SWENG500_Team1\\ProjectManager\\ProjectManagerWeb", "/")]
        [UrlToTest("http://localhost:19961/")]
        public void DeleteEventFromCalendarTest1()
        {
            CalendarController target = new CalendarController(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.DeleteEventFromCalendar();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DeleteExistingCalendar
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Lauren\\Documents\\GitHub\\SWENG500_Team1\\ProjectManager\\ProjectManagerWeb", "/")]
        [UrlToTest("http://localhost:19961/")]
        public void DeleteExistingCalendarTest1()
        {
            CalendarController target = new CalendarController(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.DeleteExistingCalendar();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DeleteUsersFromCalendar
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Lauren\\Documents\\GitHub\\SWENG500_Team1\\ProjectManager\\ProjectManagerWeb", "/")]
        [UrlToTest("http://localhost:19961/")]
        public void DeleteUsersFromCalendarTest1()
        {
            CalendarController target = new CalendarController(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.DeleteUsersFromCalendar();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
