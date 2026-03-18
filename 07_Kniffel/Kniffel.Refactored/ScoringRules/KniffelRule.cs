namespace Kniffel.Refactored.ScoringRules;

public class KniffelRule : ScoringRule
{
    public KniffelRule() : base(RuleId.Kniffel, "Kniffel")
    {
    }

    public override ScoringResult CalculateScore(Wurf wurf)
    {
        return new ScoringResult(CanCalculateScore(wurf) ? 50 : 0);
    }

    public override bool CanCalculateScore(Wurf wurf)
    {
        return wurf.GetCounts().Any(c => c == 5);
    }
}