using System;
using Game_of_Life;
using Moq;
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
            Game newGame = gameplay.NewGame();
            var mock = new Mock<IGameplay>();
            mock.Verify(g => g.SaveGame(newGame), Times.Once);
        }

        [Test]
        public void LoadGame() {
            Game newGame = gameplay.NewGame();
            var mock = new Mock<IGameplay>();
            //mock.Setup(g => g.LoadGame()).Returns(newGame);
            mock.Verify(g => g.LoadGame(), Times.Once);
        }

        [Test]
        public void PlayWithoutShowingBoard() {
            var newGame = new Game();
            var game = new Mock<IGameplay>();
            game.Setup(g => g.NewGame()).Returns(newGame);
        }

        [Test]
        public void PlayWithShowingBoard() {}
    }
}