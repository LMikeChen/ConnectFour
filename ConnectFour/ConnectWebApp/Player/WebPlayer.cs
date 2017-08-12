using Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConnectWebApp.Player
{
    public class WebPlayer : IPlayer
    {
        public WebPlayer(string playerName, char playerID)
        {
            this.PlayerName = playerName;
            this.PlayerID = playerID;
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
            return "";
        }
    }
}