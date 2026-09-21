namespace Kniffel.Refactored.Scoring;

/// <summary>
/// Scores a fixed value for a full house pattern.
/// </summary>
public class FullHouseRule : ScoringRule
{
    public FullHouseRule() : base("Full House")
    {
    }

    public override Score CalculateScore(DiceRoll diceRoll)
    {
        return new Score(IsApplicableTo(diceRoll) ? 25 : 0);
    }

    public override bool IsApplicableTo(DiceRoll diceRoll)
    {
        int[] counts = diceRoll.GetCounts();

        return counts.Any(c => c == 3) && counts.Any(c => c == 2);
    }
}
