using Players.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interface;
using GameEngine.Interface;
using Players.WebPlayerImp;

namespace Players.AIPlayerImp
{
    public class AIPlayerMoveController : IPlayerMoveController
    {
        private IPlayer webPlayer;
        private AIPlayer aiPlyaer;
        public AIPlayerMoveController()
        {
            Reset();
        }
        public IGameEngine GameEngine { get; set; }

        public IMoveResult ExecuteMove(int humanMove)
        {
            IMoveResult moveResult = GameEngine.ProcessMove(webPlayer, humanMove);

            if(moveResult.MoveResultStatus == Common.Data.Enums.MoveResultStatus.Success)
            {
                int aiMove = aiPlyaer.GenerateMove(GameEngine, webPlayer);

                IMoveResult aiMoveResult = GameEngine.ProcessMove(aiPlyaer, aiMove);

                moveResult.MoveResultStatus = aiMoveResult.MoveResultStatus;
                moveResult.Moves[1] = aiMoveResult.Moves[0];
                moveResult.Winner = aiMoveResult.Winner;
            }
            return moveResult;
        }

        public void Reset()
        {
            webPlayer = new WebPlayer("Player 1", 'X');
            aiPlyaer = new AIPlayer("AI Player", 'A');
        }

        public IPlayer[] Players
        {
            get { return new IPlayer[] {webPlayer, aiPlyaer }; }
        }
    }
}
