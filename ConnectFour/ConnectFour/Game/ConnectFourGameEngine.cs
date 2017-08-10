using System;
using System.Collections.Generic;
using System.Text;
using Common.Interface;
using GameEngine.Interface;
using GameEngine.Data;

namespace CGameEngine.Game
{
    public class ConnectFourGameEngine : IGameEngine
    {
        private IGameBoard gameBoard;
        public ConnectFourGameEngine(int rows, int columns)
        {
            gameBoard = new ConnectFourBoard(rows, columns);
        }
        
        public char[,] BoardData { get { return gameBoard.BoardData; } }

        public IMoveResult ProcessMove(IPlayer player, int column)
        {
            IMoveResult result = gameBoard.Put(player, column);

            if(result.Success)
            {
                result.IsGameOver = IsWinningMove(result.Move);
            }
            return result;
        }

        private bool IsWinningMove(IMove move)
        {
            

            return false;
        }
    }
}
