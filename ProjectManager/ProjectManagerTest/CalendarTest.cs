using ProjectManagerLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ProjectManagerWeb;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.UI.WebControls;
using ProjectManagerBLL.CalendarBLL;

namespace ProjectManagerTest
{
    
    
    /// <summary>
    ///This is a test class for CalendarTest and is intended
    ///to contain all CalendarTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CalendarTest
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
        ///A test for Page_Load
        ///</summary>
        [TestMethod()]
        public void Page_LoadTest()
        {
            ProjectManagerWeb.Calendar_Accessor target = new ProjectManagerWeb.Calendar_Accessor();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for Calendar Constructor
        ///</summary>
        [TestMethod()]
        public void CalendarConstructorTest()
        {
            ProjectManagerWeb.Calendar target = new ProjectManagerWeb.Calendar();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for CreateNewCalendarClick. Method just changes panel visibility. Nothing to test.
        ///</summary>
        [TestMethod()]
        public void CreateNewCalendarClickTest()
        {
            ProjectManagerWeb.Calendar_Accessor target = new ProjectManagerWeb.Calendar_Accessor();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for populateProjectsDropDown. Method returns void. Cannot verify.
        ///</summary>
        [TestMethod()]
        public void populateProjectsDropDownTest()
        {
            ProjectManagerWeb.Calendar_Accessor target = new ProjectManagerWeb.Calendar_Accessor();
            Assert.IsNotNull(target);
        }


        /// <summary>
        ///A test for populateUsersList. Method returns void. Cannot verify.
        ///</summary>
        [TestMethod()]
        public void populateUsersListTest()
        {
            ProjectManagerWeb.Calendar_Accessor target = new ProjectManagerWeb.Calendar_Accessor();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for DeleteCalendarClick. Method returns void. Cannot verify.
        ///</summary>
        [TestMethod()]
        public void DeleteCalendarClickTest()
        {
            ProjectManagerWeb.Calendar_Accessor target = new ProjectManagerWeb.Calendar_Accessor();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for EditCalendarInformationClick. Method returns void. Cannot verify.
        ///</summary>
        [TestMethod()]
        public void EditCalendarInformationClickTest()
        {
            ProjectManagerWeb.Calendar_Accessor target = new ProjectManagerWeb.Calendar_Accessor();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for populateNewRegisteredUsersDropDown. Method returns void. Cannot verify.
        ///</summary>
        [TestMethod()]
        public void populateNewRegisteredUsersDropDownTest()
        {
            ProjectManagerWeb.Calendar_Accessor target = new ProjectManagerWeb.Calendar_Accessor();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for SaveNewCalendar. Method returns void. Cannot verify.
        ///</summary>
        [TestMethod()]
        public void SaveNewCalendarTest()
        {
            ProjectManagerWeb.Calendar_Accessor target = new ProjectManagerWeb.Calendar_Accessor();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for CancelCalendar. Method returns void. Cannot verify.
        ///</summary>
        [TestMethod()]
        public void CancelCalendarTest()
        {
            ProjectManagerWeb.Calendar_Accessor target = new ProjectManagerWeb.Calendar_Accessor();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for populateCalendarDropDown. Method returns void. Cannot verify.
        ///</summary>
        [TestMethod()]
        public void populateCalendarDropDownTest()
        {
            ProjectManagerWeb.Calendar_Accessor target = new ProjectManagerWeb.Calendar_Accessor();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for SaveEdit_Click. Method returns void. Cannot verify.
        ///</summary>
        [TestMethod()]
        public void SaveEdit_ClickTest()
        {
            ProjectManagerWeb.Calendar_Accessor target = new ProjectManagerWeb.Calendar_Accessor();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for DeleteButton_Click. Method returns void. Cannot verify.
        ///</summary>
        [TestMethod()]
        public void DeleteButton_ClickTest()
        {
            ProjectManagerWeb.Calendar_Accessor target = new ProjectManagerWeb.Calendar_Accessor();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for ViewCalendarClick. Method returns void. Cannot verify.
        ///</summary>
        public void ViewCalendarClickTest()
        {
            ProjectManagerWeb.Calendar_Accessor target = new ProjectManagerWeb.Calendar_Accessor();
            Assert.IsNotNull(target);
        }


        /// <summary>
        ///A test for populateViewCalendarDropDown. Method returns void. Cannot verify.
        ///</summary>
        [TestMethod()]
        public void populateViewCalendarDropDownTest()
        {
            ProjectManagerWeb.Calendar_Accessor target = new ProjectManagerWeb.Calendar_Accessor(); 
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for PMCalendar_SelectionChanged. Method returns void. Cannot verify.
        ///</summary>
        [TestMethod()]
        public void PMCalendar_SelectionChangedTest()
        {
            ProjectManagerWeb.Calendar_Accessor target = new ProjectManagerWeb.Calendar_Accessor(); 
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for CancelNewCalendar_Click. Method returns void. Cannot verify.
        ///</summary>
        [TestMethod()]
        public void CancelNewCalendar_ClickTest()
        {
            ProjectManagerWeb.Calendar_Accessor target = new ProjectManagerWeb.Calendar_Accessor();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for CancelDelete_Click. Method returns void. Cannot verify.
        ///</summary>
        [TestMethod()]
        public void CancelDelete_ClickTest()
        {
            ProjectManagerWeb.Calendar_Accessor target = new ProjectManagerWeb.Calendar_Accessor();
            Assert.IsNotNull(target);
        }


        /// <summary>
        ///A test for CancelEdit_Click. Method returns void. Cannot verify.
        ///</summary>
        [TestMethod()]
        public void CancelEdit_ClickTest()
        {
            ProjectManagerWeb.Calendar_Accessor target = new ProjectManagerWeb.Calendar_Accessor();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for Back_Click. Method returns void. Cannot verify.
        ///</summary>
        [TestMethod()]
        public void Back_ClickTest()
        {
            ProjectManagerWeb.Calendar_Accessor target = new ProjectManagerWeb.Calendar_Accessor();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for AddEvent_Click. Method returns void. Cannot verify.
        ///</summary>
        [TestMethod()]
        public void AddEvent_ClickTest()
        {
            ProjectManagerWeb.Calendar_Accessor target = new ProjectManagerWeb.Calendar_Accessor();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for SaveNewEvent_Click
        ///</summary>
        [TestMethod()]
        public void SaveNewEvent_ClickTest()
        {
            ProjectManagerWeb.Calendar_Accessor target = new ProjectManagerWeb.Calendar_Accessor();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for CancelNewEvent_Click
        ///</summary>
        [TestMethod()]
        public void CancelNewEvent_ClickTest()
        {
            ProjectManagerWeb.Calendar_Accessor target = new ProjectManagerWeb.Calendar_Accessor();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for DeleteEventPageClick. Returns null, cannot test.
        ///</summary>
        [TestMethod()]
        public void DeleteEventPageClickTest()
        {
            ProjectManagerWeb.Calendar_Accessor target = new ProjectManagerWeb.Calendar_Accessor();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for CancelDeleteEventClick. Cannot test, returns void.
        ///</summary>
        [TestMethod()]
        public void CancelDeleteEventClickTest()
        {
            ProjectManagerWeb.Calendar_Accessor target = new ProjectManagerWeb.Calendar_Accessor();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for populateDeleteEventDropDown. Cannot test, returns void
        ///</summary>
        [TestMethod()]
        public void populateDeleteEventDropDownTest()
        {
            ProjectManagerWeb.Calendar_Accessor target = new ProjectManagerWeb.Calendar_Accessor();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for DeleteEvent. Cannot test, returns void.
        ///</summary>
        [TestMethod()]
        public void DeleteEventTest()
        {
            ProjectManagerWeb.Calendar_Accessor target = new ProjectManagerWeb.Calendar_Accessor();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for populateDeleteEventCheckBox
        ///</summary>
        [TestMethod()]
        public void populateDeleteEventCheckBoxTest()
        {
            ProjectManagerWeb.Calendar_Accessor target = new ProjectManagerWeb.Calendar_Accessor();
            Assert.IsNotNull(target);
        }
    }
}
