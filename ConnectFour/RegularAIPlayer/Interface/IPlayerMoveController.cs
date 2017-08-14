using Common.Interface;
using GameEngine.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players.Interface
{
    public interface IPlayerMoveController
    {

        IMoveResult ExecuteMove(int humanMove);

        IGameEngine GameEngine { get; set; }

        IPlayer[] Players { get; }

    }
}
