using Kniffel.Refactored.ScoringRules;

namespace Kniffel.Refactored;

public class KniffelScoringService
{
    private readonly IEnumerable<ScoringRule> _rules;

    /// <summary>
    ///     Constructor enables injection of Depencies
    /// </summary>
    public KniffelScoringService(IEnumerable<ScoringRule> rules)
    {
        _rules = rules;
    }


    public KniffelScoringService()
    {
        _rules = CreateDefaultRules();
    }

    public int CalculateScore(ScoreId scoreId, Wurf wurf)
    {
        var rule = _rules.Single(r => r.ScoreId == scoreId);

        return rule.CalculateScore(wurf);
    }

    public IEnumerable<ScoringResult> CalculateScorings(Wurf wurf)
    {
        return from rule in _rules
            let result = rule.CalculateScore(wurf)
            where result > 0
            orderby result descending
            select new ScoringResult(rule.ScoreId, result, rule.Name);
    }


    private IEnumerable<ScoringRule> CreateDefaultRules()
    {
        return new List<ScoringRule>
        {
            new CountRule(1, ScoreId.Ones, "Einer"),
            new CountRule(2, ScoreId.Twos, "Zweier"),
            new CountRule(3, ScoreId.Threes, "Dreier"),
            new CountRule(4, ScoreId.Fours, "Vierer"),
            new CountRule(5, ScoreId.Fives, "Fünfer"),
            new CountRule(6, ScoreId.Sixes, "Sechser"),

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