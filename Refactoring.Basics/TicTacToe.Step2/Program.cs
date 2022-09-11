namespace Jarai.Refactoring.TicTacToe.Step2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var userInterface = new FakeUserInterface
            {
                ReadLineBuffer = new[] { "1", "4", "2", "5", "3" }
            };

            var game = new TicTacToeGame(userInterface);
            game.Play();
        }
    }
}