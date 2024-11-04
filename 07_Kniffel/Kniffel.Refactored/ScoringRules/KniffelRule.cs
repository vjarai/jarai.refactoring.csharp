namespace Kniffel.Refactored.ScoringRules;

public class KniffelRule : ScoringRule
{
    public KniffelRule() : base(ScoreId.Kniffel, "Kniffel")
    {
    }

    public override int CalculateScore(Wurf wurf)
    {
        return CanCalculateScore(wurf) ? 50 : 0;
    }

    public override bool CanCalculateScore(Wurf wurf)
    {
        return wurf.GetCounts().Any(c => c == 5);
    }
}