using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interface
{
    public interface IMove
    {
        IPlayer Player { get; }
        int SequenceNumber { get; }
        int RowIndex { get; }
        int ColumnIndex { get; }

        bool IsValid { get; }
    }
}
