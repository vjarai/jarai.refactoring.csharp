using System;

namespace Jarai.Refactoring.Drucker.Refactored
{
    public class Printer
    {
        public virtual void Print(string text)
        {
            Console.WriteLine("DRUCKEN: {0}", text);
        }
    }
}