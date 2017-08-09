using System;
using System.Collections.Generic;
using System.Text;
using Common.Interface;

namespace Common.Data
{
    public class ConnectMove : IMove
    {
        public IPlayer Player { get; private set; }

        public int SequenceNumber { get; private set; }

        public int RowIndex { get; private set; }

        public int ColumnIndex { get; private set; }
    }
}
