namespace Kniffel.Refactored.ScoringRules;

public class ThreeOfAKindRule : ScoringRule
{
    public ThreeOfAKindRule() : base(RuleId.ThreeOfAKind, "Dreier Pasch")
    {
    }

    public override ScoringResult CalculateScore(Wurf wurf)
    {
        return new ScoringResult(CanCalculateScore(wurf) ? wurf.Sum() : 0);
    }

    public override bool CanCalculateScore(Wurf wurf)
    {
        int[] counts = wurf.GetCounts();

        return counts.Any(c => c >= 3);
    }
}