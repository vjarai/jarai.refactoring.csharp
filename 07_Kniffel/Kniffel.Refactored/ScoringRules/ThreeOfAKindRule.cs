namespace Kniffel.Refactored.ScoringRules;

public class ThreeOfAKindRule : ScoringRule
{
    public ThreeOfAKindRule() : base(ScoreId.ThreeOfAKind, "Dreier Pasch")
    {
    }

    public override int CalculateScore(Wurf wurf)
    {
        return CanCalculateScore(wurf) ? wurf.Sum() : 0;
    }

    public override bool CanCalculateScore(Wurf wurf)
    {
        int[] counts = wurf.GetCounts();

        return counts.Any(c => c >= 3);
    }
}