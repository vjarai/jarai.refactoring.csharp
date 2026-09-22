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
    public void Given_CountRule_When_DiceContainTargetValue_Then_ReturnsSumOfTargetValues(int faceValue, int d1, int d2, int d3, int d4, int d5, int expected)
    {
        var diceRoll = new DiceRoll(d1, d2, d3, d4, d5);
        ScoringRule rule = new CountRule(faceValue, "Count");

        var actual = rule.CalculatePoints(diceRoll);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Given_CountRule_When_TargetValueExists_Then_IsApplicableToReturnsTrue()
    {
        var sut = new CountRule(4, "Fours");

        var actual = sut.IsApplicableTo(new DiceRoll(1, 2, 4, 5, 6));

        Assert.True(actual);
    }

    [Fact]
    public void Given_CountRule_When_TargetValueDoesNotExist_Then_IsApplicableToReturnsFalse()
    {
        var sut = new CountRule(4, "Fours");

        var actual = sut.IsApplicableTo(new DiceRoll(1, 2, 3, 5, 6));

        Assert.False(actual);
    }

    [Fact]
    public void Given_ThreeOfAKindRule_When_AtLeastThreeDiceMatch_Then_ReturnsSumOfAllDice()
    {
        var sut = new ThreeOfAKindRule();

        var actual = sut.CalculatePoints(new DiceRoll(3, 3, 3, 4, 5));

        Assert.Equal(18, actual);
    }

    [Fact]
    public void Given_ThreeOfAKindRule_When_AtLeastThreeDiceMatch_Then_IsApplicableToReturnsTrue()
    {
        var sut = new ThreeOfAKindRule();

        var actual = sut.IsApplicableTo(new DiceRoll(3, 3, 3, 4, 5));

        Assert.True(actual);
    }

    [Fact]
    public void Given_ThreeOfAKindRule_When_LessThanThreeDiceMatch_Then_IsApplicableToReturnsFalse()
    {
        var sut = new ThreeOfAKindRule();

        var actual = sut.IsApplicableTo(new DiceRoll(1, 2, 3, 4, 5));

        Assert.False(actual);
    }

    [Fact]
    public void Given_FourOfAKindRule_When_AtLeastFourDiceMatch_Then_ReturnsSumOfAllDice()
    {
        var sut = new FourOfAKindRule();

        var actual = sut.CalculatePoints(new DiceRoll(2, 2, 2, 2, 5));

        Assert.Equal(13, actual);
    }

    [Fact]
    public void Given_FourOfAKindRule_When_AtLeastFourDiceMatch_Then_IsApplicableToReturnsTrue()
    {
        var sut = new FourOfAKindRule();

        var actual = sut.IsApplicableTo(new DiceRoll(2, 2, 2, 2, 5));

        Assert.True(actual);
    }

    [Fact]
    public void Given_FourOfAKindRule_When_LessThanFourDiceMatch_Then_IsApplicableToReturnsFalse()
    {
        var sut = new FourOfAKindRule();

        var actual = sut.IsApplicableTo(new DiceRoll(2, 2, 3, 4, 5));

        Assert.False(actual);
    }

    [Fact]
    public void Given_FullHouseRule_When_FullHousePatternExists_Then_Returns25()
    {
        var sut = new FullHouseRule();

        var actual = sut.CalculatePoints(new DiceRoll(2, 2, 3, 3, 3));

        Assert.Equal(25, actual);
    }

    [Fact]
    public void Given_FullHouseRule_When_FullHousePatternExists_Then_IsApplicableToReturnsTrue()
    {
        var sut = new FullHouseRule();

        var actual = sut.IsApplicableTo(new DiceRoll(2, 2, 3, 3, 3));

        Assert.True(actual);
    }

    [Fact]
    public void Given_FullHouseRule_When_FullHousePatternDoesNotExist_Then_IsApplicableToReturnsFalse()
    {
        var sut = new FullHouseRule();

        var actual = sut.IsApplicableTo(new DiceRoll(2, 2, 2, 4, 5));

        Assert.False(actual);
    }

    [Fact]
    public void Given_SmallStraightRule_When_SmallStraightExists_Then_Returns30()
    {
        var sut = new SmallStraightRule();

        var actual = sut.CalculatePoints(new DiceRoll(1, 2, 3, 4, 6));

        Assert.Equal(30, actual);
    }

    [Fact]
    public void Given_SmallStraightRule_When_SmallStraightExists_Then_IsApplicableToReturnsTrue()
    {
        var sut = new SmallStraightRule();

        var actual = sut.IsApplicableTo(new DiceRoll(1, 2, 3, 4, 6));

        Assert.True(actual);
    }

    [Fact]
    public void Given_SmallStraightRule_When_SmallStraightDoesNotExist_Then_IsApplicableToReturnsFalse()
    {
        var sut = new SmallStraightRule();

        var actual = sut.IsApplicableTo(new DiceRoll(1, 1, 3, 5, 6));

        Assert.False(actual);
    }

    [Theory]
    [InlineData(1, 2, 3, 4, 5)]
    [InlineData(2, 3, 4, 5, 6)]
    public void Given_LargeStraightRule_When_LargeStraightExists_Then_Returns40(int d1, int d2, int d3, int d4, int d5)
    {
        var sut = new LargeStraightRule();

        var actual = sut.CalculatePoints(new DiceRoll(d1, d2, d3, d4, d5));

        Assert.Equal(40, actual);
    }

    [Theory]
    [InlineData(1, 2, 3, 4, 5)]
    [InlineData(2, 3, 4, 5, 6)]
    public void Given_LargeStraightRule_When_LargeStraightExists_Then_IsApplicableToReturnsTrue(int d1, int d2, int d3, int d4, int d5)
    {
        var sut = new LargeStraightRule();

        var actual = sut.IsApplicableTo(new DiceRoll(d1, d2, d3, d4, d5));

        Assert.True(actual);
    }

    [Fact]
    public void Given_LargeStraightRule_When_LargeStraightDoesNotExist_Then_IsApplicableToReturnsFalse()
    {
        var sut = new LargeStraightRule();

        var actual = sut.IsApplicableTo(new DiceRoll(1, 2, 3, 4, 6));

        Assert.False(actual);
    }

    [Fact]
    public void Given_KniffelRule_When_AllFiveDiceMatch_Then_Returns50()
    {
        var sut = new KniffelRule();

        var actual = sut.CalculatePoints(new DiceRoll(6, 6, 6, 6, 6));

        Assert.Equal(50, actual);
    }

    [Fact]
    public void Given_KniffelRule_When_AllFiveDiceMatch_Then_IsApplicableToReturnsTrue()
    {
        var sut = new KniffelRule();

        var actual = sut.IsApplicableTo(new DiceRoll(6, 6, 6, 6, 6));

        Assert.True(actual);
    }

    [Fact]
    public void Given_KniffelRule_When_NotAllFiveDiceMatch_Then_IsApplicableToReturnsFalse()
    {
        var sut = new KniffelRule();

        var actual = sut.IsApplicableTo(new DiceRoll(6, 6, 6, 6, 5));

        Assert.False(actual);
    }

    [Fact]
    public void Given_ChanceRule_When_AnyDiceRoll_Then_ReturnsSumOfAllDice()
    {
        var sut = new ChanceRule();

        var actual = sut.CalculatePoints(new DiceRoll(2, 3, 4, 5, 1));

        Assert.Equal(15, actual);
    }

    [Fact]
    public void Given_ChanceRule_When_AnyDiceRoll_Then_IsApplicableToReturnsTrue()
    {
        var sut = new ChanceRule();

        var actual = sut.IsApplicableTo(new DiceRoll(1, 2, 3, 4, 5));

        Assert.True(actual);
    }

    [Fact]
    public void Given_ChanceRule_When_AnotherDiceRoll_Then_IsApplicableToReturnsTrue()
    {
        var sut = new ChanceRule();

        var actual = sut.IsApplicableTo(new DiceRoll(6, 6, 6, 6, 6));

        Assert.True(actual);
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
