using System;

namespace Jarai.Refactoring.Drucker.Original
{
    public class Printer
    {
        public virtual void Print(string text)
        {
            Console.WriteLine("Drucker druckt: {0}", text);
        }
    }
}