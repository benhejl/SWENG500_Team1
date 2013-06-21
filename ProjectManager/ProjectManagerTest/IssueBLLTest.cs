using ProjectManagerBLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ProjectManagerLibrary.Models;

namespace ProjectManagerTest
{
    
    
    /// <summary>
    ///This is a test class for IssueBLLTest and is intended
    ///to contain all IssueBLLTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IssueBLLTest
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
        ///A test for AddIssue
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void AddIssueTest()
        {
            Issue issue = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = IssueBLL.AddIssue(issue);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetIssue
        ///</summary>
        [TestMethod()]
        public void GetIssueTest()
        {
            int issueID = 4; // TODO: Initialize to an appropriate value
            //Issue expected = null; // TODO: Initialize to an appropriate value
            Issue actual;
            actual = IssueBLL.GetIssue(issueID);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for EditIssue
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void EditIssueTest()
        {
            Issue issue = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = IssueBLL.EditIssue(issue);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }


    }
}
