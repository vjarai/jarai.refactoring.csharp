namespace Kniffel.Refactored.Scoring;

/// <summary>
/// Scores all dice matching a specific face value.
/// </summary>
public class CountRule : ScoringRule
{
    private readonly int _targetValue;

    public CountRule(int targetValue, string ruleName) : base(ruleName)
    {
        _targetValue = targetValue;
    }

    public override Score CalculateScore(DiceRoll diceRoll)
    {
        return new Score(diceRoll.Count(value => value == _targetValue) * _targetValue);
    }

    public override bool IsApplicableTo(DiceRoll diceRoll)
    {
        return diceRoll.Any(value => value == _targetValue);
    }
}
