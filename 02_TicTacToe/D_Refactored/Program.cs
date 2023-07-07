using Jarai.Refactoring.TicTacToe.Refactored.Logic;
using Jarai.Refactoring.TicTacToe.Refactored.UserInterface;

namespace Jarai.Refactoring.TicTacToe.Refactored
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var game = new TicTacToeGame(new ConsoleUserInterface());
            game.Play();
        }
    }
}