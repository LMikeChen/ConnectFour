using static Common.Data.Enums;

namespace Common.Interface
{
    public interface IMoveResult
    {
        MoveResultStatus MoveResultStatus { get; set; }
        IPlayer Winner { get; set; }
        IMove[] Moves { get; }
    }
}
