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
    }
}
