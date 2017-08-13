using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interface
{
    public interface IPlayerController
    {
        IMoveResult MakeMove(int column);

        void Reset();
    }
}
