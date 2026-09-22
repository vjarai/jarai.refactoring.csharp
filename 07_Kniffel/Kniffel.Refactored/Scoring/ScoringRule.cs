namespace Kniffel.Refactored.Scoring;

/// <summary>
/// Base type for all scoring rules.
/// </summary>
public abstract class ScoringRule
{
    
    /// <summary>
    /// Initializes a new scoring rule with the specified rule name.
    /// </summary>
    /// <param name="ruleName">The display name of the scoring rule.</param>
    protected ScoringRule(string ruleName)
    {
        RuleName = ruleName;
    }

    public string RuleName { get; private set; }

    /// <summary>
    /// Calculates the points for this rule based on the given dice roll.
    /// </summary>
    /// <param name="diceRoll">The dice roll to evaluate.</param>
    /// <returns>The number of points awarded by this rule.</returns>
    public abstract int CalculatePoints(DiceRoll diceRoll);

    /// <summary>
    /// Determines whether this rule can be applied to the given dice roll.
    /// </summary>
    /// <param name="diceRoll">The dice roll to check.</param>
    /// <returns><c>true</c> if the rule is applicable; otherwise, <c>false</c>.</returns>
    public abstract bool IsApplicableTo(DiceRoll diceRoll);
}
