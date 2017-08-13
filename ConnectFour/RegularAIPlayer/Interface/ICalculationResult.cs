using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players.Interface
{
    public interface ICalculationResult :IComparable
    {
        int ColumnIndex { get;}
        int RowIndex { get; }
        int BlockDirections { get; set; }
        int BlockAmount { get; set; }
        bool BlocksWin { get; set; }
        int Connects { get; set; }
    }
}
