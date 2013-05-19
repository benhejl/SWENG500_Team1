using ProjectManagerLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProjectManagerTest
{
    
    
    /// <summary>
    ///This is a test class for TaskTest and is intended
    ///to contain all TaskTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TaskTest
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
        ///A test for Task Constructor
        ///</summary>
        [TestMethod()]
        public void TaskConstructorTest()
        {
            Task target = new Task();
            Assert.IsInstanceOfType(target, typeof(Task));
        }

        /// <summary>
        ///A test for CompletedOn
        ///</summary>
        [TestMethod()]
        public void CompletedOnTest()
        {
            Task target = new Task();
            DateTime expected = DateTime.MinValue;

            Assert.AreEqual(expected, target.CompletedOn);

            target.CompletedOn = DateTime.Now;
            target.CurrentStatus = Task.Status.Unscheduled;
            Assert.AreEqual(expected, target.CompletedOn);
            target.CurrentStatus = Task.Status.InProgress;
            Assert.AreEqual(expected, target.CompletedOn);
            target.CurrentStatus = Task.Status.Complete;
            Assert.AreNotEqual(expected, target.CompletedOn);
        }

        /// <summary>
        ///A test for Created
        ///</summary>
        [TestMethod()]
        public void CreatedTest()
        {
            Task target = new Task();
            target.Created = DateTime.Now;
            Assert.AreNotEqual(target.Created, DateTime.MinValue);
        }

        /// <summary>
        ///A test for Status
        ///</summary>
        [TestMethod()]
        public void StatusTest()
        {
            Task target = new Task(); // TODO: Initialize to an appropriate value
            Assert.Inconclusive("TODO: Determine how to test the status of a task.");
        }
    }
}
