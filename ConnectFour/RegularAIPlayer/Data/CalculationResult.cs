using Players.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players.Data
{
    public class CalculationResult : ICalculationResult
    {
        private readonly int MiddleIndex;
        public CalculationResult(int rowIndex, int columnIndex, int columnMax)
        {
            this.RowIndex = rowIndex;
            this.ColumnIndex = columnIndex;
            this.MiddleIndex = (columnMax)/ 2;

        }
       public int ColumnIndex { get; private set; }
        public int RowIndex { get; private set; }
        public int BlockDirections { get; set; }
       public int BlockAmount { get; set; }
       public bool BlocksWin { get; set; }
       public int Connects { get; set; }

        public int CompareTo(object obj)
        {
            CalculationResult other = (CalculationResult)obj;

            // reference check
            if(this == other)
            {
                return 0;
            }

            // first check if the move blocks win directly
            if(this.BlocksWin && !other.BlocksWin)
            {
                return 1;
            }
            else if(other.BlocksWin && !this.BlocksWin)
            {
                return -1;
            }

            // then check total blocked amount
            if(this.BlockAmount > other.BlockAmount)
            {
                return 1;
            }
            else if(this.BlockAmount < other.BlockAmount)
            {
                return -1;
            }
            
            // then check total blocked directions
            if(this.BlockDirections > other.BlockDirections)
            {
                return 1;
            }
            else if (this.BlockDirections < other.BlockDirections)
            {
                return -1;
            }
         

            // Take index closest to middle
            int result = CompareDistanceToMiddle(this.ColumnIndex, other.ColumnIndex);

            return result;

        }

        private int CompareDistanceToMiddle(int a, int b)
        {

            int aDistance = a > MiddleIndex ? MiddleIndex - a : a - MiddleIndex;
            int bDistance = b > MiddleIndex ? MiddleIndex - b : b - MiddleIndex;

            if(aDistance > bDistance)
            {
                return 1;
            }
            else if(aDistance < bDistance)
            {
                return -1;
            }

            return 0;
        }
        
    }
}
