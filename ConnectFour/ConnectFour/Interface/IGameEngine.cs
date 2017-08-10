using Common.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Interface
{
    public interface IGameEngine
    {
        char[,] BoardData { get; }

        IMoveResult ProcessMove(IPlayer player, int column);
    }
}
