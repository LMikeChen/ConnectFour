using GameEngine.Game;
using Common.Interface;
using Players.WebPlayerImp;
using Players.Interface;
using Players.AIPlayerImp;
using Players.BossAIPlayerImp;

namespace ConnectWebApp.GameController
{
    public class ConnectGameController : IGameController
    {
        private ConnectFourGameEngine gameEngine;

        private IPlayerMoveController playerMoveController;
        public ConnectGameController()
        {
            // Default is web player vs web player
            playerMoveController = new WebPlayerMoveController();

            Reset();
        }

        public int BoardRows { get { return gameEngine.BoardRows; } }

        public int BoardColumns { get { return gameEngine.BoardColumns; } }

        public IMoveResult ProcessMove(int column)
        {
            IMoveResult result = playerMoveController.ExecuteMove(column);
            return result;
        }

        public void ChangePlayerMoveController(string controllerType)
        {
            controllerType.Trim();

            if(!string.IsNullOrWhiteSpace(controllerType))
            {
                if (string.Equals("Human", controllerType, System.StringComparison.OrdinalIgnoreCase))
                {
                    playerMoveController = new WebPlayerMoveController();
                    playerMoveController.GameEngine = gameEngine;
                }
                else if (string.Equals("Block AI", controllerType, System.StringComparison.OrdinalIgnoreCase))
                {
                    AIPlayer aiPlayer = new AIPlayer("AI Player", 'A');
                    playerMoveController = new AIPlayerMoveController(aiPlayer);
                    playerMoveController.GameEngine = gameEngine;
                }
                else if (string.Equals("Boss AI", controllerType, System.StringComparison.OrdinalIgnoreCase))
                {
                    BossAIPlayer aiPlayer = new BossAIPlayer("AI Player", 'B');
                    playerMoveController = new AIPlayerMoveController(aiPlayer);
                    playerMoveController.GameEngine = gameEngine;
                }
            }
            
        }

        public void Reset()
        {
            gameEngine = new ConnectFourGameEngine(6, 7);
            playerMoveController.GameEngine = gameEngine;
        }
    }
}