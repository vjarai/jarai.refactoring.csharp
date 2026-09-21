namespace Kniffel.Refactored.Scoring;

/// <summary>
/// Scores the sum of all dice.
/// </summary>
internal class ChanceRule : ScoringRule
{
    public ChanceRule() : base("Chance")
    {
    }

    public override Score CalculateScore(DiceRoll diceRoll)
    {
        return new Score(diceRoll.Sum());
    }

    public override bool CanCalculateScore(DiceRoll diceRoll)
    {
        return true;
    }
}
