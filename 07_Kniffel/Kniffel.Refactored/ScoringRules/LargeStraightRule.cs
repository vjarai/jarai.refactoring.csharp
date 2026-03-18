namespace Kniffel.Refactored.ScoringRules;

public class LargeStraightRule : ScoringRule
{
    public LargeStraightRule() : base(RuleId.LargeStraight, "Grosse Strasse")
    {
    }

    public override ScoringResult CalculateScore(Wurf wurf)
    {
        return new ScoringResult(CanCalculateScore(wurf) ? 40 : 0);
    }

    public override bool CanCalculateScore(Wurf wurf)
    {
        return wurf.GetCounts().Order().Skip(1).All(count => count == 1);
    }
}