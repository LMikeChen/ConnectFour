using Connect4ConsoleUI.Game;

namespace Connect4ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            GameController gc = new GameController();

            gc.Start();
        }
    }
}
