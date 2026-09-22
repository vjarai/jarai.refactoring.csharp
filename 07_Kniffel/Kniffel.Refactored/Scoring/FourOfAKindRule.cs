namespace Kniffel.Refactored.Scoring;

/// <summary>
/// Scores the sum of all dice when at least four match.
/// </summary>
public class FourOfAKindRule : ScoringRule
{
    public FourOfAKindRule() : base("Four of a Kind")
    {
    }

    public override int CalculatePoints(DiceRoll diceRoll)
    {
        return diceRoll.Sum();
    }

    public override bool IsApplicableTo(DiceRoll diceRoll)
    {
        return diceRoll.GetCounts().Any(c => c >= 4);
    }
}
