using System;
using Jarai.Refactoring.TicTacToe.Refactored.Logic;
using Xunit;

namespace Jarai.Refactoring.TicTacToe.Refactored.Tests
{
    public class TicTacToeBoardTests
    {
        [Fact]
        public void Can_NOT_move_to_Field_0()
        {
            // Arrange
            var board = new TicTacToeBoard();

            // Act & Assert
            Assert.Throws<Exception>(() => board.SetField(0, Player.X));
        }

        [Fact]
        public void Can_NOT_move_to_Field_10()
        {
            // Arrange
            var board = new TicTacToeBoard();

            // Act & Assert
            Assert.Throws<Exception>(() => board.SetField(0, Player.X));
        }

        [Fact]
        public void Can_NOT_move_to_nonempty_Field()
        {
            // Arrange
            var board = new TicTacToeBoard();

            // Act
            board.SetField(1, Player.X);

            // Assert
            Assert.Throws<Exception>(() => board.SetField(1, Player.O));
        }
    }
}