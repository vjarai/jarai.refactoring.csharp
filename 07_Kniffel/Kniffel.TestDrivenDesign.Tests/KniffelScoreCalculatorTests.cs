using Kniffel.TestDrivenDesign.Scoring;

namespace Kniffel.TestDrivenDesign.Tests;

public class KniffelScoreCalculatorTests
{
    [Theory]
    [InlineData(ScoreCategory.Ones, new[] { 1, 1, 2, 3, 4 }, 2)]
    [InlineData(ScoreCategory.Twos, new[] { 2, 2, 1, 3, 4 }, 4)]
    [InlineData(ScoreCategory.Threes, new[] { 3, 3, 1, 2, 4 }, 6)]
    [InlineData(ScoreCategory.Fours, new[] { 4, 4, 1, 2, 3 }, 8)]
    [InlineData(ScoreCategory.Fives, new[] { 5, 5, 1, 2, 3 }, 10)]
    [InlineData(ScoreCategory.Sixes, new[] { 6, 6, 1, 2, 3 }, 12)]
    public void UpperSection_ReturnsSumForMatchingFace(ScoreCategory category, int[] dice, int expectedScore)
    {
        var score = KniffelScoreCalculator.CalculateScore(dice, category);

        Assert.Equal(expectedScore, score);
    }

    [Theory]
    [InlineData(ScoreCategory.Ones)]
    [InlineData(ScoreCategory.Twos)]
    [InlineData(ScoreCategory.Threes)]
    [InlineData(ScoreCategory.Fours)]
    [InlineData(ScoreCategory.Fives)]
    [InlineData(ScoreCategory.Sixes)]
    public void UpperSection_ReturnsZeroWhenFaceIsMissing(ScoreCategory category)
    {
        var dice = category switch
        {
            ScoreCategory.Ones => new[] { 2, 3, 4, 5, 6 },
            ScoreCategory.Twos => new[] { 1, 3, 4, 5, 6 },
            ScoreCategory.Threes => new[] { 1, 2, 4, 5, 6 },
            ScoreCategory.Fours => new[] { 1, 2, 3, 5, 6 },
            ScoreCategory.Fives => new[] { 1, 2, 3, 4, 6 },
            ScoreCategory.Sixes => new[] { 1, 2, 3, 4, 5 },
            _ => throw new ArgumentOutOfRangeException(nameof(category), category, null)
        };

        var score = KniffelScoreCalculator.CalculateScore(dice, category);

        Assert.Equal(0, score);
    }

    [Fact]
    public void ThreeOfAKind_ReturnsDiceSum_WhenAtLeastThreeDiceMatch()
    {
        var score = KniffelScoreCalculator.CalculateScore([4, 4, 4, 2, 6], ScoreCategory.ThreeOfAKind);

        Assert.Equal(20, score);
    }

    [Fact]
    public void ThreeOfAKind_ReturnsZero_WhenLessThanThreeDiceMatch()
    {
        var score = KniffelScoreCalculator.CalculateScore([1, 1, 2, 3, 4], ScoreCategory.ThreeOfAKind);

        Assert.Equal(0, score);
    }

    [Fact]
    public void FourOfAKind_ReturnsDiceSum_WhenAtLeastFourDiceMatch()
    {
        var score = KniffelScoreCalculator.CalculateScore([5, 5, 5, 5, 2], ScoreCategory.FourOfAKind);

        Assert.Equal(22, score);
    }

    [Fact]
    public void FourOfAKind_ReturnsZero_WhenLessThanFourDiceMatch()
    {
        var score = KniffelScoreCalculator.CalculateScore([6, 6, 6, 2, 1], ScoreCategory.FourOfAKind);

        Assert.Equal(0, score);
    }

    [Fact]
    public void FullHouse_ReturnsFixedScore_WhenThreeAndTwoDiceMatch()
    {
        var score = KniffelScoreCalculator.CalculateScore([2, 2, 3, 3, 3], ScoreCategory.FullHouse);

        Assert.Equal(25, score);
    }

    [Fact]
    public void FullHouse_ReturnsZero_WhenCombinationIsNotThreeAndTwo()
    {
        var score = KniffelScoreCalculator.CalculateScore([2, 2, 2, 2, 3], ScoreCategory.FullHouse);

        Assert.Equal(0, score);
    }

    [Fact]
    public void SmallStraight_ReturnsFixedScore_WhenFourConsecutiveDiceExist()
    {
        var score = KniffelScoreCalculator.CalculateScore([1, 2, 3, 4, 6], ScoreCategory.SmallStraight);

        Assert.Equal(30, score);
    }

    [Fact]
    public void SmallStraight_ReturnsZero_WhenNoFourConsecutiveDiceExist()
    {
        var score = KniffelScoreCalculator.CalculateScore([1, 1, 3, 4, 6], ScoreCategory.SmallStraight);

        Assert.Equal(0, score);
    }

    [Fact]
    public void LargeStraight_ReturnsFixedScore_WhenFiveConsecutiveDiceExist()
    {
        var score = KniffelScoreCalculator.CalculateScore([2, 3, 4, 5, 6], ScoreCategory.LargeStraight);

        Assert.Equal(40, score);
    }

    [Fact]
    public void LargeStraight_ReturnsZero_WhenFiveConsecutiveDiceDoNotExist()
    {
        var score = KniffelScoreCalculator.CalculateScore([1, 2, 3, 4, 6], ScoreCategory.LargeStraight);

        Assert.Equal(0, score);
    }

    [Fact]
    public void Kniffel_ReturnsFixedScore_WhenAllFiveDiceMatch()
    {
        var score = KniffelScoreCalculator.CalculateScore([6, 6, 6, 6, 6], ScoreCategory.Kniffel);

        Assert.Equal(50, score);
    }

    [Fact]
    public void Kniffel_ReturnsZero_WhenNotAllFiveDiceMatch()
    {
        var score = KniffelScoreCalculator.CalculateScore([6, 6, 6, 6, 5], ScoreCategory.Kniffel);

        Assert.Equal(0, score);
    }

    [Fact]
    public void Chance_ReturnsDiceSum_ForAnyCombination()
    {
        var score = KniffelScoreCalculator.CalculateScore([1, 3, 4, 5, 6], ScoreCategory.Chance);

        Assert.Equal(19, score);
    }

    [Fact]
    public void Chance_ThrowsArgumentException_WhenDiceCountIsNotFive()
    {
        Assert.Throws<ArgumentException>(() => KniffelScoreCalculator.CalculateScore([1, 2, 3, 4], ScoreCategory.Chance));
    }
}
