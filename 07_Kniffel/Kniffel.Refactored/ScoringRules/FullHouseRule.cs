namespace Kniffel.Refactored.ScoringRules;

public class FullHouseRule : ScoringRule
{
    public FullHouseRule() : base(ScoreId.FullHouse, "Full House")
    {
    }

    public override int CalculateScore(Wurf wurf)
    {
        return CanCalculateScore(wurf) ? 25 : 0;
    }

    public override bool CanCalculateScore(Wurf wurf)
    {
        int[] counts = wurf.GetCounts();

        return counts.Any(c => c == 3) && counts.Any(c => c == 2);
    }
}