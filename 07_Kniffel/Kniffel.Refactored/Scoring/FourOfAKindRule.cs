namespace Kniffel.Refactored.Scoring;

/// <summary>
/// Scores the sum of all dice when at least four match.
/// </summary>
public class FourOfAKindRule : ScoringRule
{
    public FourOfAKindRule() : base("Four of a Kind")
    {
    }

    public override Score CalculateScore(DiceRoll diceRoll)
    {
        return new Score(IsApplicableTo(diceRoll) ? diceRoll.Sum() : 0);
    }

    public override bool IsApplicableTo(DiceRoll diceRoll)
    {
        return diceRoll.GetCounts().Any(c => c >= 4);
    }
}
