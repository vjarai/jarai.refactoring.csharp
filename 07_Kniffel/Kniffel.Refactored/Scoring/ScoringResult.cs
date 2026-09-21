namespace Kniffel.Refactored.Scoring;

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

    
}