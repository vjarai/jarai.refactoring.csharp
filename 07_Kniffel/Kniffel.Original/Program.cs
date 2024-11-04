using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarai.Refactoring.Kniffel.Original
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new Kniffel(1,2,3,4,4);

            game.Fours();

        }
    }
}
