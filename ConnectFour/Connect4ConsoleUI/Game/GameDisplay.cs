using Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4ConsoleUI.Game
{
    public class GameDisplay
    {
        public void ShowStartMessage()
        {
            Console.WriteLine("Welcome to Connect Four.");
        }

        public void ShowBoard(char[,] gameData)
        {

            int rows = gameData.GetLength(0);
            int columns = gameData.GetLength(1);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("  0 1 2 3 4 5 6");
            for (int i = 0; i < rows; ++i)
            {
                sb.Append(i);
                for(int j = 0; j < columns; ++j)
                {
                    sb.Append(string.Format("|{0}", gameData[i, j]));

                    
                }
                sb.AppendLine("|");
            }

            Console.WriteLine(sb.ToString());
            
        }

        public void AskForMove(IPlayer player)
        {
            Console.WriteLine(string.Format("Player {0} enter a move, enter 'q' to quit", player.PlayerID));
            Console.Write(">> ");
        }

        public void ClearScreen()
        {
            Console.Clear();
        }

        public void DelcareWinner(IMoveResult result)
        {
            Console.WriteLine(string.Format("Player {0} has won the game in {1} moves!", result.Move.Player.PlayerID, result.Move.SequenceNumber));
            
        }

        public void DelcareTie()
        {
            Console.WriteLine(string.Format("The game is a tie, well fought players!"));

        }

        public void WaitToQuit()
        {
            Console.WriteLine(string.Format("Hit any key to exit game"));
            Console.Read();
        }
    }
}
