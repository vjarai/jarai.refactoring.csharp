using System;

namespace Jarai.Refactoring.Adapter.Original
{
    public class Printer
    {
        public virtual void Print(string text)
        {
            Console.WriteLine("DRUCKEN: {0}", text);
        }
    }
}