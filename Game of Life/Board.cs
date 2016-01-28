using System;

namespace Game_of_Life {
    public class Board {
        private readonly MenuText text = new MenuText();

        public void ShowGame(GameWorld world, int game) {
            var igMenu = new InGameMenu();
            ShowBoard(world, InGameMenu.SelectedGame);
            text.ShowBoardMenu(world, game);
            ConsoleKey key = Console.ReadKey(true).Key;
            igMenu.SelectInGameBoardAction(world, key);
        }

        public void ShowBoardForWorld(GameWorld world, int game) {
            ShowBoard(world, game);
            text.ShowGameStats(world, game);
        }

        private void ShowBoard(GameWorld world, int game) {
            Console.Clear();
            for (var yAxis = 0; yAxis <= world.Game[game].Board.Length - 1; yAxis++) {
                for (var xAxis = 0; xAxis <= world.Game[game].Board[0].Length - 1; xAxis++) {
                    Console.Write(world.Game[game].Board[yAxis][xAxis]);
                }

                Console.WriteLine();
            }
        }
    }
}