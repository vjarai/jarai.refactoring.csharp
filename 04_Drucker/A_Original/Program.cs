using System;

namespace Jarai.Refactoring.Drucker.Original
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var brief = new Letter("Sehr geehrter Herr XY, ...");

            var drucker = new Printer();
            brief.SendTo(drucker);

            Console.Read();
        }
    }
}