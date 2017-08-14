using Players.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Data;
using Common.Interface;
using GameEngine.Interface;
using Players.WebPlayerImp;

namespace Players.AIPlayerImp
{
    public class AIPlayerMoveController : IPlayerMoveController
    {
        private IPlayer webPlayer;
        private AIPlayer aiPlyaer;
        public AIPlayerMoveController(AIPlayer aiPlayer)
        {
            webPlayer = new WebPlayer("Player 1", 'X');
            aiPlyaer = aiPlayer;
        }
        public IGameEngine GameEngine { get; set; }

        public IMoveResult ExecuteMove(int humanMove)
        {
            IMoveResult moveResult = GameEngine.ProcessMove(webPlayer, humanMove);

            if(moveResult.MoveResultStatus == Common.Data.Enums.MoveResultStatus.Success)
            {
                int aiMove = aiPlyaer.GenerateMove(GameEngine, webPlayer);

                if (aiMove != -1)
                {
                    IMoveResult aiMoveResult = GameEngine.ProcessMove(aiPlyaer, aiMove);

                    moveResult.MoveResultStatus = aiMoveResult.MoveResultStatus;
                    moveResult.Moves[1] = aiMoveResult.Moves[0];
                    moveResult.Winner = aiMoveResult.Winner;
                }
                else
                {
                    moveResult.Winner = webPlayer;
                    moveResult.MoveResultStatus = Enums.MoveResultStatus.GameOver;
                }
            }
            return moveResult;
        }

        public IPlayer[] Players
        {
            get { return new IPlayer[] {webPlayer, aiPlyaer }; }
        }
    }
}
