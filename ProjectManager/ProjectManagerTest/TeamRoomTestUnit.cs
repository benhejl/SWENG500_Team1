using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagerLibrary.Models;
using ProjectManagerWeb.Controllers;

namespace ProjectManagerTest
{
    /// <summary>
    /// Summary description for TeamRoomTestUnit
    /// </summary>
    [TestClass]
    public class TeamRoomTestUnit
    {
        public TeamRoomTestUnit()
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
        public void TestCreateTeamRoom()
        {
            //TeamRoom teamRoom = new TeamRoom();
            //teamRoom.TeamRoomId = 1;

            //TeamRoomController teamRoomController = new TeamRoomController();
            //Assert.IsTrue(teamRoomController.CreateTeamRoom(teamRoom));
        }
        [TestMethod]
        public void TestEnterTeamRoom()
        {
            TeamRoom teamRoom = new TeamRoom();
            teamRoom.TeamRoomId = 1;

            TeamRoomController teamRoomController = new TeamRoomController();
            Assert.IsTrue(teamRoomController.EnterTeamRoom(teamRoom));
        }
        [TestMethod]
        public void TestLeaveTeamRoom()
        {
            TeamRoom teamRoom = new TeamRoom();
            teamRoom.TeamRoomId = 1;

            TeamRoomController teamRoomController = new TeamRoomController();
            Assert.IsTrue(teamRoomController.LeaveTeamRoom(teamRoom));
        }
        [TestMethod]
        public void TestViewTeamRoomConversations()
        {
            TeamRoom teamRoom = new TeamRoom();
            teamRoom.TeamRoomId = 1;

            TeamRoomController teamRoomController = new TeamRoomController();
            Assert.IsTrue(teamRoomController.ViewTeamRoomConversations(teamRoom));
        }
    }
}
