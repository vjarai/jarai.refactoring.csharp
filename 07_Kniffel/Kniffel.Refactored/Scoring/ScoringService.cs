namespace Kniffel.Refactored.Scoring;

/// <summary>
/// Calculates available scores for a dice roll.
/// </summary>
public class ScoringService
{
    private readonly IEnumerable<ScoringRule> _rules;

    /// <summary>
    /// Initializes a new instance with injected scoring rules.
    /// </summary>
    /// <param name="rules">The scoring rules used to calculate available scores.</param>
    public ScoringService(IEnumerable<ScoringRule> rules)
    {
        _rules = rules;
    }

    /// <summary>
    /// Initializes a new instance and creates scoring rules via reflection.
    /// </summary>
    public ScoringService()
    {
        _rules = DiscoverRules();
    }

    /// <summary>
    /// Calculates all available scores for the given dice roll.
    /// </summary>
    /// <param name="diceRoll">The dice roll to evaluate.</param>
    /// <returns>A descending list of scores with points greater than zero.</returns>
    public IEnumerable<Score> CalculateScores(DiceRoll diceRoll)
    {
        return from rule in _rules
               where rule.IsApplicableTo(diceRoll)
               let points = rule.CalculatePoints(diceRoll)
               //where result.Points > 0
               orderby points descending
               select new Score(points, rule.RuleName);
    }

    /// <summary>
    /// Creates scoring rules by combining fixed count rules with reflected rule implementations.
    /// </summary>
    /// <returns>The complete collection of scoring rules.</returns>
    public IEnumerable<ScoringRule> DiscoverRules()
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
