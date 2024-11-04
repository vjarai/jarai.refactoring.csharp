namespace Kniffel.Refactored.ScoringRules;

public class SmallStraightRule : ScoringRule
{
    public SmallStraightRule() : base(ScoreId.SmallStraight, "Kleine Strasse")
    {
    }

    public override int CalculateScore(Wurf wurf)
    {
        return CanCalculateScore(wurf) ? 30 : 0;
    }

    public override bool CanCalculateScore(Wurf wurf)
    {
        int[] counts = wurf.GetCounts();

        // Check for sequences 1-2-3-4, 2-3-4-5, or 3-4-5-6
        return (counts[0] >= 1 && counts[1] >= 1 && counts[2] >= 1 && counts[3] >= 1) ||
               (counts[1] >= 1 && counts[2] >= 1 && counts[3] >= 1 && counts[4] >= 1) ||
               (counts[2] >= 1 && counts[3] >= 1 && counts[4] >= 1 && counts[5] >= 1);
    }
}