using System;
using System.Collections.Generic;
using System.Linq;
using Kniffel.Refactored.Scoring;
using Xunit;

namespace Kniffel.Refactored.Tests;

public class ScoringServiceTests
{

    [Fact]
    public void Given_ScoringService_When_MultipleRulesApply_Then_ScoresAreReturnedDescending()
    {
        var sut = new ScoringService([new KniffelRule(), new ThreeOfAKindRule(), new ChanceRule()]);

        var scores = sut.CalculateScores(new DiceRoll(4, 4, 4, 4, 4)).ToList();

        Assert.Equal(scores.OrderByDescending(s => s.Points), scores);
    }

    [Fact]
    public void Given_ScoringService_When_RuleScoresZero_Then_RuleIsExcludedFromResult()
    {
        var sut = new ScoringService([new ThreeOfAKindRule()]);

        var scores = sut.CalculateScores(new DiceRoll(1, 2, 3, 4, 5)).ToList();

        Assert.Empty(scores);
    }

    

    [Fact]
    public void Given_ScoringService_When_KniffelRolled_Then_HighestScoreIsKniffel()
    {
        var sut = new ScoringService();

        var scores = sut.CalculateScores(new DiceRoll(6, 6, 6, 6, 6)).ToList();

        Assert.Equal(50, scores[0].Points);
    }

    [Fact]
    public void Given_ScoringService_When_NoRuleApplies_Then_ResultIsEmpty()
    {
        var sut = new ScoringService([new KniffelRule()]);

        var scores = sut.CalculateScores(new DiceRoll(1, 2, 3, 4, 5)).ToList();

        Assert.Empty(scores);
    }

   
}
