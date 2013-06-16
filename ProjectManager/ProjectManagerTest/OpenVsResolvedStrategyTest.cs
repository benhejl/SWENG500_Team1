using ProjectManagerLibrary.Models.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ProjectManagerLibrary.Models;
using System.Web.UI.DataVisualization.Charting;
using System.Collections.Generic;

namespace ProjectManagerTest
{
    
    
    /// <summary>
    ///This is a test class for OpenVsResolvedStrategyTest and is intended
    ///to contain all OpenVsResolvedStrategyTest Unit Tests
    ///</summary>
    [TestClass()]
    public class OpenVsResolvedStrategyTest
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
            OpenVsResolvedStrategy target = new OpenVsResolvedStrategy();
            Project project = BuildDefaultProject();

            List<Series> results = target.EvaluateProject(project, new DateRange(DateTime.Now, DateTime.Now));

            Assert.IsNotNull(results);
            Assert.AreEqual(results.Count, 2);

            // TODO: Insert issues

            Assert.AreEqual(results[0].Points.Count, 5);
            Assert.AreEqual(results[1].Points.Count, 5);
        }


        /// <summary>
        /// Guarantee the evaluation throws if a project is invalid.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EvaluateProjectNullProjectTest()
        {
            OpenVsResolvedStrategy target = new OpenVsResolvedStrategy();
            target.EvaluateProject(null, null);
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EvaluateProjectNullRangeTest()
        {
            OpenVsResolvedStrategy target = new OpenVsResolvedStrategy();
            target.EvaluateProject(BuildDefaultProject(), null);
        }

        /// <summary>
        /// Validate the correctness of the expected chart title.
        ///</summary>
        [TestMethod()]
        public void DataTitleTest()
        {
            OpenVsResolvedStrategy target = new OpenVsResolvedStrategy(); // TODO: Initialize to an appropriate value
            string actual = target.DataTitle;
            Assert.AreEqual(actual, "Open vs. Resolved Defects");
        }
    }
}
