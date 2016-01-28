using System;
using System.Collections.Generic;

namespace Game_of_Life {
    public class Game {
        private readonly MenuText text = new MenuText();
        private readonly GameFileManager gfManager = new GameFileManager();
        private InGameMenu igMenu = new InGameMenu();

        public void NewGame() {
            SavedGame game = gfManager.LoadNewGame("GliderGun");
            var world = new GameWorld {
                Game = new List<SavedGame>()
            };
            CreateWorld(game, world);
            Play(world, false);
        }

        private void CreateWorld(SavedGame game, GameWorld world) {
            for (var i = 0; i < 753; i++) {
                world.Game.Add(new SavedGame {
                    AliveCells = game.AliveCells,
                    Board = game.Board,
                    Generation = game.Generation
                });
            }
        }

        public GameWorld LoadGame() {
            Console.WriteLine("Input file name (example: MySavedGame)");
            string fileName = Console.ReadLine();
            return gfManager.LoadGame(fileName);
        }

        public void SaveGame(GameWorld world) {
            text.ShowSaveGameText();
            string fileName = Progarm.ReadLineWithCancel();
            gfManager.SaveGame(world, fileName);
        }

        public void Play(GameWorld world, bool isNeededToShowGame) {
            do {
                PlayWhileKeyNotPressed(world, isNeededToShowGame);
                igMenu.ShowInGameMenu(world);
            } while (true);
        }

        private void PlayWhileKeyNotPressed(GameWorld world, bool isNeededToShowGame) {
            while (!Console.KeyAvailable) {
                int aliveCellsInWorld = StepToNextGeneration(world);
                Console.Clear();
                if (isNeededToShowGame) {
                    ShowWorldAndGame(world, aliveCellsInWorld);
                } else {
                    text.ShowWorldStats(world, aliveCellsInWorld);
                }
            }
        }

        private int StepToNextGeneration(GameWorld world) {
            var gameCycle = new GameCycle();
            var aliveCellsInWorld = 0;
            foreach (SavedGame game in world.Game) {
                gameCycle.ChangeBoardState(game);
                aliveCellsInWorld += game.AliveCells;
            }
            return aliveCellsInWorld;
        }

        private void ShowWorldAndGame(GameWorld world, int aliveCellsInWorld) {
            var board = new Board();
            igMenu = new InGameMenu();
            board.ShowBoardForWorld(world, InGameMenu.SelectedGame);
            text.ShowWorldStats(world, aliveCellsInWorld);
        }
    }
}