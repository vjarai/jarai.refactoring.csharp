namespace Solid.Refactored
{
    public interface IAlexaSkill
    {
        bool CanHandleRequest(string request);
        void HandleRequest(string request);
    }
}