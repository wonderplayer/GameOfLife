using System;

namespace Game_of_Life {
    public class Board {
        private readonly MenuText text = new MenuText();

        public void ShowSelectedBoard(Game game) {
            var inGameMenu = new InGameMenu();
            ShowBoardLayout(game.Boards[InGameMenu.SelectedBoard]);
            text.ShowBoardStats(game.Boards[InGameMenu.SelectedBoard]);
            text.ShowBoardMenu();
            inGameMenu.SelectBoardAction(game);
        }

        public void ShowBoard(SavedBoard game) {
            ShowBoardLayout(game);
            text.ShowBoardStats(game);
        }

        private void ShowBoardLayout(SavedBoard game) {
            Console.Clear();
            for (var yAxis = 0; yAxis <= game.Layout.Length - 1; yAxis++) {
                for (var xAxis = 0; xAxis <= game.Layout[0].Length - 1; xAxis++) {
                    Console.Write(game.Layout[yAxis][xAxis]);
                }

                Console.WriteLine();
            }
        }
    }
}