using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interface
{
    public interface IGameController
    {
       int BoardRows { get; }

       int BoardColumns { get; }

        IMoveResult ProcessMove( int column);

        void Reset();
       
    }
}
