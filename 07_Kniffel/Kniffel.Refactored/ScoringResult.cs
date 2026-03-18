namespace Kniffel.Refactored;

public class ScoringResult
{
    public ScoringResult(int score, RuleId ruleId = default, string? ruleName = null)
    {
        RuleId = ruleId;
        RuleName = ruleName ?? ruleId.ToString();
        Score = score;
    }

    public RuleId RuleId { get; }
    public string RuleName { get; }
    public int Score { get; }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;

        var other = (ScoringResult)obj;

        return other.Equals(this);
    }

    protected bool Equals(ScoringResult other)
    {
        return RuleId == other.RuleId && Score == other.Score;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(RuleName, Score);
    }

    public override string ToString()
    {
        return $"{Score:d2} : {RuleName}";
    }
}