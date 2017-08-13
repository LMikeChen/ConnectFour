using Common.Interface;
using GameEngine.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerUnitTests.Setups
{
    public class MockSetup
    {
        protected Mock<IGameEngine> gameEngineMoq = new Mock<IGameEngine>();

        public void SetData(char[,] data)
        {
            gameEngineMoq.Setup(mk => mk.BoardData).Returns(data);
        }

        public void SetProcessHumanMove(IPlayer humanPlayer, int move, IMoveResult result)
        {
            gameEngineMoq.Setup(mk => mk.ProcessMove(humanPlayer, move)).Returns(result);
        }

        public void SetProcessAIMove(IPlayer aiPlayer, int move, IMoveResult result)
        {
            gameEngineMoq.Setup(mk => mk.ProcessMove(aiPlayer, move)).Returns(result);
        }

        public IGameEngine GameEngine { get { return gameEngineMoq.Object; }}
    }
}
