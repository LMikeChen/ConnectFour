

using System;
using Common.Interface;
using GameEngine.Interface;
using Players.Interface;
using Common.Data;
using Players.Data;

namespace Players.AIPlayerImp
{
    public class AIPlayer : IPlayer
    {
        public AIPlayer(string playerName, char playerID)
        {
            this.PlayerName = playerName;
            this.PlayerID = playerID;
        }
        public string PlayerName { get; private set; }

        public char PlayerID { get; private set; }

        public int GenerateMove (IGameEngine gameEngine, IPlayer otherPlayer)
        {
            char[,] boardData = gameEngine.BoardData;

            ICalculationResult result = CalculateBlocks(gameEngine.BoardData, otherPlayer.PlayerID);

            if (result == null)
            {
                return -1;
            }
            else
            {
                return result.ColumnIndex;
            }
        }

        #region

        private ICalculationResult CalculateBlocks(char[,] boardData, char otherPlayerID)
        {
            ICalculationResult max = null;
            for (int i = 0; i < boardData.GetLength(1); ++i)
            {
                int rowIndex = GetRow(i, boardData);
                if (rowIndex >= 0)
                {

                    ICalculationResult current = CalculateColumnBlocks(rowIndex, i, boardData, otherPlayerID);
                    if(max == null || current.CompareTo( max) == 1)
                    {
                        max = current;
                    }
                }
            }
            return max;
        }

        private ICalculationResult CalculateColumnBlocks(int row, int col, char[,] boardData, char otherPlayerID)
        {
            int totalBlcokCount = 0;

            ICalculationResult result = new CalculationResult(row, col, boardData.GetLength(1));

            int downBlockCount = DownBlockCount(row, col, boardData, otherPlayerID);

            if(downBlockCount > 0)
            {
                if(downBlockCount >2)
                {
                    result.BlocksWin = true;
                    
                }
                else
                {
                    result.BlockAmount += downBlockCount;
                    result.BlockDirections += 1;
                }
            }

            int leftBlockCount = LeftBlockCount(row, col, boardData, otherPlayerID);
            int rightBlockCount = RightBlockCount(row, col, boardData, otherPlayerID);

            if (leftBlockCount > 0 || rightBlockCount > 0)
            {
                if ((leftBlockCount + rightBlockCount) > 2)
                {
                    result.BlocksWin = true;
                }
                else
                {
                    result.BlockAmount += rightBlockCount;
                    result.BlockAmount += leftBlockCount;
                    result.BlockDirections += rightBlockCount > 0? 1 : 0;
                    result.BlockDirections += leftBlockCount > 0 ? 1 : 0;
                }
            }

            int upLeftBlockCount = UpLeftBlockCount(row, col, boardData, otherPlayerID);
            int downRIghtBlockCount = DownRightBlockCount(row, col, boardData, otherPlayerID);

            if (upLeftBlockCount > 0 || downRIghtBlockCount > 0)
            {
                if ((upLeftBlockCount + downRIghtBlockCount) > 2)
                {
                    result.BlocksWin = true;
                }
                else
                {
                    result.BlockAmount += downRIghtBlockCount;
                    result.BlockAmount += upLeftBlockCount;
                    result.BlockDirections += downRIghtBlockCount > 0 ? 1 : 0;
                    result.BlockDirections += upLeftBlockCount > 0 ? 1 : 0;
                }
            }

            int upRightBlockCount = UpRightBlockCount(row, col, boardData, otherPlayerID);
            int downLeftBlockCount = DownLeftBlockCount(row, col, boardData, otherPlayerID);

            if (upRightBlockCount > 0 || downLeftBlockCount > 0)
            {
                if ((upRightBlockCount + downLeftBlockCount) > 2)
                {
                    result.BlocksWin = true;
                }
                else
                {
                    result.BlockAmount += downLeftBlockCount;
                    result.BlockAmount += upRightBlockCount;
                    result.BlockDirections += downLeftBlockCount > 0 ? 1 : 0;
                    result.BlockDirections += upRightBlockCount > 0 ? 1 : 0;
                }
            }
            return result;

        }

