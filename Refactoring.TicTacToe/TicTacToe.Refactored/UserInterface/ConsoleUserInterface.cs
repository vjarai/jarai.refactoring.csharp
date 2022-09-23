using System;
using Jarai.Refactoring.TicTacToe.Refactored.Logic;

namespace Jarai.Refactoring.TicTacToe.Refactored.UserInterface
{
    internal class ConsoleUserInterface : IUserInterface
    {
        public int GetMove(Player player)
        {
            Console.WriteLine("What box do you want to place {0} in? (1-9)", player);
            Console.Write("> ");
            return int.Parse(Console.ReadLine());
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }

        public void ShowBoard(TicTacToeBoard board)
        {
            Console.Clear();
            Console.WriteLine(" {0} | {1} | {2} ", board.GetFieldSymbol(0), board.GetFieldSymbol(1), board.GetFieldSymbol(2));
            Console.WriteLine(" --------- ");
            Console.WriteLine(" {0} | {1} | {2} ", board.GetFieldSymbol(3), board.GetFieldSymbol(4), board.GetFieldSymbol(5));
            Console.WriteLine(" --------- ");
            Console.WriteLine(" {0} | {1} | {2} ", board.GetFieldSymbol(6), board.GetFieldSymbol(7), board.GetFieldSymbol(8));
        }
    }
}