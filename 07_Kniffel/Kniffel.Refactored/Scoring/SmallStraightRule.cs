namespace Kniffel.Refactored.Scoring;

/// <summary>
/// Represents the small straight rule and returns a fixed score when applicable.
/// </summary>
public class SmallStraightRule : ScoringRule
{
    public SmallStraightRule() : base("Small Straight")
    {
    }

    public override int CalculatePoints(DiceRoll diceRoll)
    {
        return 30;
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
