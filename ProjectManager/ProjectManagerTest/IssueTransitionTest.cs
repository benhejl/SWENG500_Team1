using ProjectManagerLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProjectManagerTest
{
    
    
    /// <summary>
    ///This is a test class for IssueTransitionTest and is intended
    ///to contain all IssueTransitionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IssueTransitionTest
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

        const Issue.IssueStatus TestStatus = Issue.IssueStatus.Resolved;
        DateTime TestTranstionTimestamp = DateTime.Parse("1/1/2001 12:00 PM");
        const string TestComment = "Hello, world";

        private IssueTransition DefaultTestTranstion()
        {
            return new IssueTransition(TestStatus, TestTranstionTimestamp, TestComment);
        }


        /// <summary>
        ///A test for IssueTransition Constructor
        ///</summary>
        [TestMethod()]
        public void IssueTransitionConstructorTest()
        {
            IssueTransition target = DefaultTestTranstion();
            Assert.IsInstanceOfType(target, typeof(IssueTransition));

            target = new IssueTransition(TestStatus, TestTranstionTimestamp, null);
            Assert.IsInstanceOfType(target, typeof(IssueTransition));
        }

        /// <summary>
        ///A test for Comments
        ///</summary>
        [TestMethod()]
        public void CommentsTest()
        {
            IssueTransition target = DefaultTestTranstion();
            Assert.AreEqual(target.Comments, TestComment);

            target = new IssueTransition(TestStatus, TestTranstionTimestamp, null);
            Assert.AreEqual(target.Comments, string.Empty);
        }

        /// <summary>
        ///A test for OccurredOn
        ///</summary>
        [TestMethod()]
        public void OccurredOnTest()
        {
            IssueTransition target = DefaultTestTranstion();
            Assert.AreEqual(target.OccurredOn, TestTranstionTimestamp);
        }

        /// <summary>
        ///A test for Status
        ///</summary>
        [TestMethod()]
        public void StatusTest()
        {
            IssueTransition target = DefaultTestTranstion();
            Assert.AreEqual(target.Status, TestStatus);
        }
    }
}
