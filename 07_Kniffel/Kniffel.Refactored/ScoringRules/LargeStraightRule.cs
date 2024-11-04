namespace Kniffel.Refactored.ScoringRules;

public class LargeStraightRule : ScoringRule
{
    public LargeStraightRule() : base(ScoreId.LargeStraight, "Grosse Strasse")
    {
    }

    public override int CalculateScore(Wurf wurf)
    {
        return CanCalculateScore(wurf) ? 40 : 0;
    }

    public override bool CanCalculateScore(Wurf wurf)
    {
        return wurf.GetCounts().Order().Skip(1).All(count => count == 1);
    }
}