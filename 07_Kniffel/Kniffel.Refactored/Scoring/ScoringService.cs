namespace Kniffel.Refactored.Scoring;

/// <summary>
/// Calculates available scores for a dice roll.
/// </summary>
public class ScoringService
{
    private readonly IEnumerable<ScoringRule> _rules;

    /// <summary>
    ///     Constructor enables injection of dependencies.
    /// </summary>
    public ScoringService(IEnumerable<ScoringRule> rules)
    {
        _rules = rules;
    }

    public ScoringService()
    {
        _rules = CreateRulesViaReflection();
    }

    public IEnumerable<Score> CalculateScorings(DiceRoll diceRoll)
    {
        return from rule in _rules
            let result = rule.CalculateScore(diceRoll)
            where result.Points > 0
            orderby result.Points descending
            select new Score(result.Points, rule.RuleName);
    }

    public IEnumerable<ScoringRule> CreateRulesViaReflection()
    {
        var rules = new List<ScoringRule>
        {
            new CountRule(1, "Ones"),
            new CountRule(2, "Twos"),
            new CountRule(3, "Threes"),
            new CountRule(4, "Fours"),
            new CountRule(5, "Fives"),
            new CountRule(6, "Sixes")
        };

        var asm = typeof(Program).Assembly;
        var ruleType = typeof(ScoringRule);

        var reflectedRules = asm.GetTypes()
            .Where(t => ruleType.IsAssignableFrom(t) && !t.IsAbstract && t != typeof(CountRule))
            .Where(t => t.GetConstructor(Type.EmptyTypes) != null)
            .Select(t => (ScoringRule?)Activator.CreateInstance(t))
            .Where(r => r is not null)
            .Select(r => r!)
            .OrderBy(r => r.GetType().Name)
            .ToList();

        rules.AddRange(reflectedRules);
        return rules;
    }
}
