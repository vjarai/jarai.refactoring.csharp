namespace Kniffel.Refactored.Scoring;

/// <summary>
/// Base type for all scoring rules.
/// </summary>
public abstract class ScoringRule
{
    /// <summary>
    ///     Default constructor needed for Moq mocking
    /// </summary>
    public ScoringRule()
    {
        RuleName = string.Empty;
    }

    protected ScoringRule(string ruleName)
    {
        RuleName = ruleName;
    }

    public string RuleName { get; private set; }

    public abstract Score CalculateScore(DiceRoll diceRoll);

    public abstract bool CanCalculateScore(DiceRoll diceRoll);
}
