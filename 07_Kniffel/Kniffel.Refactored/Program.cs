using Kniffel.Refactored.ScoringRules;

namespace Kniffel.Refactored;

// Viktor@Jarai.de1

internal class Program
{
    private static void Main(string[] args)
    {
        // => Kniffel_Regeln sind im im _ReadMe Ordner dieses Projects

        // Dora hat drei Fünfen und zwei Dreien gewürfelt.
        // Sie hat nun vier Möglichkeiten:
        // ■ 25 Punkte für „Full House
        // ■ 21 Punkte für „Dreierpasch“
        // ■ 15 Punkte für die Fünfen
        // ■  6 Punkte für die Dreien

        //var wurf = new Wurf(5, 5, 5, 3, 3);
        //var wurf = new Wurf(3, 3, 3, 3, 3);
        //var wurf = new Wurf(4, 3, 2, 5,  1 );

        // TODO: Create KniffelScoringService with all rules via IoC Container
        var scoringService = CreateKniffelScoringService();

        do
        {
            var wurf = new Wurf();
            var scorings = scoringService.CalculateScorings(wurf);

            Console.WriteLine(wurf);

            foreach (var score in scorings)
            {
                Console.WriteLine(score);
            }

            Console.WriteLine("Noch einmal? (j/n)");
        } while (Console.ReadLine().ToUpper() != "N");
    }

    private static KniffelScoringService CreateKniffelScoringService()
    {
        var rules = new List<ScoringRule>
        {
            new CountRule(1, ScoreId.Ones, "Einer"),
            new CountRule(2, ScoreId.Twos, "Zweier"),
            new CountRule(3, ScoreId.Threes, "Dreier"),
            new CountRule(4, ScoreId.Fours, "Vierer"),
            new CountRule(5, ScoreId.Fives, "Fünfer"),
            new CountRule(6, ScoreId.Sixes, "Sechser"),

            new ThreeOfAKindRule(),
            new FourOfAKindRule(),
            new FullHouseRule(),
            new SmallStraightRule(),
            new LargeStraightRule(),
            new KniffelRule(),
            new ChanceRule()
        };

        return new KniffelScoringService(rules);
    }
}