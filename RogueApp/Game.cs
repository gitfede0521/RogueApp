using RLNET;
using System;

namespace RLNET_Tutorial
{
    public class Game
    {
        public static RLRootConsole rootConsole;
        private static Engine engine;

        public static void Main()
        {
            rootConsole = new RLRootConsole("ascii_8x8.png", 80, 50, 8, 8,title:"GAME");
            engine = new Engine(rootConsole);
            rootConsole.Run();
        }
    }
}
