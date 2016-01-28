using System;
using System.Text;

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
                    GameWorld savedGame = game.LoadGame();
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

        public static string ReadLineWithCancel() {
            var buffer = new StringBuilder();
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter && info.Key != ConsoleKey.Escape) {
                if (info.Key != ConsoleKey.Backspace) {
                    buffer.Append(info.KeyChar);
                    Console.Write(info.KeyChar);
                } else {
                    if (buffer.Length > 0) {
                        buffer.Remove(buffer.Length - 1, 1);
                        Console.Write("\b");
                        Console.Write(" ");
                        Console.Write("\b");
                    }
                }

                info = Console.ReadKey(true);
            }

            return info.Key == ConsoleKey.Enter ? buffer.ToString() : null;
        }
    }
}