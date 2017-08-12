using Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4ConsoleUI.Game.Player
{
    public class HumanPlayer : IPlayer
    {
        public HumanPlayer(string name, char id)
        {
            this.PlayerName = name;
            this.PlayerID = id;
        }
        public string PlayerName { get; private set; }

        public char PlayerID { get; private set; }

        public int CompareTo(object obj)
        {
            char otherID = (char)obj;


            if (this.PlayerID == otherID)
            {
                return 0;
            }
            else if (this.PlayerID > otherID)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public string MakeMove()
        {
            string input = Console.ReadLine();
            return input;
        }
    }
}
