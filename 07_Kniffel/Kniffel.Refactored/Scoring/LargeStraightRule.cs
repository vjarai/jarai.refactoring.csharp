namespace Kniffel.Refactored.Scoring;

/// <summary>
/// Scores a fixed value for a large straight.
/// </summary>
public class LargeStraightRule : ScoringRule
{
    public LargeStraightRule() : base("Large Straight")
    {
    }

    public override Score CalculateScore(DiceRoll diceRoll)
    {
        return new Score(IsApplicableTo(diceRoll) ? 40 : 0);
    }

    public override bool IsApplicableTo(DiceRoll diceRoll)
    {
        return diceRoll.GetCounts().Order().Skip(1).All(count => count == 1);
    }
}
