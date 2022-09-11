using Jarai.Refactoring.TicTacToe.Step3.Logic;

namespace Jarai.Refactoring.TicTacToe.Step3.UserInterface
{
    public interface IUserInterface
    {
        int GetMove(Player player);
        void ShowBoard(TicTacToeBoard board);
        void ShowMessage(string message);
    }
}