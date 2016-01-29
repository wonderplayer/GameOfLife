using System;

namespace Game_of_Life {
    public class InGameMenu {
        private readonly MenuText text = new MenuText();
        public static int SelectedBoard { get; private set; }

        public void ShowGameMenu(Game game) {
            text.ShowGameMenuText();
            Console.ReadKey(true);
            SelectGameAction(game, Console.ReadKey(true).Key);
        }

        private void SelectGameAction(Game game, ConsoleKey key) {
            var theGame = new Gameplay();
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

        private void SelectBoard(Game game) {
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

        public void SelectBoardAction(Game game) {
            var theGame = new Gameplay();
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key) {
                case ConsoleKey.C:
                    theGame.Play(game, true);
                    break;
            }
        }
    }
}