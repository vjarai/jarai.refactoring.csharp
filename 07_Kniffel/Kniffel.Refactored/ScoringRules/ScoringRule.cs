namespace Kniffel.Refactored.ScoringRules;

public abstract class ScoringRule
{
    /// <summary>
    ///     Default Construktor needed for Moq mocking
    /// </summary>
    public ScoringRule()
    {
        RuleName = string.Empty;
    }

    protected ScoringRule(RuleId ruleId, string ruleName)
    {
        RuleName = ruleName;
        RuleId = ruleId;
    }

    public string RuleName { get; private set; }

    public RuleId RuleId { get; private set; }


    public abstract int CalculateScore(Wurf wurf);

    public abstract bool CanCalculateScore(Wurf wurf);
}