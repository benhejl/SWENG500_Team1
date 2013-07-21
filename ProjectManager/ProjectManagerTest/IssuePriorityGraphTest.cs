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
    ///This is a test class for IssuePriorityGraphTest and is intended
    ///to contain all IssuePriorityGraphTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IssuePriorityGraphTest
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
        ///A test for IssuePriorityGraph Constructor
        ///</summary>
        [TestMethod()]
        public void IssuePriorityGraphConstructorTest()
        {
            IssuePriorityGraph target = new IssuePriorityGraph();
            Assert.IsInstanceOfType(target, typeof(IssuePriorityGraph));
        }

        /// <summary>
        ///A test for CreateChartArea
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ProjectManagerLibrary.dll")]
        public void CreateChartAreaTest()
        {
            IssuePriorityGraph_Accessor target = new IssuePriorityGraph_Accessor(); // TODO: Initialize to an appropriate value
            ChartArea actual = target.CreateChartArea();
            Assert.AreEqual(true, actual.Area3DStyle.Enable3D);
        }

        /// <summary>
        ///A test for Display
        ///</summary>
        [TestMethod()]
        public void DisplayTest()
        {
            IssuePriorityGraph target = new IssuePriorityGraph(); // TODO: Initialize to an appropriate value
            Project project = BuildDefaultProject();
            DateRange range = new DateRange(DateTime.Now.Subtract(TimeSpan.FromDays(10)), DateTime.Now);
            AddIssues(project, 8, 2, 0);

            Control actual = target.Display(project, range);
            Assert.IsInstanceOfType(actual, typeof(Chart));

            Chart chart = actual as Chart;
            Assert.AreEqual(1, chart.Series.Count);
            Assert.AreEqual(3, chart.Series[0].Points.Count);
            Assert.AreEqual(8, chart.Series[0].Points[0].YValues[0]);
            Assert.AreEqual(2, chart.Series[0].Points[1].YValues[0]);
            Assert.AreEqual(0, chart.Series[0].Points[2].YValues[0]);
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
            IssuePriorityGraph_Accessor target = new IssuePriorityGraph_Accessor();
            Project project = BuildDefaultProject();
            DateRange range = new DateRange(DateTime.Now, DateTime.Now);
            List<Series> actual = target.EvaluateProject(project, range);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual(3, actual[0].Points.Count);
            Assert.AreEqual(0, actual[0].Points[0].YValues[0]);
            Assert.AreEqual(0, actual[0].Points[1].YValues[0]);
            Assert.AreEqual(0, actual[0].Points[1].YValues[0]);

            AddIssues(project, 3, 7, 2);
            actual = target.EvaluateProject(project, range);

            Assert.AreEqual(3, actual[0].Points[0].YValues[0]);
            Assert.AreEqual(7, actual[0].Points[1].YValues[0]);
            Assert.AreEqual(2, actual[0].Points[2].YValues[0]);
        }

        /// <summary>
        ///A test for CurrentDateRange
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ProjectManagerLibrary.dll")]
        public void CurrentDateRangeTest()
        {
            IssuePriorityGraph_Accessor target = new IssuePriorityGraph_Accessor();
            Assert.AreEqual(DateTime.MinValue, target.CurrentDateRange.StartTime);
            Assert.AreEqual(DateTime.MaxValue, target.CurrentDateRange.FinishTime);
        }

        /// <summary>
        ///A test for DataTitle
        ///</summary>
        [TestMethod()]
        public void DataTitleTest()
        {
            IssuePriorityGraph target = new IssuePriorityGraph();
            Assert.AreEqual("Issues By Priority", target.DataTitle);
        }

        /// <summary>
        ///A test for RequiresDateRange
        ///</summary>
        [TestMethod()]
        public void RequiresDateRangeTest()
        {
            IssuePriorityGraph target = new IssuePriorityGraph();
            Assert.AreEqual(false, target.RequiresDateRange);
        }

        /// <summary>
        ///A test for SortOrder
        ///</summary>
        [TestMethod()]
        public void SortOrderTest()
        {
            IssuePriorityGraph target = new IssuePriorityGraph();
            Assert.AreEqual(1, target.SortOrder);
        }

        private Project BuildDefaultProject()
        {
            return new Project(1, "Test", DateTime.Now, DateTime.Now, "Status", "Description", "Category", DateTime.Now);
        }

        private void AddIssues(Project project, int high, int medium, int low)
        {
            AddIssuePriorityCount(project, high, Issue.IssuePriority.High);
            AddIssuePriorityCount(project, medium, Issue.IssuePriority.Medium);
            AddIssuePriorityCount(project, low, Issue.IssuePriority.Low);
        }

        private static void AddIssuePriorityCount(Project project, int count, Issue.IssuePriority priority)
        {
            for (int i = 0; i < count; i++)
            {
                Issue issue = new Issue();
                issue.CurrentPriority = priority;
                project.AddIssue(issue);
            }
        }
    }
}
