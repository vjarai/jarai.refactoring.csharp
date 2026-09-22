namespace Kniffel.Refactored.Scoring;

/// <summary>
/// Represents a scoring result for a rule.
/// </summary>
public class Score
{
    public Score(int points, string ruleName)
    {
        RuleName = ruleName;
        Points = points;
    }

    public string RuleName { get; }
    public int Points { get; }

    public override string ToString()
    {
        return $"{RuleName,-20} : {Points}";
    }
}
