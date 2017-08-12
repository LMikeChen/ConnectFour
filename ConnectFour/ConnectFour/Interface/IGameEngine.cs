using Common.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Interface
{
    public interface IGameEngine
    {
        char[,] BoardData { get; }

        int BoardRows { get; }

        int BoardColumns { get; }

        IMoveResult ProcessMove(IPlayer player, int column);
    }
}
