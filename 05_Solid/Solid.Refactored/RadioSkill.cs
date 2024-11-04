namespace Solid.Refactored
{
    public class RadioSkill : AlexaSkill, IAlexaSkill
    {
        public override bool CanHandleRequest(string request)
        {
            return request.Contains("radio");
        }

        public override void HandleRequest(string request)
        {
            var parameter = GetParameter(request, "Radio", "<DefaultSender>");

            Console.WriteLine($"Ich spiele den Radiosender '{parameter}'.");
        }
    }
}