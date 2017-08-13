using Common.Interface;

namespace Players.WebPlayerImp
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

    }
}