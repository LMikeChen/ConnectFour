using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Common.Interface;

namespace Common.Data
{
    public class MoveResult : IMoveResult
    {
        public MoveResult(IMove move)
        {
            this.Move = move;
            this.Success = true;
        }

        public MoveResult()
        {
            this.Success = false;
        }

        public bool Success { get; private set; }

        public bool IsGameOver { get; set; }

        public bool IsTie { get; set; }

        public IPlayer Winner { get; set; }

        public IMove Move { get; private set; }
    }
}
