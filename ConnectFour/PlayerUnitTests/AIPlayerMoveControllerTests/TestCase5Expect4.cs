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
    public class TestCase5Expect4
    {
        MockSetup setup = new MockSetup();

        [TestMethod]
        public void TestMethod1()
        {
            AIPlayer aiPlayer = new AIPlayer("AI Player", 'B');
            AIPlayerMoveController aiController = new AIPlayerMoveController(aiPlayer);
            setup.SetData(new char[,] {
                {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', 'X', 'B', 'X', ' '},
                {'B', 'X', 'B', 'B', 'X', 'B', 'B'},
                {'X', 'B', 'X', 'X', 'B', 'X', 'X'}
            });
            
            WebPlayer webPlayer = new WebPlayer("Player 1", 'X');

            int actualMove = aiPlayer.GenerateMove(setup.GameEngine, webPlayer);

          //  Assert.AreNotEqual(-1, actualMove);

        }
    }
}
