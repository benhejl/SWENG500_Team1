using ProjectManagerDAL.CalendarDAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;

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
            string users = "UnitTestUsers"; 
            string projectName = "UnitTestProject";
            bool expected = true;
            bool actual;
            actual = CalendarDAL.insertNewCalendar(calendarName, users, projectName);
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
            string projectName = "UnitTestProject";
            string users = "UnitTestUsers";
            bool expected = true;
            bool actual;
            actual = CalendarDAL.updateCalendar(currentName, newName, projectName, users);
            Assert.AreEqual(expected, actual);
        }
    }
}
