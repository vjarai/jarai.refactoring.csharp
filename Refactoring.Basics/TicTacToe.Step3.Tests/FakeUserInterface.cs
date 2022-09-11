using System.Collections.Generic;
using Jarai.Refactoring.TicTacToe.Step3.Logic;
using Jarai.Refactoring.TicTacToe.Step3.UserInterface;

namespace Jarai.Refactoring.TicTacToe.Step3.Tests
{
    public class FakeUserInterface : IUserInterface
    {
        private int _readLineBufferIndex = 0;

        public int[] ReadLineBuffer { get; set; }

        public List<string> WriteLineBuffer { get;  } = new List<string>();


        public int GetMove(Player player)
        {
            return ReadLineBuffer[_readLineBufferIndex++];
        }

        public void ShowBoard(TicTacToeBoard board)
        {
        }

        public void ShowMessage(string message)
        {
           WriteLineBuffer.Add(message);
        }
    }
}
