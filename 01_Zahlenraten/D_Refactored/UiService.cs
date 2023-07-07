using System;

namespace Jarai.Refactoring.Zahlenraten.Refactored
{
    public class UiService : IUiService
    {
        public virtual string ReadLine()
        {
            return Console.ReadLine();
        }

        public virtual void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void WriteInputCorrect()
        {
            Console.WriteLine("Richtig");
        }

        public void WriteInputToBig()
        {
            Console.WriteLine("Ihre Zahl ist zu groß");
        }

        public void WriteInputToSmall()
        {
            Console.WriteLine("Ihre Zahl ist zu klein");
        }
    }
}