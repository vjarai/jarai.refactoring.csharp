using Kniffel.Refactored.Scoring;
using Xunit;

namespace Kniffel.Refactored.Tests;

public class ScoringRulesTests
{
    [Theory]
    [InlineData(1, 1, 2, 3, 4, 5, 1)]
    [InlineData(2, 1, 2, 2, 4, 5, 4)]
    [InlineData(3, 3, 3, 1, 5, 6, 6)]
    [InlineData(4, 4, 4, 4, 1, 2, 12)]
    [InlineData(5, 5, 1, 5, 2, 5, 15)]
    [InlineData(6, 6, 6, 6, 2, 1, 18)]
    public void Given_CountRule_When_DiceMatchFaceValue_Then_ReturnsSumOfMatchingDice(int faceValue, int d1, int d2, int d3, int d4, int d5, int expected)
    {
        var diceRoll = new DiceRoll(d1, d2, d3, d4, d5);
        ScoringRule rule = new CountRule(faceValue, "Count");

        var actual = rule.CalculateScore(diceRoll);

        Assert.Equal(expected, actual.Points);
    }

    [Fact]
    public void Given_ThreeOfAKindRule_When_ThreeOrMoreDiceAreEqual_Then_ReturnsSumOfAllDice()
    {
        var sut = new ThreeOfAKindRule();

        var actual = sut.CalculateScore(new DiceRoll(3, 3, 3, 4, 5));

        Assert.Equal(18, actual.Points);
    }

    [Fact]
    public void Given_ThreeOfAKindRule_When_NoDiceTriple_Then_ReturnsZero()
    {
        var sut = new ThreeOfAKindRule();

        var actual = sut.CalculateScore(new DiceRoll(1, 2, 3, 4, 5));

        Assert.Equal(0, actual.Points);
    }

    [Fact]
    public void Given_FourOfAKindRule_When_FourOrMoreDiceAreEqual_Then_ReturnsSumOfAllDice()
    {
        var sut = new FourOfAKindRule();

        var actual = sut.CalculateScore(new DiceRoll(2, 2, 2, 2, 5));

        Assert.Equal(13, actual.Points);
    }

    [Fact]
    public void Given_FourOfAKindRule_When_NoDiceQuad_Then_ReturnsZero()
    {
        var sut = new FourOfAKindRule();

        var actual = sut.CalculateScore(new DiceRoll(2, 2, 2, 3, 5));

        Assert.Equal(0, actual.Points);
    }

    [Fact]
    public void Given_FullHouseRule_When_ThreeAndTwoDiceAreEqual_Then_Returns25()
    {
        var sut = new FullHouseRule();

        var actual = sut.CalculateScore(new DiceRoll(2, 2, 3, 3, 3));

        Assert.Equal(25, actual.Points);
    }

    [Fact]
    public void Given_FullHouseRule_When_PatternIsMissing_Then_ReturnsZero()
    {
        var sut = new FullHouseRule();

        var actual = sut.CalculateScore(new DiceRoll(2, 2, 2, 2, 5));

        Assert.Equal(0, actual.Points);
    }

    [Fact]
    public void Given_SmallStraightRule_When_FourConsecutiveDicePresent_Then_Returns30()
    {
        var sut = new SmallStraightRule();

        var actual = sut.CalculateScore(new DiceRoll(1, 2, 3, 4, 6));

        Assert.Equal(30, actual.Points);
    }

    [Fact]
    public void Given_SmallStraightRule_When_NoConsecutiveSequence_Then_ReturnsZero()
    {
        var sut = new SmallStraightRule();

        var actual = sut.CalculateScore(new DiceRoll(1, 1, 3, 5, 6));

        Assert.Equal(0, actual.Points);
    }

    [Theory]
    [InlineData(1, 2, 3, 4, 5)]
    [InlineData(2, 3, 4, 5, 6)]
    public void Given_LargeStraightRule_When_FiveConsecutiveDicePresent_Then_Returns40(int d1, int d2, int d3, int d4, int d5)
    {
        var sut = new LargeStraightRule();

        var actual = sut.CalculateScore(new DiceRoll(d1, d2, d3, d4, d5));

        Assert.Equal(40, actual.Points);
    }

    [Fact]
    public void Given_LargeStraightRule_When_DicehaveduplicateValues_Then_ReturnsZero()
    {
        var sut = new LargeStraightRule();

        var actual = sut.CalculateScore(new DiceRoll(1, 2, 2, 4, 5));

        Assert.Equal(0, actual.Points);
    }

    [Fact]
    public void Given_KniffelRule_When_AllFiveDiceAreEqual_Then_Returns50()
    {
        var sut = new KniffelRule();

        var actual = sut.CalculateScore(new DiceRoll(6, 6, 6, 6, 6));

        Assert.Equal(50, actual.Points);
    }

    [Fact]
    public void Given_KniffelRule_When_NotAllDiceAreEqual_Then_ReturnsZero()
    {
        var sut = new KniffelRule();

        var actual = sut.CalculateScore(new DiceRoll(6, 6, 6, 6, 5));

        Assert.Equal(0, actual.Points);
    }

    [Fact]
    public void Given_ChanceRule_When_AnyDiceValues_Then_ReturnsSumOfAllDice()
    {
        var sut = new ChanceRule();

        var actual = sut.CalculateScore(new DiceRoll(2, 3, 4, 5, 1));

        Assert.Equal(15, actual.Points);
    }
}

public class DiceRollTests
{
    [Fact]
    public void Given_DiceRoll_When_DiceHaveMixedValues_Then_GetCountsReturnsFrequencyPerFace()
    {
        var diceRoll = new DiceRoll(1, 2, 2, 4, 6);

        var counts = diceRoll.GetCounts();

        Assert.Equal(new[] { 1, 2, 0, 1, 0, 1 }, counts);
    }

    [Fact]
    public void Given_DiceRoll_When_AllDiceAreIdentical_Then_GetCountsReturnsZerosExceptMatchingFace()
    {
        var diceRoll = new DiceRoll(5, 5, 5, 5, 5);

        var counts = diceRoll.GetCounts();

        Assert.Equal(new[] { 0, 0, 0, 0, 5, 0 }, counts);
    }

    [Fact]
    public void Given_DiceRoll_When_DiceInAnyOrder_Then_GetCountsIsOrderIndependent()
    {
        var diceRoll = new DiceRoll(6, 1, 6, 3, 1);

        var counts = diceRoll.GetCounts();

        Assert.Equal(new[] { 2, 0, 1, 0, 0, 2 }, counts);
    }
}
