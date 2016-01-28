using System;

namespace Game_of_Life {
    public class InGameMenu {
        private readonly MenuText text = new MenuText();
        public static int SelectedGame { get; set; }

        public void ShowInGameMenu(GameWorld world) {
            text.ShowInGameMenuText();
            Console.ReadKey(true);
            ConsoleKey key = Console.ReadKey(true).Key;
            SelectInGameAction(world, key);
        }

        private void SelectInGameAction(GameWorld world, ConsoleKey key) {
            var game = new Game();
            switch (key) {
                case ConsoleKey.S:
                    game.SaveGame(world);
                    break;
                case ConsoleKey.W:
                    SelectGame(world);
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
            }
        }

        private void SelectGame(GameWorld world) {
            var board = new Board();
            SelectedGame = InputGameNumber();
            board.ShowGame(world, SelectedGame);
        }

        private int InputGameNumber() {
            int selectedGame;
            Console.Write("Input game number:");
            int.TryParse(Console.ReadLine(), out selectedGame);
            return selectedGame;
        }

        public void SelectInGameBoardAction(GameWorld world, ConsoleKey key) {
            var game = new Game();
            switch (key) {
                case ConsoleKey.C:
                    game.Play(world, true);
                    break;
            }
        }
    }
}