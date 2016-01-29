using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Game_of_Life {
    public class Gameplay : IGameplay {
        private readonly MenuText text = new MenuText();

        private readonly Files file = new Files();

        private readonly InGameMenu inGameMenu = new InGameMenu();

        private const string MAP_TYPE_FILE_NAME = "GliderGun.json";

        public Game NewGame() {
            
            string path = Path.GetFullPath(MAP_TYPE_FILE_NAME);
            string jsonString = file.LoadGameFromFile(path);
            var board = JsonConvert.DeserializeObject<SavedBoard>(jsonString);
            var game = new Game {
                Boards = new List<SavedBoard>()
            };
            FillGameWithBoards(board, game);

            return game;
        }

        public Game LoadGame() {
            Console.WriteLine("Input file name");
            string fileName = Console.ReadLine() + ".json";
            string jsonString = file.LoadGameFromFile(fileName);
            return JsonConvert.DeserializeObject<Game>(jsonString);
        }

        public void SaveGame(Game game) {
            text.ShowSaveGameText();
            string fileName = Console.ReadLine();
            file.SaveToFile(game, fileName);
        }

        public void Play(Game game, bool isNeededToShowBoard) {
            do {
                PlayWhileKeyNotPressed(game, isNeededToShowBoard);
                inGameMenu.ShowGameMenu(game);
            } while (true);
        }


        private void FillGameWithBoards(SavedBoard board, Game game) {
            for (var i = 0; i < 1000; i++) {
                game.Boards.Add(new SavedBoard {
                    AliveCells = board.AliveCells,
                    Layout = board.Layout,
                    Generation = board.Generation
                });
            }
        }

        private void PlayWhileKeyNotPressed(Game game, bool isNeededToShowBoard) {
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

        private int StepToNextGeneration(Game world) {
            var gameCycle = new GameCycle();
            var aliveCellsInGame = 0;
            foreach (SavedBoard board in world.Boards) {
                gameCycle.ChangeBoardState(board);
                aliveCellsInGame += board.AliveCells;
            }
            return aliveCellsInGame;
        }

        private void ShowGameWithBoard(Game game, int aliveCellsInGame) {
            var board = new Board();
            board.ShowBoard(game.Boards[InGameMenu.SelectedBoard]);
            text.ShowGameStats(game, aliveCellsInGame);
        }
    }
}