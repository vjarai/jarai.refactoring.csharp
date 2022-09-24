using System.Collections.Generic;
using System.Reflection;

namespace Glücksspiel
{
    public class FakeUiService : UiService
    {
        private int _index;

        public FakeUiService(string[] inputBuffer)
        {
            InputBuffer = inputBuffer;
        }

        public string[] InputBuffer { get; }

        public List<string> OutputBuffer { get; } = new List<string>();

        public override string ReadLine()
        {
            return InputBuffer[_index++];
        }

        public override void WriteLine(string message)
        {
            OutputBuffer.Add(message);
        }
    }
}