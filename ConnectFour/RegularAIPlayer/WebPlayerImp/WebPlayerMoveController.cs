using Common.Interface;
using GameEngine.Interface;
using Players.Interface;
using Players.WebPlayerImp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players.WebPlayerImp
{
    public class WebPlayerMoveController : IPlayerMoveController
    {
        private WebPlayer player1;
        private WebPlayer player2;

        private bool player1Turn;

        public WebPlayerMoveController()
        {
            Reset();
        }
        public IGameEngine GameEngine { get; set; }

        public IMoveResult ExecuteMove(int humanMove)
        {
            WebPlayer player = player1Turn ? player1 : player2;
            player1Turn = !player1Turn;
            return GameEngine.ProcessMove(player, humanMove);
        }

        public void Reset()
        {
            player1 = new WebPlayer("Player 1", 'X');
            player2 = new WebPlayer("Player 2", 'O');
        }
    }
}
