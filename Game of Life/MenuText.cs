using System;

namespace Game_of_Life {
    public class MenuText {
        public void ShowBoardStats(SavedBoard board) {
            Console.Write("Alive cells: {0}", board.AliveCells);
            Console.WriteLine("  Generation: {0}", board.Generation);
            Console.WriteLine();
        }

        public void ShowBoardMenu() {
            Console.WriteLine("C - continue watching this board while playing");
            Console.Write("Or press any other key to continue watching game...");
        }

        public void ShowSaveGameText() {
            Console.WriteLine();
            Console.WriteLine("Press ESC to resume game");
            Console.Write("Enter a file name: ");
        }

        public void ShowGameStats(SavedGame game, int aliveCellsInGame) {
            Console.WriteLine("Alive cells in game: " + aliveCellsInGame);
            Console.WriteLine("Generation: " + game.Boards[0].Generation);
            Console.Write("Press any key to show menu...");
        }

        public void ShowGameMenuText() {
            Console.WriteLine();
            Console.Write("ESC - exit game  ");
            Console.Write("S - save game  ");
            Console.WriteLine("W - select board to show");
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