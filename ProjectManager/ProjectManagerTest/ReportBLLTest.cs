using ProjectManagerBLL.Report;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ProjectManagerLibrary.Models.Graphs;
using ProjectManagerLibrary.Models.Reports;
using System.Linq;

namespace ProjectManagerTest
{
    
    
    /// <summary>
    ///This is a test class for ReportBLLTest and is intended
    ///to contain all ReportBLLTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ReportBLLTest
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
        ///A test for ReportTypes
        ///</summary>
        [TestMethod()]
        public void ReportTypesTest()
        {
            List<Type> actual = ReportBLL.ReportTypes();
            Assert.AreEqual(actual.Count, 2);
            Assert.IsTrue(actual.Contains(typeof(ProjectManagerLibrary.Models.Graphs.OpenVsResolvedGraph)));
            Assert.IsTrue(actual.Contains(typeof(ProjectManagerLibrary.Models.Reports.ProjectSummary)));
        }

        /// <summary>
        ///A test for OrderReportTypes
        ///</summary>
        [TestMethod()]
        public void OrderReportTypesTest()
        {
            List<Type> availableReports = new List<Type>(new Type[] { typeof(OpenVsResolvedGraph) });
            List<Type> expected = new List<Type>(new Type[] { typeof(OpenVsResolvedGraph) });
            List<Type> actual = ReportBLL.OrderReportTypes(availableReports);
            Assert.IsTrue(Enumerable.SequenceEqual(expected, actual));

            availableReports = new List<Type>(new Type[] { typeof(ProjectSummary) });
            expected = new List<Type>(new Type[] { typeof(ProjectSummary) });
            actual = ReportBLL.OrderReportTypes(availableReports);
            Assert.IsTrue(Enumerable.SequenceEqual(expected, actual));

            availableReports = new List<Type>(new Type[] { typeof(ProjectSummary), typeof(OpenVsResolvedGraph) });
            expected = new List<Type>(new Type[] { typeof(ProjectSummary), typeof(OpenVsResolvedGraph) });
            actual = ReportBLL.OrderReportTypes(availableReports);
            Assert.IsTrue(Enumerable.SequenceEqual(expected, actual));

            availableReports = new List<Type>(new Type[] { typeof(OpenVsResolvedGraph), typeof(ProjectSummary) });
            expected = new List<Type>(new Type[] { typeof(ProjectSummary), typeof(OpenVsResolvedGraph) });
            actual = ReportBLL.OrderReportTypes(availableReports);
            Assert.IsTrue(Enumerable.SequenceEqual(expected, actual));
        }
    }
}
