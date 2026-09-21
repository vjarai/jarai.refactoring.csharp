namespace Kniffel.Refactored.Scoring;

/// <summary>
/// Represents a scoring result for a rule.
/// </summary>
public class Score
{
    public Score(int points, string? ruleName = null)
    {
        RuleName = ruleName ?? string.Empty;
        Points = points;
    }

    public string RuleName { get; }
    public int Points { get; }
}
