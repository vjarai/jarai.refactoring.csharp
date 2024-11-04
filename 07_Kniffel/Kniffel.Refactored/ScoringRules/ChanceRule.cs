namespace Kniffel.Refactored.ScoringRules;

internal class ChanceRule : ScoringRule
{
    public ChanceRule() : base(ScoreId.Chance, "Chance")
    {
    }

    public override int CalculateScore(Wurf wurf)
    {
        return wurf.Sum();
    }

    public override bool CanCalculateScore(Wurf wurf)
    {
        return true;
    }
}