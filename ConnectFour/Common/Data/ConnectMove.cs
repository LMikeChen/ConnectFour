using System;
using System.Collections.Generic;
using System.Text;
using Common.Interface;

namespace Common.Data
{
    public class ConnectMove : IMove
    {
        public ConnectMove(IPlayer player, int sequenceNumber, int rowIndex, int columnIndex)
        {
            this.Player = player;
            this.SequenceNumber = sequenceNumber;
            this.RowIndex = rowIndex;
            this.ColumnIndex = columnIndex;
            this.IsValid = true;
        }

        public ConnectMove()
        {
            this.IsValid = false;
        }

        public IPlayer Player { get; private set; }

        public int SequenceNumber { get; private set; }

        public int RowIndex { get; private set; }

        public int ColumnIndex { get; private set; }

        public bool IsValid { get; private set; }
    }
}
