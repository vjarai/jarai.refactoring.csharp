using Kniffel.Refactored.ScoringRules;

namespace Kniffel.Refactored;

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
        _rules = CreateDefaultRules();
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


    private IEnumerable<ScoringRule> CreateDefaultRules()
    {
        return new List<ScoringRule>
        {
            new CountRule(1, RuleId.Ones, "Einer"),
            new CountRule(2, RuleId.Twos, "Zweier"),
            new CountRule(3, RuleId.Threes, "Dreier"),
            new CountRule(4, RuleId.Fours, "Vierer"),
            new CountRule(5, RuleId.Fives, "Fünfer"),
            new CountRule(6, RuleId.Sixes, "Sechser"),

            new ThreeOfAKindRule(),
            new FourOfAKindRule(),
            new FullHouseRule(),
            new SmallStraightRule(),
            new LargeStraightRule(),
            new KniffelRule(),
            new ChanceRule()
        };
    }
}