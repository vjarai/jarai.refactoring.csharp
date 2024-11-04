namespace Kniffel.Refactored.ScoringRules;

public class CountRule : ScoringRule
{
    private readonly int _zielWert;

    public CountRule(int zielWert, ScoreId ruleId, string name) : base(ruleId, name)
    {
        _zielWert = zielWert;
    }

    public override int CalculateScore(Wurf wurf)
    {
        return wurf.Count(wert => wert == _zielWert) * _zielWert;
    }

    public override bool CanCalculateScore(Wurf wurf)
    {
        return wurf.Count(wert => wert == _zielWert) >= 1;
    }
}