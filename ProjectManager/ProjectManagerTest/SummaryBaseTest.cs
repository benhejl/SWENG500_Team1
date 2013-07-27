using ProjectManagerLibrary.Models.Reports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.UI.WebControls;

namespace ProjectManagerTest
{
    
    
    /// <summary>
    ///This is a test class for SummaryBaseTest and is intended
    ///to contain all SummaryBaseTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SummaryBaseTest
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
        ///A test for CreateRow
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ProjectManagerLibrary.dll")]
        public void CreateRowTest()
        {
            SummaryBase_Accessor target = new IssuesByUser_Accessor();
            string description = "Description";
            string value = "Value";
            TableRow actual = target.CreateRow(description, value, true);
            Assert.AreEqual(2, actual.Cells.Count);
            Assert.AreEqual(description, actual.Cells[0].Text);
            Assert.AreEqual(value, actual.Cells[1].Text);
            Assert.AreEqual(true, actual.Cells[0].Font.Bold);
            Assert.AreEqual(true, actual.Cells[1].Font.Bold);

            actual = target.CreateRow(description, value, false);
            Assert.AreEqual(true, actual.Cells[0].Font.Bold);
            Assert.AreEqual(false, actual.Cells[1].Font.Bold);
        }
    }
}
