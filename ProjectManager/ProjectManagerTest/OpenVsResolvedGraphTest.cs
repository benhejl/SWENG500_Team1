using ProjectManagerLibrary.Models.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ProjectManagerLibrary.Models;
using System.Web.UI.DataVisualization.Charting;
using System.Collections.Generic;
using System.Web.UI;

namespace ProjectManagerTest
{
    
    
    /// <summary>
    ///This is a test class for OpenVsResolvedStrategyTest and is intended
    ///to contain all OpenVsResolvedStrategyTest Unit Tests
    ///</summary>
    [TestClass()]
    public class OpenVsResolvedGraphTest
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


        private Project BuildDefaultProject()
        {
            return new Project(1, "Test", DateTime.Now, DateTime.Now, "Status", "Description", "Category", DateTime.Now);
        }


        /// <summary>
        ///A test for EvaluateProject
        ///</summary>
        [TestMethod()]
        public void EvaluateProjectTest()
        {
            OpenVsResolvedGraph_Accessor target = new OpenVsResolvedGraph_Accessor();
            Project project = BuildDefaultProject();

            List<Series> results = target.EvaluateProject(project, new DateRange(DateTime.Now, DateTime.Now));
            Assert.IsNotNull(results);
            Assert.AreEqual(results.Count, 2);
            Assert.AreEqual(1, results[0].Points.Count);
            Assert.AreEqual(0, results[0].Points[0].YValues[0]);
            Assert.AreEqual(1, results[1].Points.Count);
            Assert.AreEqual(0, results[1].Points[0].YValues[0]);

            AddIssues(project, 3, 2);

            results = target.EvaluateProject(project, new DateRange(DateTime.Now, DateTime.Now));

            Assert.IsNotNull(results);
            Assert.AreEqual(results.Count, 2);
            Assert.AreEqual(1, results[0].Points.Count);
            Assert.AreEqual(2, results[0].Points[0].YValues[0]);
            Assert.AreEqual(1, results[1].Points.Count);
            Assert.AreEqual(3, results[1].Points[0].YValues[0]);
        }

        private static void AddIssues(Project project, int resolved, int unresolved)
        {
            Issue issue;
            for (int i = 0; i < resolved; i++)
            {
                issue = new Issue();
                issue.CurrentStatus = Issue.IssueStatus.Resolved;
                project.Issues.Add(issue);
            }
            for (int i = 0; i < unresolved; i++)
            {
                issue = new Issue();
                issue.CurrentStatus = Issue.IssueStatus.Unresolved;
                project.Issues.Add(issue);
            }
        }


        /// <summary>
        /// Guarantee the evaluation throws if a project is invalid.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EvaluateProjectNullProjectTest()
        {
            OpenVsResolvedGraph_Accessor target = new OpenVsResolvedGraph_Accessor();
            target.EvaluateProject(null, null);
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EvaluateProjectNullRangeTest()
        {
            OpenVsResolvedGraph_Accessor target = new OpenVsResolvedGraph_Accessor();
            target.EvaluateProject(BuildDefaultProject(), null);
        }

        /// <summary>
        /// Validate the correctness of the expected chart title.
        ///</summary>
        [TestMethod()]
        public void DataTitleTest()
        {
            OpenVsResolvedGraph target = new OpenVsResolvedGraph(); // TODO: Initialize to an appropriate value
            string actual = target.DataTitle;
            Assert.AreEqual(actual, "Open vs. Resolved Issues");
        }

        /// <summary>
        ///A test for Display
        ///</summary>
        [TestMethod()]
        public void DisplayTest()
        {
            OpenVsResolvedGraph target = new OpenVsResolvedGraph(); // TODO: Initialize to an appropriate value
            Project project = BuildDefaultProject();
            AddIssues(project, 5, 1);
            DateRange range = new DateRange(DateTime.Now.Subtract(TimeSpan.FromDays(10)), DateTime.Now);
            Control actual = target.Display(project, range);

            Assert.IsInstanceOfType(actual, typeof(Chart));

            Chart chart = actual as Chart;
            Assert.AreEqual(2, chart.Series.Count);
            Assert.AreEqual(1, chart.Series[0].Points.Count);
            Assert.AreEqual(1, chart.Series[0].Points[0].YValues[0]);
            Assert.AreEqual(1, chart.Series[1].Points.Count);
            Assert.AreEqual(5, chart.Series[1].Points[0].YValues[0]);
            Assert.AreEqual(1, chart.Legends.Count);
            Assert.AreEqual(1, chart.Titles.Count);
        }

        /// <summary>
        ///A test for RequiresDateRange
        ///</summary>
        [TestMethod()]
        public void RequiresDateRangeTest()
        {
            OpenVsResolvedGraph target = new OpenVsResolvedGraph(); // TODO: Initialize to an appropriate value
            Assert.AreEqual(false, target.RequiresDateRange);
        }

        /// <summary>
        ///A test for CurrentDateRange
        ///</summary>
        [TestMethod()]
        public void CurrentDateRangeTest()
        {
            OpenVsResolvedGraph_Accessor target = new OpenVsResolvedGraph_Accessor(); // TODO: Initialize to an appropriate value
            DateRange actual;
            actual = target.CurrentDateRange;
            Assert.IsNotNull(target.CurrentDateRange);

            DateTime start = DateTime.Parse("1/1/2013");
            DateTime finish = DateTime.Parse("2/1/2013");

            target.EvaluateProject(new Project(1, " ", start, finish, "", "", "", finish), new DateRange(start, finish));
            actual = target.CurrentDateRange;
            Assert.AreEqual(DateTime.MinValue, actual.StartTime);
            Assert.AreEqual(DateTime.MaxValue, actual.FinishTime);
        }

        /// <summary>
        ///A test for SortOrder
        ///</summary>
        [TestMethod()]
        public void SortOrderTest()
        {
            OpenVsResolvedGraph target = new OpenVsResolvedGraph();
            Assert.AreEqual(1, target.SortOrder);
        }

        /// <summary>
        ///A test for ConfigureAxis
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ProjectManagerLibrary.dll")]
        public void ConfigureAxisTest()
        {
            OpenVsResolvedGraph_Accessor target = new OpenVsResolvedGraph_Accessor(); // TODO: Initialize to an appropriate value
            Axis axis = new Axis();
            target.ConfigureAxis(axis);
            Assert.AreEqual(System.Drawing.Color.LightGray, axis.LineColor);
            Assert.AreEqual(System.Drawing.Color.LightGray, axis.MajorTickMark.LineColor);
            Assert.AreEqual(System.Drawing.Color.LightGray, axis.MinorTickMark.LineColor);
            Assert.IsFalse(axis.MinorGrid.Enabled);
            Assert.IsFalse(axis.MinorGrid.Enabled);
        }
    }
}
