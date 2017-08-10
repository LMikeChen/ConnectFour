using System;
using System.Collections.Generic;
using System.Text;
using Common.Data;
using Common.Interface;

namespace GameEngine.Data
{
    public class ConnectFourBoard : IGameBoard
    {
        private int sequenceID = 0;
        public ConnectFourBoard(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
            this.GameMoves = new IMove[Rows, Columns];
        }
        public int Rows { get; private set; }

        public int Columns { get; private set; }

        public int BoardSize { get { return Rows * Columns; } }

        public char[,] BoardData {
            get
            {
              char[,]   board = new char[Rows, Columns];

                for (int i = 0; i < Rows; ++i)
                {
                    for (int j = 0; j< Columns; ++j)
                    {
                        IMove move = GameMoves[i, j];
                        if (move != null)
                        {
                            board[i, j] = move.Player.PlayerID;
                        }
                        else
                        {
                            board[i, j] = ' ';
                        }
                    }
                }

              return board;
            }}

        public IMoveResult Put(IPlayer player, int column)
        {
            for (int i = Rows -1; i >= 0; --i)
            {
                if (GameMoves[i, column] == null)
                {
                    ConnectMove move = new ConnectMove(player, sequenceID++, i, column);
                    GameMoves[i, column] = move;
                    IMoveResult result = new MoveResult(move);

                    return result;
                }
            }

            // Failed result;
            return new MoveResult();
        }

        private IMove[,] GameMoves { get; set; }
    }
}
