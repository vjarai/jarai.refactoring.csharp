namespace Kniffel.Refactored.Scoring;

/// <summary>
/// Represents the full house rule and returns a fixed score when applicable.
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
