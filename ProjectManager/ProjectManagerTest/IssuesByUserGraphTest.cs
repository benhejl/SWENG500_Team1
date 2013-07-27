using ProjectManagerLibrary.Models.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.UI.DataVisualization.Charting;
using ProjectManagerLibrary.Models;
using System.Web.UI;
using System.Collections.Generic;

namespace ProjectManagerTest
{
    
    
    /// <summary>
    ///This is a test class for IssuesByUserGraphTest and is intended
    ///to contain all IssuesByUserGraphTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IssuesByUserGraphTest
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
        ///A test for IssuesByUserGraph Constructor
        ///</summary>
        [TestMethod()]
        public void IssuesByUserGraphConstructorTest()
        {
            IssuesByUserGraph target = new IssuesByUserGraph();
            Assert.IsInstanceOfType(target, typeof(IssuesByUserGraph));
        }

        /// <summary>
        ///A test for CreateChartArea
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ProjectManagerLibrary.dll")]
        public void CreateChartAreaTest()
        {
            IssuesByUserGraph_Accessor target = new IssuesByUserGraph_Accessor(); // TODO: Initialize to an appropriate value
            ChartArea actual = target.CreateChartArea();
            Assert.AreEqual(true, actual.Area3DStyle.Enable3D);
        }

        /// <summary>
        ///A test for Display
        ///</summary>
        [TestMethod()]
        public void DisplayTest()
        {
            IssuesByUserGraph target = new IssuesByUserGraph();
            Project project = new Project(1, "Test", DateTime.Now, DateTime.Now.AddDays(1), "", "", "", DateTime.Now.AddDays(1));
            DateRange range = new DateRange(DateTime.Now.Subtract(TimeSpan.FromDays(10)), DateTime.Now);

            Control actual = target.Display(project, range);
            Assert.IsInstanceOfType(actual, typeof(Chart));

            Chart chart = actual as Chart;
            Assert.AreEqual(1, chart.Series.Count);
            Assert.AreEqual(0, chart.Series[0].Points.Count);
            Assert.AreEqual(1, chart.Legends.Count);
            Assert.AreEqual(1, chart.Titles.Count);
        }

        /// <summary>
        ///A test for EvaluateProject
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ProjectManagerLibrary.dll")]
        public void EvaluateProjectTest()
        {
            IssuesByUserGraph_Accessor target = new IssuesByUserGraph_Accessor(); // TODO: Initialize to an appropriate value
            Project project = new Project(1, "Test", DateTime.Now, DateTime.Now.AddDays(1), "", "", "", DateTime.Now.AddDays(1));
            DateRange range = new DateRange(DateTime.Now, DateTime.Now);
            List<Series> actual = target.EvaluateProject(project, range);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual(0, actual[0].Points.Count);
        }

        /// <summary>
        ///A test for CurrentDateRange
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ProjectManagerLibrary.dll")]
        public void CurrentDateRangeTest()
        {
            IssuesByUserGraph_Accessor target = new IssuesByUserGraph_Accessor();
            Assert.AreEqual(DateTime.MinValue, target.CurrentDateRange.StartTime);
            Assert.AreEqual(DateTime.MaxValue, target.CurrentDateRange.FinishTime);
        }

        /// <summary>
        ///A test for DataTitle
        ///</summary>
        [TestMethod()]
        public void DataTitleTest()
        {
            IssuesByUserGraph target = new IssuesByUserGraph();
            Assert.AreEqual("Issues By User", target.DataTitle);
        }

        /// <summary>
        ///A test for RequiresDateRange
        ///</summary>
        [TestMethod()]
        public void RequiresDateRangeTest()
        {
            IssuesByUserGraph target = new IssuesByUserGraph();
            Assert.AreEqual(false, target.RequiresDateRange);
        }

        /// <summary>
        ///A test for SortOrder
        ///</summary>
        [TestMethod()]
        public void SortOrderTest()
        {
            IssuesByUserGraph target = new IssuesByUserGraph();
            Assert.AreEqual(1, target.SortOrder);
        }
    }
}
