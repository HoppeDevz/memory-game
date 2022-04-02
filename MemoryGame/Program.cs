using System;

using MemoryGamePlayer;
using MemoryGameCore;

namespace MemoryGame
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Core gameCore = new Core();

            // INITIALIZE GAME CORE //
            gameCore.initializeGameCore();

            Player player = new Player("gabrielh2c", "gato123");

            Console.ReadKey();
        }
    }
}
