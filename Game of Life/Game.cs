using System;
using System.Collections.Generic;

namespace Game_of_Life {
    public class Game {
        private readonly MenuText text = new MenuText();
        private readonly Files file = new Files();
        private readonly InGameMenu inGameMenu = new InGameMenu();

        public void NewGame() {
            SavedBoard board = file.LoadDefaultBoard();
            var game = new SavedGame {
                Boards = new List<SavedBoard>()
            };
            FillGameWithBoards(board, game);
            Play(game, false);
        }

        private void FillGameWithBoards(SavedBoard board, SavedGame game) {
            for (var i = 0; i < 1000; i++) {
                game.Boards.Add(new SavedBoard {
                    AliveCells = board.AliveCells,
                    Layout = board.Layout,
                    Generation = board.Generation
                });
            }
        }

        public SavedGame LoadGame() {
            Console.WriteLine("Input file name");
            string fileName = Console.ReadLine();
            return file.LoadGame(fileName);
        }

        public void SaveGame(SavedGame game) {
            text.ShowSaveGameText();
            string fileName = Console.ReadLine();
            file.SaveGame(game, fileName);
        }

        public void Play(SavedGame game, bool isNeededToShowBoard) {
            do {
                PlayWhileKeyNotPressed(game, isNeededToShowBoard);
                inGameMenu.ShowGameMenu(game);
            } while (true);
        }

        private void PlayWhileKeyNotPressed(SavedGame game, bool isNeededToShowBoard) {
            while (!Console.KeyAvailable) {
                int aliveCellsInGame = StepToNextGeneration(game);
                Console.Clear();
                if (isNeededToShowBoard) {
                    ShowGameWithBoard(game, aliveCellsInGame);
                    continue;
                }
                text.ShowGameStats(game, aliveCellsInGame);
            }
        }

        private int StepToNextGeneration(SavedGame world) {
            var gameCycle = new GameCycle();
            var aliveCellsInGame = 0;
            foreach (SavedBoard board in world.Boards) {
                gameCycle.ChangeBoardState(board);
                aliveCellsInGame += board.AliveCells;
            }
            return aliveCellsInGame;
        }

        private void ShowGameWithBoard(SavedGame game, int aliveCellsInGame) {
            var board = new Board();
            board.ShowBoard(game.Boards[InGameMenu.SelectedBoard]);
            text.ShowGameStats(game, aliveCellsInGame);
        }
    }
}