        private int DownBlockCount(int row, int col, char[,] boardData, char otherPlayerID)
        {
            int count = 0;
            for(int i = row + 1; i < boardData.GetLength(0); ++i)
            {
                if(boardData[i, col] == otherPlayerID)
                {
                    count++;
                }
                else if(count > 1 && boardData[i, col] == Utilities.EmpptyCell)
                {
                    count++;
                    break;
                }
                else
                {
                    break;
                }
            }
            return count;
        }

        private int LeftBlockCount(int row, int col, char[,] boardData, char otherPlayerID)
        {
            int count = 0;
            for (int i = col - 1; i >= 0; --i)
            {
                if (boardData[row, i] == otherPlayerID)
                {
                    count++;
                }
                else if (count > 1 && boardData[row, i] == Utilities.EmpptyCell)
                {
                    count++;
                    break;
                }
                else
                {
                    break;
                }
            }
            return count;
        }

        private int RightBlockCount(int row, int col, char[,] boardData, char otherPlayerID)
        {
            int count = 0;
            for (int i = col + 1; i < boardData.GetLength(1); ++i)
            {
                if (boardData[row, i] == otherPlayerID)
                {
                    count++;
                }
                else if (count > 1 && boardData[row, i] == Utilities.EmpptyCell)
                {
                    count++;
                    break;
                }
                else
                {
                    break;
                }
            }
            return count;
        }

        private int UpLeftBlockCount(int row, int col, char[,] boardData, char otherPlayerID)
        {
            int count = 0;
            int cRow = row - 1;
            int cColumn = col - 1;
            while(cRow >= 0 && cColumn >= 0)
            {
                if(boardData[cRow, cColumn] == otherPlayerID)
                {
                    count++;
                    cRow--;
                    cColumn--;
                }
                else if (count > 1 && boardData[cRow, cColumn] == Utilities.EmpptyCell)
                {
                    count++;
                    break;
                }
                else
                {
                    break;
                }
            }

            return count;
        }

        private int UpRightBlockCount(int row, int col, char[,] boardData, char otherPlayerID)
        {
            int count = 0;
            int cRow = row - 1;
            int cColumn = col + 1;
            while (cRow >= 0 && cColumn < boardData.GetLength(1))
            {
                if (boardData[cRow, cColumn] == otherPlayerID)
                {
                    count++;
                    cRow--;
                    cColumn++;
                }
                else if (count > 1 && boardData[cRow, cColumn] == Utilities.EmpptyCell)
                {
                    count++;
                    break;
                }
                else
                {
                    break;
                }
            }

            return count;
        }

        private int DownLeftBlockCount(int row, int col, char[,] boardData, char otherPlayerID)
        {
            int count = 0;
            int cRow = row + 1;
            int cColumn = col - 1;
            while (cRow < boardData.GetLength(0) && cColumn >= 0)
            {
                if (boardData[cRow, cColumn] == otherPlayerID)
                {
                    count++;
                    cRow++;
                    cColumn--;
                }
                else if (count > 1 && boardData[cRow, cColumn] == Utilities.EmpptyCell)
                {
                    count++;
                    break;
                }
                else
                {
                    break;
                }
            }

            return count;
        }

        private int DownRightBlockCount(int row, int col, char[,] boardData, char otherPlayerID)
        {
            int count = 0;
            int cRow = row + 1;
            int cColumn = col + 1;
            while (cRow < boardData.GetLength(0) && cColumn < boardData.GetLength(1))
            {
                if (boardData[cRow, cColumn] == otherPlayerID)
                {
                    count++;
                    cRow++;
                    cColumn++;
                }
                else if (count > 1 && boardData[cRow, cColumn] == Utilities.EmpptyCell)
                {
                    count++;
                    break;
                }
                else
                {
                    break;
                }
            }

            return count;
        }

        private int GetRow(int column, char[,] boardData)
        {
            for(int i = boardData.GetLength(0) - 1; i >=0; i--)
            {
                if(boardData[i, column] == Utilities.EmpptyCell)
                {
                    return i;
                }
            }

            return -1;
        }
        #endregion
    }
}
