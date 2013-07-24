using ProjectManagerBLL.CalendarBLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using ProjectManagerLibrary.Models;

namespace ProjectManagerTest
{
    
    /// <summary>
    ///This is a test class for CalendarBLLTest and is intended
    ///to contain all CalendarBLLTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CalendarBLLTest
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
        ///A test for CalendarBLL Constructor
        ///</summary>
        [TestMethod()]
        public void CalendarBLLConstructorTest()
        {
            CalendarBLL target = new CalendarBLL();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for createCalendar
        ///</summary>
        [TestMethod()]
        public void createCalendarTest()
        {
            CalendarBLL target = new CalendarBLL();
            string name = "UnitTestName";
            bool expected = true;
            bool actual;
            actual = target.createCalendar(name);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for deleteCalendar
        ///</summary>
        [TestMethod()]
        public void deleteCalendarTest()
        {
            CalendarBLL target = new CalendarBLL();
            string calendarToDelete = "UnitTestName";
            bool expected = true;
            bool actual;
            actual = target.deleteCalendar(calendarToDelete);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for getCalendars
        ///</summary>
        [TestMethod()]
        public void getCalendarsTest()
        {
            CalendarBLL target = new CalendarBLL();
            ArrayList actual;
            actual = target.getCalendars();
            Assert.IsNotNull(actual);
        }

        /*/// <summary>
        ///A test for getProjectNames
        ///</summary>
        [TestMethod()]
        public void getProjectNamesTest()
        {
            CalendarBLL target = new CalendarBLL();
            ArrayList actual;
            actual = target.getProjectNames();
            Assert.IsNotNull(actual);
        }*/

        /// <summary>
        ///A test for getUsers
        ///</summary>
        [TestMethod()]
        public void getUsersTest()
        {
            CalendarBLL target = new CalendarBLL();
            ArrayList actual;
            actual = target.getUsers(); 
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for updateCalendarInfo
        ///</summary>
        [TestMethod()]
        public void updateCalendarInfoTest()
        {
            CalendarBLL target = new CalendarBLL();
            string currentName = "UnitTestName";
            string newName = "UnitTestChangeName";
            bool expected = true;
            bool actual;
            actual = target.updateCalendarInfo(currentName, newName);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for deleteEventsByCalendarId
        ///</summary>
        [TestMethod()]
        public void deleteEventsByCalendarIdTest()
        {
            CalendarBLL target = new CalendarBLL(); 
            int calendarToDelete = 1;
            bool expected = true;
            bool actual;
            actual = target.deleteEventsByCalendarId(calendarToDelete);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for getEventsByDate
        ///</summary>
        [TestMethod()]
        public void getEventsByDateTest()
        {
            //UNCOMMENT ME
            /*CalendarBLL target = new CalendarBLL(); 
            ArrayList expected = new ArrayList(); 
            ArrayList actual;
            actual = target.getEventsByDate(DateTime.Now);
            Assert.AreEqual(expected.Count, actual.Count);*/
        }

        /// <summary>
        ///A test for getCalendarIdByName
        ///</summary>
        [TestMethod()]
        public void getCalendarIdByNameTest()
        {
            CalendarBLL target = new CalendarBLL();
            string calendarName = "UnitTestName";
            int expected = 1; 
            int actual;
            actual = target.getCalendarIdByName(calendarName);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for getCalendarByName
        ///</summary>
        [TestMethod()]
        public void getCalendarByNameTest()
        {
            CalendarBLL target = new CalendarBLL();
            string calendarName = "UnitTestName";
            Calendar actual;
            actual = target.getCalendarByName(calendarName);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for addCalendarEvent
        ///</summary>
        [TestMethod()]
        public void addCalendarEventTest()
        {
            CalendarBLL target = new CalendarBLL();
            CalendarEvent e = new CalendarEvent(1, "EventName", DateTime.Now, DateTime.Now, 1, "Test Type");
            bool expected = true;
            bool actual;
            actual = target.addCalendarEvent(e);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for getCalendarEvents
        ///</summary>
        [TestMethod()]
        public void getCalendarEventsTest()
        {
            CalendarBLL target = new CalendarBLL(); // TODO: Initialize to an appropriate value
            int calendarId = 0; // TODO: Initialize to an appropriate value
            ArrayList expected = null; // TODO: Initialize to an appropriate value
            ArrayList actual;
            actual = target.getCalendarEvents(calendarId);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for deleteEventsByName
        ///</summary>
        [TestMethod()]
        public void deleteEventsByNameTest()
        {
            CalendarBLL target = new CalendarBLL(); // TODO: Initialize to an appropriate value
            string eventName = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.deleteEventsByName(eventName);
            Assert.AreEqual(expected, actual);
        }
    }
}
