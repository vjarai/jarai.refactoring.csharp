namespace Kniffel.Refactored.Scoring;

/// <summary>
/// Scores a fixed value when all five dice match.
/// </summary>
public class KniffelRule : ScoringRule
{
    public KniffelRule() : base("Kniffel")
    {
    }

    public override int CalculatePoints(DiceRoll diceRoll)
    {
        return 50;
    }

    public override bool IsApplicableTo(DiceRoll diceRoll)
    {
        return diceRoll.GetCounts().Any(c => c == 5);
    }
}
