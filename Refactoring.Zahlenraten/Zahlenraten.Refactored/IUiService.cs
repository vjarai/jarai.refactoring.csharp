namespace Jarai.Refactoring.Zahlenraten.Refactored
{
    public interface IUiService
    {
        string ReadLine();
        void WriteLine(string message);
        void WriteInputToSmall();
        void WriteInputToBig();
        void WriteInputCorrect();
    }
}