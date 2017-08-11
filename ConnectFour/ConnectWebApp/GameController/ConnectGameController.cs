using CGameEngine.Game;
using Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConnectWebApp.GameController
{
    public class ConnectGameController : IGameController
    {
        private ConnectFourGameEngine gameEngine;
        public ConnectGameController()
        {
            gameEngine = new ConnectFourGameEngine(6, 7);
        }

        public IMoveResult ProcessMove(IPlayer player, int column)
        {
            return gameEngine.ProcessMove(player, column);
        }
    }
}