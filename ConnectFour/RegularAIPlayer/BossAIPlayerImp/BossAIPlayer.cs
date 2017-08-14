using Common.Data;
using Common.Interface;
using GameEngine.Interface;
using Players.AIPlayerImp;
using Players.Data;
using Players.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players.BossAIPlayerImp
{
    public class BossAIPlayer : AIPlayer
    {
        public BossAIPlayer(string playerName, char playerID) : base(playerName, playerID)
        {

        }

        protected override ICalculationResult CalculateResult(IGameEngine gameEngine, char otherPlayerID)
        {
            ICalculationResult max = null;
            char[,] boardData = gameEngine.BoardData;
            for (int i = 0; i < boardData.GetLength(1); ++i)
            {
                int rowIndex = GetRow(i, boardData);
                if (rowIndex >= 0)
                {
                    IMove move = new ConnectMove(this, 0, rowIndex, i);

                    if (gameEngine.IsWinningMove(move))
                    {
                        CalculationResult result = new CalculationResult(rowIndex, i, boardData.GetLength(1));
                        result.IsWinningMove = true;

                        return result;
                    }
                }
            }
            return base.CalculateResult(gameEngine, otherPlayerID);

        }
    }
}
