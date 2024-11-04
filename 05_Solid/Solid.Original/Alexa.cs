namespace Solid.Original
{
    public class Alexa
    {

        public void HandleRequest(string request)
        {
            request = request.ToLower();

            if (request.Contains("radio"))
                Console.WriteLine("Ich spiele Radio.");
            else if (request.Contains("licht"))
                Console.WriteLine("Ich schalte das Licht ein.");
            else if (request.Contains("wetter"))
                Console.WriteLine("Das Wetter ist sonnig.");
            else
                Console.WriteLine("Entschuldigung, '" + request + "' habe ich leider nicht verstanden (Fehlt ein Skill?).");

        }
    }
}