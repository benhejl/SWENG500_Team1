using ProjectManagerLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProjectManagerTest
{
    
    
    /// <summary>
    ///This is a test class for DateRangeTest and is intended
    ///to contain all DateRangeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DateRangeTest
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
        ///A test for DateRange Constructor
        ///</summary>
        [TestMethod()]
        public void DateRangeConstructorTest()
        {
            DateTime start = new DateTime(2013, 5, 18);
            DateTime finish = new DateTime(2013, 5, 19);
            DateRange target = new DateRange(start, finish);
            Assert.IsInstanceOfType(target, typeof(DateRange));
            Assert.Equals(target.StartTime, start);
            Assert.Equals(target.FinishTime, finish);
        }

        /// <summary>
        /// A test for creating an invalid DateRange
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidDateRangeConstructorTest()
        {
            DateTime start = new DateTime(2013, 5, 19);
            DateTime finish = new DateTime(2013, 5, 18);
            DateRange target = new DateRange(start, finish);
        }
    }
}
