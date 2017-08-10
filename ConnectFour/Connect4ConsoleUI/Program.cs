using CGameEngine.Game;
using Connect4ConsoleUI.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectFourGameEngine gameEngine = new ConnectFourGameEngine(6, 7);
            GameDisplay display = new GameDisplay();
            GameController gc = new GameController(display, gameEngine);

            gc.Start();
        }
    }
}
