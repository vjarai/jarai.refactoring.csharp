namespace Kniffel.Refactored.Scoring;

/// <summary>
/// Scores a fixed value for a small straight.
/// </summary>
public class SmallStraightRule : ScoringRule
{
    public SmallStraightRule() : base("Small Straight")
    {
    }

    public override Score CalculateScore(DiceRoll diceRoll)
    {
        return new Score(IsApplicableTo(diceRoll) ? 30 : 0);
    }

    public override bool IsApplicableTo(DiceRoll diceRoll)
    {
        int[] counts = diceRoll.GetCounts();

        // Check for sequences 1-2-3-4, 2-3-4-5, or 3-4-5-6
        return (counts[0] >= 1 && counts[1] >= 1 && counts[2] >= 1 && counts[3] >= 1) ||
               (counts[1] >= 1 && counts[2] >= 1 && counts[3] >= 1 && counts[4] >= 1) ||
               (counts[2] >= 1 && counts[3] >= 1 && counts[4] >= 1 && counts[5] >= 1);
    }
}
