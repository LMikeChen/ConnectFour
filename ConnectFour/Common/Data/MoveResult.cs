
using Common.Interface;
using static Common.Data.Enums;

namespace Common.Data
{
    public class MoveResult : IMoveResult
    {
        public MoveResult(IMove move)
        {
            this.Moves = new IMove[2];
            Moves[0] = move;
            this.MoveResultStatus = MoveResultStatus.Success;
        }

        public MoveResult()
        {
            this.MoveResultStatus = MoveResultStatus.InValidMove;
        }

        public MoveResultStatus MoveResultStatus { get; set; }

        public IPlayer Winner { get; set; }

        public IMove[] Moves { get; private set; }
    }
}
