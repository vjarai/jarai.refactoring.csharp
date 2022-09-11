namespace Jarai.Refactoring.TicTacToe.Step1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var game = new TicTacToeGame(new UserInterface());
            game.Play();
        }
    }
}