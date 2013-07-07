using ProjectManagerWeb.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using ProjectManagerLibrary.Models;

namespace ProjectManagerTest
{
    
    
    /// <summary>
    ///This is a test class for ScrumControllerTest and is intended
    ///to contain all ScrumControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ScrumControllerTest
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
        ///A test for ScrumController Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Lauren\\Documents\\GitHub\\SWENG500_Team1\\ProjectManager\\ProjectManagerWeb", "/")]
        [UrlToTest("http://localhost:19961/")]
        public void ScrumControllerConstructorTest()
        {
            ScrumController target = new ScrumController();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for EditScrum
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Lauren\\Documents\\GitHub\\SWENG500_Team1\\ProjectManager\\ProjectManagerWeb", "/")]
        [UrlToTest("http://localhost:19961/")]
        public void EditScrumTest()
        {
            ScrumController target = new ScrumController(); // TODO: Initialize to an appropriate value
            ScrumModel scrum = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.EditScrum(scrum);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetScrumQuestions
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Lauren\\Documents\\GitHub\\SWENG500_Team1\\ProjectManager\\ProjectManagerWeb", "/")]
        [UrlToTest("http://localhost:19961/")]
        public void GetScrumQuestionsTest()
        {
            ScrumController target = new ScrumController(); // TODO: Initialize to an appropriate value
            ScrumModel expected = null; // TODO: Initialize to an appropriate value
            ScrumModel actual;
            actual = target.GetScrumQuestions();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for InputNewScrum
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Lauren\\Documents\\GitHub\\SWENG500_Team1\\ProjectManager\\ProjectManagerWeb", "/")]
        [UrlToTest("http://localhost:19961/")]
        public void InputNewScrumTest()
        {
            ScrumController target = new ScrumController(); // TODO: Initialize to an appropriate value
            ScrumModel scrum = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.InputNewScrum(scrum);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ViewScrumData
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Lauren\\Documents\\GitHub\\SWENG500_Team1\\ProjectManager\\ProjectManagerWeb", "/")]
        [UrlToTest("http://localhost:19961/")]
        public void ViewScrumDataTest()
        {
            ScrumController target = new ScrumController(); // TODO: Initialize to an appropriate value
            ScrumModel expected = null; // TODO: Initialize to an appropriate value
            ScrumModel actual;
            actual = target.ViewScrumData();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ViewScrumDetails
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Lauren\\Documents\\GitHub\\SWENG500_Team1\\ProjectManager\\ProjectManagerWeb", "/")]
        [UrlToTest("http://localhost:19961/")]
        public void ViewScrumDetailsTest()
        {
            //UNCOMMENT ME
            /*ScrumController target = new ScrumController(); // TODO: Initialize to an appropriate value
            ScrumModel scrum = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
<<<<<<< HEAD
            //actual = target.ViewScrumDetails(scrum);
            //Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
=======
            actual = target.ViewScrumDetails(scrum);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");*/
>>>>>>> 567b43206841e93c2be674c60285cc3c2a5c39e5
        }
    }
}
