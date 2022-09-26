using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Resharper.InheritanceToDelegation
{
    public class Schiff : ISchiff
    {
        public void Tuckern()
        {
            Console.WriteLine("Tuckern");
        }
    }
}