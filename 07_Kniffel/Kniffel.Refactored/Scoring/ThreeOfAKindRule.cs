namespace Kniffel.Refactored.Scoring;

/// <summary>
/// Scores the sum of all dice when at least three match.
/// </summary>
public class ThreeOfAKindRule : ScoringRule
{
    public ThreeOfAKindRule() : base("Three of a Kind")
    {
    }

    public override int CalculatePoints(DiceRoll diceRoll)
    {
        return diceRoll.Sum();
    }

    public override bool IsApplicableTo(DiceRoll diceRoll)
    {
        int[] counts = diceRoll.GetCounts();

        return counts.Any(c => c >= 3);
    }
}
