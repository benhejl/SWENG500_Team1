﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagerWeb.Controllers;
using ProjectManagerLibrary.Models;

namespace ProjectManagerTest
{
    /// <summary>
    /// Summary description for ScrumTestUnit
    /// </summary>
    [TestClass]
    public class ScrumTestUnit
    {
        public ScrumTestUnit()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestInputNewScrum()
        {
            ScrumController scrumController = new ScrumController();
            ScrumModel scrum = new ScrumModel();
            scrum.UserId = 1;
            Assert.IsTrue(scrumController.InputNewScrum(scrum));
        }
        [TestMethod]
        public void TestEditScrum()
        {
            ScrumController scrumController = new ScrumController();
            ScrumModel scrum = new ScrumModel();
            scrum.UserId = 1;
            Assert.IsTrue(scrumController.EditScrum(scrum));
        }
        [TestMethod]
        public void ViewScrum()
        {
            ScrumController scrumController = new ScrumController();
            ScrumModel scrum = new ScrumModel();
            scrum.UserId = 1;
            Assert.IsTrue(scrumController.ViewScrum(scrum));
        }
        [TestMethod]
        public void ViewScrumDetails()
        {
            ScrumController scrumController = new ScrumController();
            ScrumModel scrum = new ScrumModel();
            scrum.UserId = 1;
            Assert.IsTrue(scrumController.ViewScrumDetails(scrum));
        }
        [TestMethod]
        public void TestGetScrumQuestions()
        {
            ScrumController scrumController = new ScrumController();
            ScrumModel scrum = scrumController.GetScrumQuestions();
            Assert.IsTrue(scrum.QuestionsTable.Count > 0);
        }
    }
}
