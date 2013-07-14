using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ProjectManagerLibrary.Models.Reports;
using ProjectManagerLibrary.Models;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagerTest
{
    
    
    /// <summary>
    ///This is a test class for ProjectSummaryTest and is intended
    ///to contain all ProjectSummaryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProjectSummaryTest
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
        ///A test for Display
        ///</summary>
        [TestMethod()]
        public void DisplayTest()
        {
            ProjectSummary target = new ProjectSummary();
            Project project = new Project(0, "Name", DateTime.Now, DateTime.Now, "", "", "", DateTime.Now);
            Control control = target.Display(project, new DateRange(DateTime.Now, DateTime.Now));
            Assert.IsInstanceOfType(control, typeof(Table));
            Table table = control as Table;
            Assert.AreEqual(4, table.Rows.Count);
        }

        /// <summary>
        ///A test for DataTitle
        ///</summary>
        [TestMethod()]
        public void DataTitleTest()
        {
            ProjectSummary target = new ProjectSummary();
            Assert.AreEqual(target.DataTitle, "Summary");
        }

        /// <summary>
        ///A test for RequiresDateRange
        ///</summary>
        [TestMethod()]
        public void RequiresDateRangeTest()
        {
            ProjectSummary target = new ProjectSummary();
            Assert.AreEqual(target.RequiresDateRange, false);
        }

        /// <summary>
        ///A test for CurrentDateRange
        ///</summary>
        [TestMethod()]
        public void CurrentDateRangeTest()
        {
            ProjectSummary target = new ProjectSummary();
            DateRange actual = target.CurrentDateRange;
            Assert.IsNotNull(target.CurrentDateRange);
            Assert.IsTrue(actual.StartTime.AddSeconds(2).CompareTo(DateTime.Now) > 0);
            Assert.IsTrue(actual.FinishTime.AddSeconds(2).CompareTo(DateTime.Now) > 0);
        }
    }
}
