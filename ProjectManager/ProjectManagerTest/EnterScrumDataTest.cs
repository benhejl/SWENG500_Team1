using ProjectManagerWeb.Scrum;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace ProjectManagerTest
{
    
    
    /// <summary>
    ///This is a test class for EnterScrumDataTest and is intended
    ///to contain all EnterScrumDataTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EnterScrumDataTest
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
        ///A test for EnterScrumData Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Lauren\\Documents\\GitHub\\SWENG500_Team1\\ProjectManager\\ProjectManagerWeb", "/")]
        [UrlToTest("http://localhost:19961/")]
        public void EnterScrumDataConstructorTest()
        {
            EnterScrumData target = new EnterScrumData();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Page_Load
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Lauren\\Documents\\GitHub\\SWENG500_Team1\\ProjectManager\\ProjectManagerWeb", "/")]
        [UrlToTest("http://localhost:19961/")]
        [DeploymentItem("ProjectManagerWeb.dll")]
        public void Page_LoadTest()
        {
            EnterScrumData_Accessor target = new EnterScrumData_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.Page_Load(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for submit_Click
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Lauren\\Documents\\GitHub\\SWENG500_Team1\\ProjectManager\\ProjectManagerWeb", "/")]
        [UrlToTest("http://localhost:19961/")]
        [DeploymentItem("ProjectManagerWeb.dll")]
        public void submit_ClickTest()
        {
            EnterScrumData_Accessor target = new EnterScrumData_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.submit_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
