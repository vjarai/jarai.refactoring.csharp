namespace Kniffel.Refactored.ScoringRules;

public class CountRule : ScoringRule
{
    private readonly int _zielWert;

    public CountRule(int zielWert, RuleId ruleId, string ruleName) : base(ruleId, ruleName)
    {
        _zielWert = zielWert;
    }

    public override ScoringResult CalculateScore(Wurf wurf)
    {
        return new ScoringResult(wurf.Count(wert => wert == _zielWert) * _zielWert);
    }

    public override bool CanCalculateScore(Wurf wurf)
    {
        return wurf.Any(wert => wert == _zielWert);
    }
}