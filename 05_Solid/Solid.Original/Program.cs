namespace Solid.Original
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var myAlexa = new Alexa();

            myAlexa.HandleRequest("Spiele Radio HR3");
            myAlexa.HandleRequest("Wie wird das Wetter?");
            myAlexa.HandleRequest("Schalte Licht Wohnzimmer ein");
            myAlexa.HandleRequest("BlaBla");

            Console.ReadLine();
        }
    }
}