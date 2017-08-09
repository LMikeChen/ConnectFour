using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interface
{
    public interface IMoveResult
    {
        bool Success { get; }
        bool IsGameOver { get; set; }
        IPlayer Winner { get; }
        IMove Move { get; }
    }
}
