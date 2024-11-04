namespace Solid.Refactored
{
    public class LampenSkill : AlexaSkill, IAlexaSkill
    {
        public override bool CanHandleRequest(string request)
        {
            return request.Contains("licht");
        }

        public override void HandleRequest(string request)
        {
            var parameter = GetParameter(request, "Licht", "<DefaultLampe>");
            Console.WriteLine($"Schalte Lampe {parameter} ein.");
        }
    }
}