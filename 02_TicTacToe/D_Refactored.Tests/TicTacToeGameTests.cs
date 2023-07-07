using System.Linq;
using Jarai.Refactoring.TicTacToe.Refactored.Logic;
using Xunit;

namespace Jarai.Refactoring.TicTacToe.Refactored.Tests
{
    public class TicTacToeGameTests
    {
        


        [Fact()]
        public void Player_X_can_win()
        {
            // Arrange
            var userInterface = new FakeUserInterface
            {
                ReadLineBuffer = new[] {0, 1, 4, 2, 5, 3 }
            };

            var game = new TicTacToeGame(userInterface);

            // Act
            game.Play();

            // Assert
            Assert.Equal("The winner is X!", userInterface.WriteLineBuffer.Last());
        }


        [Fact()]
        public void Player_Y_can_win()
        {
            // Arrange
            var userInterface = new FakeUserInterface
            {
                ReadLineBuffer = new[] { 1, 4, 2, 5, 9, 6 }
            };

            var game = new TicTacToeGame(userInterface);

            // Act
            game.Play();

            // Assert
            Assert.Equal("The winner is O!", userInterface.WriteLineBuffer.Last());
        }


        [Fact()]
        public void No_player_can_win()
        {
            // Arrange
            var userInterface = new FakeUserInterface
            {
                ReadLineBuffer = new[] { 1, 4, 2, 5, 6, 3, 9, 8, 7, -1 }
            };

            var game = new TicTacToeGame(userInterface);

            // Act
            game.Play();

            // Assert
            Assert.Contains("No one won.", userInterface.WriteLineBuffer);
        }
    }
}