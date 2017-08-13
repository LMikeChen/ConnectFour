using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Players.AIPlayerImp;
using Common.Interface;
using PlayerUnitTests.Setups;
using Common.Data;
using Players.WebPlayerImp;

namespace PlayerUnitTests.AIPlayerMoveControllerTests
{
    [TestClass]
    public class TestCase1Expect4
    {
        MockSetup setup = new MockSetup();

        [TestMethod]
        public void TestMethod1()
        {
            AIPlayerMoveController aiController = new AIPlayerMoveController();
            setup.SetData(new char[,] {
                {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', 'X', ' ', 'X', ' '}
            });

            AIPlayer aiPlayer = new AIPlayer("AI Player", 'A');
            WebPlayer webPlayer = new WebPlayer("Player 1", 'X');

            int actualMove = aiPlayer.GenerateMove(setup.GameEngine, webPlayer);

            Assert.AreEqual(4, actualMove);

        }
    }
}
