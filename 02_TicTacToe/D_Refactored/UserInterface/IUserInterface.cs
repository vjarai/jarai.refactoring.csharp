using Jarai.Refactoring.TicTacToe.Refactored.Logic;

namespace Jarai.Refactoring.TicTacToe.Refactored.UserInterface
{
    public interface IUserInterface
    {
        int GetMove(Player player);
        void ShowBoard(TicTacToeBoard board);
        void ShowMessage(string message);
    }
}