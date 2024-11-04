namespace Kniffel.Refactored;

public class ScoringResult
{
    public ScoringResult(ScoreId scoreId, int score, string? ruleName = null)
    {
        ScoreId = scoreId;
        RuleName = ruleName ?? scoreId.ToString();
        Score = score;
    }

    public ScoreId ScoreId { get; }
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
        return ScoreId == other.ScoreId && Score == other.Score;
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