using Jarai.Refactoring.TicTacToe.Step3.Logic;
using Jarai.Refactoring.TicTacToe.Step3.UserInterface;

namespace Jarai.Refactoring.TicTacToe.Step3
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