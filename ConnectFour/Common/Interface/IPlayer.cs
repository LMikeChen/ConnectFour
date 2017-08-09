using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interface
{
    public interface IPlayer : IComparable
    {
        string PlayerName { get; }
        int PlayerID { get; }
    }
}
