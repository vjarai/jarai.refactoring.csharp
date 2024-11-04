namespace Kniffel.Refactored.ScoringRules;

public class FourOfAKindRule : ScoringRule
{
    public FourOfAKindRule() : base(ScoreId.FourOfAKind, "Vierer Pasch")
    {
    }

    public override int CalculateScore(Wurf wurf)
    {
        return CanCalculateScore(wurf) ? wurf.Sum() : 0;
    }

    public override bool CanCalculateScore(Wurf wurf)
    {
        return wurf.GetCounts().Any(c => c >= 4);
    }
}