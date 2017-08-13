using Common.Interface;
using GameEngine.Interface;
using GameEngine.Data;
using static Common.Data.Enums;

namespace GameEngine.Game
{
    public class ConnectFourGameEngine : IGameEngine
    {
        private IGameBoard gameBoard;
        private bool isGameOver;
        private IMoveResult winningResult;
        public ConnectFourGameEngine(int rows, int columns)
        {
            gameBoard = new ConnectFourBoard(rows, columns);
            isGameOver = false;
        }

        #region interfaces 

        public int BoardRows { get { return gameBoard.Rows; } }

        public int BoardColumns { get { return gameBoard.Columns; } }


        public char[,] BoardData { get { return gameBoard.BoardData; } }

        public IMoveResult ProcessMove(IPlayer player, int column)
        {
            if (!isGameOver)
            {
                IMoveResult result = gameBoard.Put(player, column);

                if (result.MoveResultStatus == MoveResultStatus.Success)
                {
                    IMove move = result.Moves[0];
                    if (IsWinningMove(move))
                    {
                        result.MoveResultStatus = MoveResultStatus.GameOver;
                        winningResult = result;
                        isGameOver = true;
                    }
                    else if (move.SequenceNumber >= gameBoard.BoardSize - 1)
                    {
                        result.MoveResultStatus = MoveResultStatus.GameTie;
                    }

                }
                return result;
            }
            else
            {
                return winningResult;
            }
            
        }

        #endregion

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

