namespace Kniffel.Refactored.Scoring;

/// <summary>
/// Scores the sum of all dice when at least three match.
/// </summary>
public class ThreeOfAKindRule : ScoringRule
{
    public ThreeOfAKindRule() : base("Three of a Kind")
    {
    }

    public override Score CalculateScore(DiceRoll diceRoll)
    {
        return new Score(CanCalculateScore(diceRoll) ? diceRoll.Sum() : 0);
    }

    public override bool CanCalculateScore(DiceRoll diceRoll)
    {
        int[] counts = diceRoll.GetCounts();

        return counts.Any(c => c >= 3);
    }
}
