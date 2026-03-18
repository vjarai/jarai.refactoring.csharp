namespace Kniffel.Refactored.ScoringRules;

internal class ChanceRule : ScoringRule
{
    public ChanceRule() : base(RuleId.Chance, "Chance")
    {
    }

    public override ScoringResult CalculateScore(Wurf wurf)
    {
        return new ScoringResult( wurf.Sum());
    }

    public override bool CanCalculateScore(Wurf wurf)
    {
        return true;
    }
}