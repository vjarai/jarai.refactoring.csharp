using Xunit;

namespace Kniffel.Refactored.Tests;

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