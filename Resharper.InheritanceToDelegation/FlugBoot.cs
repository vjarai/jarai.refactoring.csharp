using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Resharper.InheritanceToDelegation
{
    public class FlugBoot : ISchiff, IFlugzeug
    {

        public void Tuckern()
        {
            Console.WriteLine("Tuckern");
        }

        public void Fliegen()
        {
            Console.WriteLine("Fliegen");
        }
    }
}