using System;
using System.Collections.Generic;
using System.Text;
using Common.Interface;

namespace ConnectFourGameEngine.Data
{
    public class ConnectFourBoard : IGameBoard
    {
       
        public ConnectFourBoard(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
            this.BoardData = new IMove[Rows, Columns];
        }
        public int Rows { get; private set; }

        public int Columns { get; private set; }

        public IMove[,] BoardData { get; private set; }

        public IMoveResult Put(IPlayer player, int column)
        {
            return null;
        }
    }
}
