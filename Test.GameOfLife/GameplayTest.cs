using System.IO;
using Game_of_Life;
using NUnit.Framework;

namespace Test.GameOfLife {
    [TestFixture]
    public class GameplayTest {
        private Gameplay gameplay;

        [SetUp]
        public void Init() {
            gameplay = new Gameplay();
        }

        [Test]
        public void NewGame() {
            Game game = gameplay.NewGame();
            Assert.IsNotEmpty(game.Boards);
        }

        [Test]
        public void SaveGame() {
            Game game = gameplay.NewGame();
            gameplay.SaveGame(game);
        }

        [Test]
        public void LoadGame() {
            Game newGame = gameplay.NewGame();
            Game loadedGame = gameplay.LoadGame();
            Assert.AreNotEqual(newGame, loadedGame);
        }
    }
}