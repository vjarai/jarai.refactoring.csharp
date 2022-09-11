using System.Linq;
using Xunit;

namespace Jarai.Refactoring.TicTacToe.Step2.Tests
{
    public class TicTacToeGameTests
    {
        [Fact()]
        public void Player_X_can_win()
        {
            // Arrange
            var userInterface = new FakeUserInterface
            {
                ReadLineBuffer = new[] { "1", "4", "2", "5", "3" }
            };

            var game = new TicTacToeGame(userInterface);

            // Act
            game.Play();

            // Assert
            Assert.Equal("The winner is X!", userInterface.WriteLineBuffer.Last());
        }

        [Fact()]
        public void Moves_are_validity_checked()
        {
            // Arrange
            var userInterface = new FakeUserInterface
            {
                ReadLineBuffer = new[] { "1", "1", "4", "2", "5", "3" }
            };

            var game = new TicTacToeGame(userInterface);

            // Act
            game.Play();

            // Assert
            Assert.Contains("Error: box not vacant!", userInterface.WriteLineBuffer);
        }

        [Fact()]
        public void Moves_are_range_checked()
        {
            // Arrange
            var userInterface = new FakeUserInterface
            {
                ReadLineBuffer = new[] {"99", "1", "1", "4", "2", "5", "3" }
            };

            var game = new TicTacToeGame(userInterface);

            // Act
            game.Play();

            // Assert
            Assert.Contains("Wrong selection entered!", userInterface.WriteLineBuffer);
        }

        [Fact()]
        public void Player_Y_can_win()
        {
            // Arrange
            var userInterface = new FakeUserInterface
            {
                ReadLineBuffer = new[] { "1", "4", "2", "5", "9", "6" }
            };

            var game = new TicTacToeGame(userInterface);

            // Act
            game.Play();

            // Assert
            Assert.Equal("The winner is Y!", userInterface.WriteLineBuffer.Last());
        }


        [Fact()]
        public void No_player_can_win()
        {
            // Arrange
            var userInterface = new FakeUserInterface
            {
                ReadLineBuffer = new[] { "1", "4", "2", "5", "6", "3", "9", "8", "7", "-1" }
            };

            var game = new TicTacToeGame(userInterface);

            // Act
            game.Play();

            // Assert
            Assert.Contains("No one won.", userInterface.WriteLineBuffer);
        }

    }
}