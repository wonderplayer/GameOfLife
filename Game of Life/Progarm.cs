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
            var gameplay = new Gameplay();
            switch (key) {
                case ConsoleKey.D1:
                    Game newGame = gameplay.NewGame();
                    gameplay.Play(newGame, false);
                    break;
                case ConsoleKey.D2:
                    Game game = gameplay.LoadGame();
                    gameplay.Play(game, false);
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