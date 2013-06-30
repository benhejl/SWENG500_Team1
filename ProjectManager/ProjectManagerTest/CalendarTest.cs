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
        ///A test for Calendar Constructor
        ///</summary>
        [TestMethod()]
        public void CalendarConstructorTest()
        {
            ProjectManagerWeb.Calendar target = new ProjectManagerWeb.Calendar();
            Assert.IsInstanceOfType(target, typeof(ProjectManagerWeb.Calendar));
        }

        [TestMethod()]
        public void CancelCalendarTest()
        {
            Calendar_Accessor target = new Calendar_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.CancelCalendar(sender, e);
            Assert.IsNotNull(target);
        }
        
        [TestMethod()]
        public void CreateNewCalendarClickTest()
        {
            Calendar_Accessor target = new Calendar_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.CreateNewCalendarClick(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void DeleteButton_ClickTest()
        {
            Calendar_Accessor target = new Calendar_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.DeleteButton_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void DeleteCalendarClickTest()
        {
            Calendar_Accessor target = new Calendar_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.DeleteCalendarClick(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void EditCalendarInformationClickTest()
        {
            Calendar_Accessor target = new Calendar_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.EditCalendarInformationClick(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void Page_LoadTest()
        {
            Calendar_Accessor target = new Calendar_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.Page_Load(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void SaveEdit_ClickTest()
        {
            Calendar_Accessor target = new Calendar_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.SaveEdit_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void SaveNewCalendarTest()
        {
            Calendar_Accessor target = new Calendar_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.SaveNewCalendar(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void populateDropDownTest()
        {
            Calendar_Accessor target = new Calendar_Accessor(); // TODO: Initialize to an appropriate value
            DropDownList temp = new DropDownList();
            target.populateDropDown(temp);
            Assert.IsNotNull(temp.DataSource);
        }
        
        [TestMethod()]
        public void populateProjectsDropDownTest()
        {
            Calendar_Accessor target = new Calendar_Accessor(); // TODO: Initialize to an appropriate value
            target.populateProjectsDropDown();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void populateUsersListTest()
        {
            Calendar_Accessor target = new Calendar_Accessor(); // TODO: Initialize to an appropriate value
            target.populateUsersList();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
