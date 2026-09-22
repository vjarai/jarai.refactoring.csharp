namespace Kniffel.Refactored.Scoring;

/// <summary>
/// Scores a fixed value for a full house pattern.
/// </summary>
public class FullHouseRule : ScoringRule
{
    public FullHouseRule() : base("Full House")
    {
    }

    public override int CalculatePoints(DiceRoll diceRoll)
    {
        return 25;
    }

    public override bool IsApplicableTo(DiceRoll diceRoll)
    {
        int[] counts = diceRoll.GetCounts();

        return counts.Any(c => c == 3) && counts.Any(c => c == 2);
    }
}
