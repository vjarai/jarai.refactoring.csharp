namespace Kniffel.Refactored.Scoring;

/// <summary>
/// Scores a fixed value for a large straight.
/// </summary>
public class LargeStraightRule : ScoringRule
{
    public LargeStraightRule() : base("Large Straight")
    {
    }

    public override int CalculatePoints(DiceRoll diceRoll)
    {
        return 40;
    }

    public override bool IsApplicableTo(DiceRoll diceRoll)
    {
        var sequence = diceRoll.Distinct().OrderBy(value => value).ToArray();

        return sequence.SequenceEqual([1, 2, 3, 4, 5])
            || sequence.SequenceEqual([2, 3, 4, 5, 6]);
    }
}
