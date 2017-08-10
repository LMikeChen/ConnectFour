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
                if(IsWinningMove(result.Move))
                {
                    result.IsGameOver = true;
                }
                else if(result.Move.SequenceNumber >= gameBoard.BoardSize -1)
                {
                    result.IsTie = true;   
                }
                
            }
            return result;
        }

        private bool IsWinningMove(IMove move)
        {
            char playerId = move.Player.PlayerID;
            char[,] boardData = gameBoard.BoardData;
            if(CheckLeft(playerId, move.RowIndex, move.ColumnIndex, boardData) + CheckRight(playerId, move.RowIndex, move.ColumnIndex, boardData) >= 3)
            {
                return true;
            }

            if (CheckDown(playerId, move.RowIndex, move.ColumnIndex, boardData) >=3)
            {
                return true;
            }

            if (CheckUpLeft(playerId, move.RowIndex, move.ColumnIndex, boardData) + CheckDownRight(playerId, move.RowIndex, move.ColumnIndex, boardData) >=3)
            {
                return true;
            }

            if (CheckUpRight(playerId, move.RowIndex, move.ColumnIndex, boardData) + CheckDownLeft(playerId, move.RowIndex, move.ColumnIndex, boardData) >=3)
            {
                return true;
            }
            
            return false;
        }

        private int CheckLeft(char playerId, int rowIndex, int colIndex, char[,] boardData)
        {
            int count = 0;
            for(int i = colIndex -1; i >= 0; --i)
            {
                if(boardData[rowIndex, i] == playerId)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            return count;
        }

        private int CheckRight(char playerId, int rowIndex, int colIndex, char[,] boardData)
        {
            int count = 0;
            for (int i = colIndex+1; i < boardData.GetLength(1); ++i)
            {
                if (boardData[rowIndex, i] == playerId)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            return count;
        }

        //private int CheckUp(char playerId, int rowIndex, int colIndex, char[,] boardData)
        //{
        //    int count = 0;
        //    for (int i = rowIndex - 1; i >= 0; --i)
        //    {
        //        if (boardData[i, colIndex] == playerId)
        //        {
        //            count++;
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }
        //    return count;
        //}

        private int CheckDown(char playerId, int rowIndex, int colIndex, char[,] boardData)
        {
            int count = 0;
            for (int i = rowIndex + 1; i < boardData.GetLength(0); ++i)
            {
                if (boardData[i, colIndex] == playerId)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            return count;
            return 0;
        }

        private int CheckUpLeft(char playerId, int rowIndex, int colIndex, char[,] boardData)
        {
            int row = rowIndex - 1;
            int column = colIndex - 1;

            int count = 0;
            while(row >= 0 && column>= 0)
            {
                if (boardData[row--, column--] == playerId)
                {
                    count++;
                    
                }
                else
                {
                    break;
                }
            }

            return count;
        }

        private int CheckUpRight(char playerId, int rowIndex, int colIndex, char[,] boardData)
        {
            int row = rowIndex - 1;
            int column = colIndex + 1;

            int count = 0;
            while (row >= 0 && column < boardData.GetLength(1))
            {
                if (boardData[row--, column++] == playerId)
                {
                    count++;

                }
                else
                {
                    break;
                }
            }

            return count;
        }

        private int CheckDownLeft(char playerId, int rowIndex, int colIndex, char[,] boardData)
        {
            int row = rowIndex + 1;
            int column = colIndex - 1;

            int count = 0;
            while (row < boardData.GetLength(0) && column >= 0)
            {
                if (boardData[row++, column--] == playerId)
                {
                    count++;

                }
                else
                {
                    break;
                }
            }

            return count;
        }

        private int CheckDownRight(char playerId, int rowIndex, int colIndex, char[,] boardData)
        {
            int row = rowIndex + 1;
            int column = colIndex + 1;

            int count = 0;
            while (row < boardData.GetLength(0) && column < boardData.GetLength(1))
            {
                if (boardData[row++, column++] == playerId)
                {
                    count++;

                }
                else
                {
                    break;
                }
            }

            return count;
        }

    }
}
