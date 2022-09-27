﻿namespace Jarai.Refactoring.Adapter.Original
{
    public class Letter
    {
        private readonly string _text;

        public Letter(string text)
        {
            _text = text;
        }

        public void SendTo(Printer printer)
        {
            printer.Print(_text);
        }
    }
}