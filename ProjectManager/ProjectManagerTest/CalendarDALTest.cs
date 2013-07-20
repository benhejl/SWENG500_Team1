using ProjectManagerDAL.CalendarDAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using ProjectManagerLibrary.Models;

namespace ProjectManagerTest
{
    
    
    /// <summary>
    ///This is a test class for CalendarDALTest and is intended
    ///to contain all CalendarDALTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CalendarDALTest
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
        ///A test for deleteCalendar
        ///</summary>
        [TestMethod()]
        public void deleteCalendarTest()
        {
            string name = "UnitTestName";
            bool expected = true; 
            bool actual;
            actual = CalendarDAL.deleteCalendar(name);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for getCalendarNames
        ///</summary>
        [TestMethod()]
        public void getCalendarNamesTest()
        {
            ArrayList actual;
            actual = CalendarDAL.getCalendarNames();
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for insertNewCalendar
        ///</summary>
        [TestMethod()]
        public void insertNewCalendarTest()
        {
            string calendarName = "UnitTestName";
            int projectId = 1;
            bool expected = true;
            bool actual;
            actual = CalendarDAL.insertNewCalendar(calendarName, projectId);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for updateCalendar
        ///</summary>
        [TestMethod()]
        public void updateCalendarTest()
        {
            string currentName = "UnitTestName";
            string newName = "UnitTestChangeName";
            int projectId = 1;
            bool expected = true;
            bool actual;
            actual = CalendarDAL.updateCalendar(currentName, newName, projectId);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for deleteEventsByCalendarId
        ///</summary>
        [TestMethod()]
        public void deleteEventsByCalendarIdTest()
        {
            int calendarId = 1;
            bool expected = true;
            bool actual;
            actual = CalendarDAL.deleteEventsByCalendarId(calendarId);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for getCalendarIdByName
        ///</summary>
        [TestMethod()]
        public void getCalendarIdByNameTest()
        {
            string calendarName = "UnitTestName";
            int expected = 1;
            int actual;
            actual = CalendarDAL.getCalendarIdByName(calendarName);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for getEvents
        ///</summary>
        [TestMethod()]
        public void getEventsTest()
        {
            ArrayList expected = new ArrayList();
            ArrayList actual;
            actual = CalendarDAL.getEvents();
            Assert.AreEqual(expected.Count, actual.Count);
        }

        /// <summary>
        ///A test for addNewEvent
        ///</summary>
        [TestMethod()]
        public void addNewEventTest()
        {
            CalendarEvent e = new CalendarEvent(1, "EventTest", DateTime.Now, DateTime.Now, 1, "Test Type");
            bool expected = true;
            bool actual;
            actual = CalendarDAL.addNewEvent(e);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for getCalendarByName
        ///</summary>
        [TestMethod()]
        public void getCalendarByNameTest()
        {
            string calendarName = "UnitTestName";
            ProjectManagerLibrary.Models.Calendar actual = CalendarDAL.getCalendarByName(calendarName);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for deleteEventsByName
        ///</summary>
        [TestMethod()]
        public void deleteEventsByNameTest()
        {
            string eventName = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = CalendarDAL.deleteEventsByName(eventName);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
