using Kniffel.Refactored.Scoring;

namespace Kniffel.Refactored;

/// <summary>
/// Entry point of the Kniffel.Refactored console application.
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        var scoringService = new ScoringService();

        do
        {
            var diceRoll = new DiceRoll();
            var scorings = scoringService.CalculateScorings(diceRoll);

            Console.WriteLine(diceRoll);

            foreach (var score in scorings)
            {
                Console.WriteLine(score);
            }

            Console.WriteLine("Roll again? (y/n)");
        } while (!string.Equals(Console.ReadLine(), "n", StringComparison.OrdinalIgnoreCase));
    }
}