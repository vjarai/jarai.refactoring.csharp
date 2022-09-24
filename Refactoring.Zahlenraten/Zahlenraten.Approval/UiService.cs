using System;

namespace Glücksspiel
{
    public class UiService
    {
        public virtual string ReadLine()
        {
            return Console.ReadLine();
        }

        public virtual void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}