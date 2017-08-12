using GameEngine.Game;
using Common.Interface;
using Connect4ConsoleUI.Game.Player;
using ConnectWebApp.Player;

namespace ConnectWebApp.GameController
{
    public class ConnectGameController : IGameController
    {
        private ConnectFourGameEngine gameEngine;
        private WebPlayer player1;
        private WebPlayer player2;

        private bool player1Turn;
        public ConnectGameController()
        {
            player1 = new WebPlayer("Player 1", 'X');
            player2 = new WebPlayer("Player 2", 'O');

            gameEngine = new ConnectFourGameEngine(6, 7);
        }

        public int BoardRows { get { return gameEngine.BoardRows; } }

        public int BoardColumns { get { return gameEngine.BoardColumns; } }

        public IMoveResult ProcessMove(int column)
        {
            WebPlayer player = player1Turn ? player1 : player2;
            player1Turn = !player1Turn;
            return gameEngine.ProcessMove(player, column);
        }
    }
}