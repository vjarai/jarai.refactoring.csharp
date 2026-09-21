namespace Kniffel.Refactored.Scoring;

public class ScoringService
{
    private readonly IEnumerable<ScoringRule> _rules;

    /// <summary>
    ///     Constructor enables injection of Depencies
    /// </summary>
    public ScoringService(IEnumerable<ScoringRule> rules)
    {
        _rules = rules;
    }


    public ScoringService()
    {
        _rules = CreateRulesViaReflection();
    }

    public ScoringResult CalculateScore(RuleId ruleId, Wurf wurf)
    {
        var rule = _rules.Single(r => r.RuleId == ruleId);

        return rule.CalculateScore(wurf);
    }

    public IEnumerable<ScoringResult> CalculateScorings(Wurf wurf)
    {
        return from rule in _rules
            let result = rule.CalculateScore(wurf)
            where result.Score > 0
            orderby result.Score descending
            select new ScoringResult(result.Score, rule.RuleId, rule.RuleName);
    }


    public IEnumerable<ScoringRule> CreateRulesViaReflection()
    {
        // Erst Count-Regeln in definierter Reihenfolge hinzufügen
        var rules = new List<ScoringRule>
        {
            new CountRule(1, RuleId.Ones, "Einer"),
            new CountRule(2, RuleId.Twos, "Zweier"),
            new CountRule(3, RuleId.Threes, "Dreier"),
            new CountRule(4, RuleId.Fours, "Vierer"),
            new CountRule(5, RuleId.Fives, "Fünfer"),
            new CountRule(6, RuleId.Sixes, "Sechser")
        };

        // Restliche ScoringRule-Implementierungen per Reflection finden und instanzieren
        var asm = typeof(Program).Assembly;
        var ruleType = typeof(ScoringRule);

        var reflectedRules = asm.GetTypes()
            .Where(t => ruleType.IsAssignableFrom(t) && !t.IsAbstract && t != typeof(CountRule))
            .Where(t => t.GetConstructor(Type.EmptyTypes) != null)
            .Select(t => (ScoringRule?)Activator.CreateInstance(t))
            .Where(r => r is not null)
            .Select(r => r!)
            // Stabile Reihenfolge nach RuleId (enum) erzeugen
            .OrderBy(r => (int)r.RuleId)
            .ToList();

        rules.AddRange(reflectedRules);
        return rules;
    }
}