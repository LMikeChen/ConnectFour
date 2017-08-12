
using GameEngine.Game;
using Common.Data;
using Common.Interface;
using GameEngine.Interface;
using HumanPlayerForConsole.Player;


namespace Connect4ConsoleUI.Game
{
    public class GameController
    {
        private GameDisplay display;
        private IGameEngine gameEngine;
        private IPlayer player1;
        private IPlayer player2;
        private readonly int MaxValidColumn;
        public GameController()
        {
            gameEngine = new ConnectFourGameEngine(6, 7);
            
            this.gameEngine = gameEngine;
            this.MaxValidColumn = gameEngine.BoardData.GetLength(1);
            player1 = new HumanPlayer("Player1", 'X');
            player2 = new HumanPlayer("Player1", 'O');

            display = new GameDisplay(player1, player2);
        }
        public void Start()
        {
            display.ShowStartMessage();

            bool player1Turn = true;
            while (true)
            {
                display.ShowBoard(gameEngine.BoardData);

                display.AskForMove(player1Turn ? player1 : player2);

               
                IPlayer currentPlayer = player1Turn ? player1 : player2;

                //IMoveResult result = ExecutePlayerMove(input, player1Turn ? player1 : player2);
                string move = currentPlayer.MakeMove();

                IMoveResult result = ExecutePlayerMove(move, currentPlayer);
                if (result.MoveResultStatus == Enums.MoveResultStatus.GameOver)
                {
                    display.ClearScreen();
                    display.ShowBoard(gameEngine.BoardData);
                    display.DelcareWinner(result);
                    break;
                   
                }
                else if(result.MoveResultStatus == Enums.MoveResultStatus.GameTie)
                {
                    display.ClearScreen();
                    display.ShowBoard(gameEngine.BoardData);
                    display.DelcareTie();
                    break;
                }
                else if(result.MoveResultStatus != Enums.MoveResultStatus.InValidMove)
                {
                    player1Turn = !player1Turn;
                }
                else if(result.MoveResultStatus == Enums.MoveResultStatus.UserQuit)
                {
                    break;
                }
               

                display.ClearScreen();
            }

            display.WaitToQuit();
            
        }


        private IMoveResult ExecutePlayerMove(string move, IPlayer player)
        {
            move.Trim();

            if(move.Length == 1)
            {
                switch (move[0])
                {
                    case 'q':
                    case 'Q':
                        MoveResult moveResult = new MoveResult();
                        moveResult.MoveResultStatus = Enums.MoveResultStatus.UserQuit;
                        return moveResult;
                    default:
                        
                        int column;
                        if (int.TryParse(move, out column) && (column >= 0 && column < MaxValidColumn))
                        {
                            return  gameEngine.ProcessMove(player, column);
                         
                        }

                        break;
                }
            }

            return new MoveResult();
            
        }
    }
}
