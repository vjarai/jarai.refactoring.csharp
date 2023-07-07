using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntwickeltVonMaxMustermann
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Der Computer denkt sich ein zufällige Zahl im Bereich 1 bis 100 aus: int geheimzahl = new Random().Next(1, 101);
            int z = new Random().Next(1, 101);
            Console.WriteLine("Errate eine Zahl zwischen 1 und 100");
            //Nachdem der Anwender einen Tipp eingegeben hat, antwortet der Computer, ob der Tipp "Zu klein.", "Zu groß." oder "Richtig!" war.
            int e = int.Parse(Console.ReadLine());
            int g = 0;
            int a = 0;
            while (g == 0)
            {

                if (e == z) { Console.WriteLine("Richtig"); g = 1; Console.WriteLine($"du hast" + a + "Versuche gebraucht"); Console.ReadLine(); }
                else if (z > e) { Console.WriteLine("Ihre Zahl ist zu klein"); e = int.Parse(Console.ReadLine()); }
                else if (z < e) { Console.WriteLine("Ihre Zahl ist zu groß"); e = int.Parse(Console.ReadLine()); }
                a++; Console.WriteLine("Bitte Versuchen sie es erneut");
            }

        }
        //Der Anwender muss so lange einen Tipp eingeben, bis er die richtige Zahl erraten hat. 
        //Der Computer zeigt am Ende an, wieviele Versuche der Anwender benötigt hat.
    }
}

