using System.Collections.Generic;

namespace Jarai.Refactoring.TicTacToe.Step2
{
    public class FakeUserInterface : IUserInterface
    {
        private int _readLineBufferIndex = 0;

        public string[] ReadLineBuffer { get; set; }

        public List<string> WriteLineBuffer { get;  } = new List<string>();


        public void WriteLine(string format, params object[] args)
        {

           var output = string.Format(format, args);

            WriteLineBuffer.Add(output);
        }

        public void WriteLine()
        {
            WriteLine("\n");
        }

        public void Clear()
        {
        }

        public void ReadKey()
        {
            
        }

        public void Write(string text)
        {
            WriteLine(text);
        }

        public string ReadLine()
        {
            return ReadLineBuffer[_readLineBufferIndex++];
        }
    }
}
