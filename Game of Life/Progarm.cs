using System;

namespace Game_of_Life {
    public static class Progarm {
        private static void Main() {
            ShowMenu();
        }

        private static void ShowMenu() {
            var text = new MenuText();
            text.ShowMenuText();
            SelectAction(Console.ReadKey(true).Key);
        }

        private static void SelectAction(ConsoleKey key) {
            var game = new Game();
            switch (key) {
                case ConsoleKey.D1:
                    game.NewGame();
                    break;
                case ConsoleKey.D2:
                    SavedGame savedGame = game.LoadGame();
                    game.Play(savedGame, false);
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.Escape:
                    break;
                default:
                    Console.Clear();
                    ShowMenu();
                    break;
            }
        }
    }
}