﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Resharper.InheritanceToDelegation
{
    public class Flugzeug : IFlugzeug
    {
        public void Fliegen()
        {
            Console.WriteLine("Fliegen");
        }
    }
}