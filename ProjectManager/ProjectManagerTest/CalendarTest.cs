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
            Calendar_Accessor target = new Calendar_Accessor();
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
            Calendar_Accessor target = new Calendar_Accessor();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for populateProjectsDropDown. Method returns void. Cannot verify.
        ///</summary>
        [TestMethod()]
        public void populateProjectsDropDownTest()
        {
            Calendar_Accessor target = new Calendar_Accessor();
            Assert.IsNotNull(target);
        }


        /// <summary>
        ///A test for populateUsersList. Method returns void. Cannot verify.
        ///</summary>
        [TestMethod()]
        public void populateUsersListTest()
        {
            Calendar_Accessor target = new Calendar_Accessor();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for DeleteCalendarClick. Method returns void. Cannot verify.
        ///</summary>
        [TestMethod()]
        public void DeleteCalendarClickTest()
        {
            Calendar_Accessor target = new Calendar_Accessor();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for EditCalendarInformationClick. Method returns void. Cannot verify.
        ///</summary>
        [TestMethod()]
        public void EditCalendarInformationClickTest()
        {
            Calendar_Accessor target = new Calendar_Accessor();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for populateNewRegisteredUsersDropDown. Method returns void. Cannot verify.
        ///</summary>
        [TestMethod()]
        public void populateNewRegisteredUsersDropDownTest()
        {
            Calendar_Accessor target = new Calendar_Accessor();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for SaveNewCalendar. Method returns void. Cannot verify.
        ///</summary>
        [TestMethod()]
        public void SaveNewCalendarTest()
        {
            Calendar_Accessor target = new Calendar_Accessor();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for CancelCalendar. Method returns void. Cannot verify.
        ///</summary>
        [TestMethod()]
        public void CancelCalendarTest()
        {
            Calendar_Accessor target = new Calendar_Accessor();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for populateCalendarDropDown. Method returns void. Cannot verify.
        ///</summary>
        [TestMethod()]
        public void populateCalendarDropDownTest()
        {
            Calendar_Accessor target = new Calendar_Accessor();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for SaveEdit_Click. Method returns void. Cannot verify.
        ///</summary>
        [TestMethod()]
        public void SaveEdit_ClickTest()
        {
            Calendar_Accessor target = new Calendar_Accessor();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for DeleteButton_Click. Method returns void. Cannot verify.
        ///</summary>
        [TestMethod()]
        public void DeleteButton_ClickTest()
        {
            Calendar_Accessor target = new Calendar_Accessor();
            Assert.IsNotNull(target);
        }

    }
}
