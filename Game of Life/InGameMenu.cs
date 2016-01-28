using System;

namespace Game_of_Life {
    public class InGameMenu {
        private readonly MenuText text = new MenuText();
        public static int SelectedBoard { get; private set; }

        public void ShowGameMenu(SavedGame game) {
            text.ShowGameMenuText();
            Console.ReadKey(true);
            SelectGameAction(game, Console.ReadKey(true).Key);
        }

        private void SelectGameAction(SavedGame game, ConsoleKey key) {
            var theGame = new Game();
            switch (key) {
                case ConsoleKey.S:
                    theGame.SaveGame(game);
                    break;
                case ConsoleKey.W:
                    SelectBoard(game);
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
            }
        }

        private void SelectBoard(SavedGame game) {
            var board = new Board();
            SelectedBoard = InputBoardNumber();
            board.ShowSelectedBoard(game);
        }

        private int InputBoardNumber() {
            int selectedGame;
            Console.Write("Input game number:");
            int.TryParse(Console.ReadLine(), out selectedGame);
            return selectedGame;
        }

        public void SelectBoardAction(SavedGame game) {
            var theGame = new Game();
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key) {
                case ConsoleKey.C:
                    theGame.Play(game, true);
                    break;
            }
        }
    }
}