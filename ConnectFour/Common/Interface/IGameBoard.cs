using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interface
{
    public interface IGameBoard
    {
        int Rows { get; }
        int Columns { get; }

        IMoveResult Put(IPlayer player, int column);

        char[,] BoardData { get; }
    }
}
