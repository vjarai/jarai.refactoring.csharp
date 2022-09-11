using System;

namespace Jarai.Refactoring.TicTacToe.Step2
{
    public class UserInterface : IUserInterface
    {
        public void WriteLine(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void ReadKey()
        {
            Console.ReadKey();
        }

        public void Write(string text)
        {
            Console.Write(text);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}