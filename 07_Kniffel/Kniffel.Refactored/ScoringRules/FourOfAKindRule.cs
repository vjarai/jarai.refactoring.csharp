namespace Kniffel.Refactored.ScoringRules;

public class FourOfAKindRule : ScoringRule
{
    public FourOfAKindRule() : base(RuleId.FourOfAKind, "Vierer Pasch")
    {
    }

    public override ScoringResult CalculateScore(Wurf wurf)
    {
        return new ScoringResult(CanCalculateScore(wurf) ? wurf.Sum() : 0);
    }

    public override bool CanCalculateScore(Wurf wurf)
    {
        return wurf.GetCounts().Any(c => c >= 4);
    }
}