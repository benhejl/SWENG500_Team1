using System;
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
            ScrumModel scrumModel = new ScrumModel();
            scrumModel.AnswerList = new System.Collections.ArrayList();

            Answers answers = new Answers();
            answers.Answer = "Worked on Unit Test Cases";
            answers.QuestionId = 1;
            answers.UserId = 1;
            scrumModel.AnswerList.Add(answers);

            answers = new Answers();
            answers.Answer = "Worked on Scrum Room";
            answers.QuestionId = 2;
            answers.UserId = 1;
            scrumModel.AnswerList.Add(answers);

            answers = new Answers();
            answers.Answer = "None";
            answers.QuestionId = 3;
            answers.UserId = 1;
            scrumModel.AnswerList.Add(answers);

            Assert.IsTrue(new ScrumController().InputNewScrum(scrumModel));
        }
        [TestMethod]
        public void TestEditScrum()
        {
            ScrumModel scrumModel = new ScrumModel();
            scrumModel.AnswerList = new System.Collections.ArrayList();

            Answers answers = new Answers();
            answers.Answer = "Test Edit";
            answers.QuestionId = 1;
            answers.UserId = 1;
            answers.AnswerKey = 0;
            scrumModel.AnswerList.Add(answers);

            answers = new Answers();
            answers.Answer = "Test Edit";
            answers.QuestionId = 2;
            answers.UserId = 1;
            answers.AnswerKey = 0;
            scrumModel.AnswerList.Add(answers);

            answers = new Answers();
            answers.Answer = "None";
            answers.QuestionId = 3;
            answers.UserId = 1;
            answers.AnswerKey = 0;
            scrumModel.AnswerList.Add(answers);

            Assert.IsTrue(new ScrumController().EditScrum(scrumModel));
        }
        [TestMethod]
        public void TestViewScrum()
        {
            ScrumController scrumController = new ScrumController();
            Assert.IsTrue(scrumController.ViewScrumData().ScrumList.Count > 0);
        }
        [TestMethod]
        public void TestViewScrumDetails()
        {
            ScrumController scrumController = new ScrumController();
            Assert.IsTrue(scrumController.GetScrumDetails(0).AnswerList.Count > 1);
        }
        [TestMethod]
        public void TestGetScrumQuestions()
        {
            ScrumController scrumController = new ScrumController();
            ScrumModel scrum = scrumController.GetScrumQuestions();
            Assert.IsTrue(scrum.QuestionList.Count == 3);
        }
    }
}
