using System;

namespace Game_of_Life {
    public class MenuText {
        public void ShowGameStats(GameWorld world, int game) {
            Console.Write("Alive cells: {0}", world.Game[game].AliveCells);
            Console.WriteLine("  Generation: {0}", world.Game[game].Generation);
            Console.WriteLine();
        }

        public void ShowBoardMenu(GameWorld world, int game) {
            ShowGameStats(world, game);
            Console.WriteLine("C - continue watching this game while playing");
            Console.Write("Or press any other key to continue watching world...");
        }

        public void ShowSaveGameText() {
            Console.WriteLine();
            Console.WriteLine("Press ESC to resume game");
            Console.Write("Enter a file name: ");
        }

        public void ShowWorldStats(GameWorld world, int aliveCellsInWorld) {
            Console.WriteLine("Alive cells in all games: " + aliveCellsInWorld);
            Console.WriteLine("Generation: " + world.Game[0].Generation);
            Console.Write("Press any key to show menu...");
        }

        public void ShowInGameMenuText() {
            Console.WriteLine();
            Console.Write("ESC - exit game  ");
            Console.Write("S - save game  ");
            Console.WriteLine("W - select game to show");
            Console.Write("Press any other key to resume a game");
            Console.WriteLine();
        }

        public void ShowMenuText() {
            Console.WriteLine("1. New game");
            Console.WriteLine("2. Load game form file");
            Console.WriteLine("3. Exit");
        }
    }
}