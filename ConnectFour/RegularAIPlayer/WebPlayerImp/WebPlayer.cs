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

    }
}