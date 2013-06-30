using ProjectManagerBLL.CalendarBLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;

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
        ///A test for createCalendar
        ///</summary>
        [TestMethod()]
        public void createCalendarTest()
        {
            CalendarBLL target = new CalendarBLL(); // TODO: Initialize to an appropriate value
            Assert.IsTrue(target.createCalendar("Test Calendar"));
        }

        /// <summary>
        ///A test for getCalendars
        ///</summary>
        [TestMethod()]
        public void getCalendarsTest()
        {
            CalendarBLL target = new CalendarBLL(); // TODO: Initialize to an appropriate value
            DataRowCollection expected = null; // TODO: Initialize to an appropriate value
            DataRowCollection actual;
            actual = target.getCalendars();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for updateCalendarInfo
        ///</summary>
        [TestMethod()]
        public void updateCalendarInfoTest()
        {
            CalendarBLL target = new CalendarBLL(); // TODO: Initialize to an appropriate value
            string currentName = "ZXC"; // TODO: Initialize to an appropriate value
            string newName = "ASD"; // TODO: Initialize to an appropriate value
            target.updateCalendarInfo(currentName, newName);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for deleteCalendar
        ///</summary>
        [TestMethod()]
        public void deleteCalendarTest()
        {
            CalendarBLL target = new CalendarBLL(); // TODO: Initialize to an appropriate value
            string calendarToDelete = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.deleteCalendar(calendarToDelete);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for getCalendarData
        ///</summary>
        [TestMethod()]
        public void getCalendarDataTest()
        {
            CalendarBLL target = new CalendarBLL(); // TODO: Initialize to an appropriate value
            string calendarName = string.Empty; // TODO: Initialize to an appropriate value
            DataRowCollection expected = null; // TODO: Initialize to an appropriate value
            DataRowCollection actual;
            actual = target.getCalendarData(calendarName);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
