using System;
using System.Collections.Generic;
using System.Text;
using ConnectFourGameEngine.Interface;
using Common.Interface;
using ConnectFourGameEngine.Data;

namespace ConnectFourGameEngine.Game
{
    public class ConnectFourGameEngine : IGameEngine
    {
        private IGameBoard gameBoard;
        public ConnectFourGameEngine(int rows, int columns)
        {
            gameBoard = new ConnectFourBoard(rows, columns);
        }
        

    }
}
