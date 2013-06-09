using ProjectManagerBLL.Calendar;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
        ///A test for DeleteUsers
        ///</summary>
        [TestMethod()]
        public void DeleteUsersTest()
        {
            CalendarBLL target = new CalendarBLL();
            bool expected = true;
            bool actual;
            actual = target.DeleteUsers();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CreateNewCalendar
        ///</summary>
        [TestMethod()]
        public void CreateNewCalendarTest()
        {
            CalendarBLL target = new CalendarBLL();
            bool expected = true;
            bool actual;
            actual = target.CreateNewCalendar();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for AddEvent
        ///</summary>
        [TestMethod()]
        public void AddEventTest()
        {
            CalendarBLL target = new CalendarBLL();
            bool expected = true;
            bool actual;
            actual = target.AddEvent();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for AddUsers
        ///</summary>
        [TestMethod()]
        public void AddUsersTest()
        {
            CalendarBLL target = new CalendarBLL();
            bool expected = true;
            bool actual;
            actual = target.AddUsers();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for AlterCalendarInfo
        ///</summary>
        [TestMethod()]
        public void AlterCalendarInfoTest()
        {
            CalendarBLL target = new CalendarBLL();
            bool expected = true;
            bool actual;
            actual = target.AlterCalendarInfo();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for DeleteEvent
        ///</summary>
        [TestMethod()]
        public void DeleteEventTest()
        {
            CalendarBLL target = new CalendarBLL();
            bool expected = true;
            bool actual;
            actual = target.DeleteEvent();
            Assert.AreEqual(expected, actual);
        }

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
        ///A test for DeleteExistingCalendar
        ///</summary>
        [TestMethod()]
        public void DeleteExistingCalendarTest()
        {
            CalendarBLL target = new CalendarBLL();
            bool expected = true;
            bool actual;
            actual = target.DeleteExistingCalendar();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ViewEvent
        ///</summary>
        [TestMethod()]
        public void ViewEventTest()
        {
            CalendarBLL target = new CalendarBLL();
            bool expected = true;
            bool actual;
            actual = target.ViewEvent();
            Assert.AreEqual(expected, actual);
        }
    }
}
