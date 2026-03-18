using Xunit;

namespace Kniffel.Refactored.Tests;

public class ScoringServiceTests
{
    private readonly ScoringService _sut = new();

    [Theory]
    [InlineData(RuleId.Ones, 1, 2, 3, 4, 5, 1)]
    [InlineData(RuleId.Twos, 1, 2, 2, 4, 5, 4)]
    [InlineData(RuleId.Threes, 3, 3, 1, 5, 6, 6)]
    [InlineData(RuleId.Fours, 4, 4, 4, 1, 2, 12)]
    [InlineData(RuleId.Fives, 5, 1, 5, 2, 5, 15)]
    [InlineData(RuleId.Sixes, 6, 6, 6, 2, 1, 18)]
    public void Count_rules_return_sum_of_matching_dice(RuleId ruleId, int d1, int d2, int d3, int d4, int d5, int expected)
    {
        var wurf = new Wurf(d1, d2, d3, d4, d5);

        var actual = _sut.CalculateScore(ruleId, wurf);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Three_of_a_kind_returns_sum_when_present()
    {
        var actual = _sut.CalculateScore(RuleId.ThreeOfAKind, new Wurf(3, 3, 3, 4, 5));

        Assert.Equal(18, actual);
    }

    [Fact]
    public void Three_of_a_kind_returns_zero_when_not_present()
    {
        var actual = _sut.CalculateScore(RuleId.ThreeOfAKind, new Wurf(1, 2, 3, 4, 5));

        Assert.Equal(0, actual);
    }

    [Fact]
    public void Four_of_a_kind_returns_sum_when_present()
    {
        var actual = _sut.CalculateScore(RuleId.FourOfAKind, new Wurf(2, 2, 2, 2, 5));

        Assert.Equal(13, actual);
    }

    [Fact]
    public void Four_of_a_kind_returns_zero_when_not_present()
    {
        var actual = _sut.CalculateScore(RuleId.FourOfAKind, new Wurf(2, 2, 2, 3, 5));

        Assert.Equal(0, actual);
    }

    [Fact]
    public void Full_house_returns_25_for_three_and_two_equal_dice()
    {
        var actual = _sut.CalculateScore(RuleId.FullHouse, new Wurf(2, 2, 3, 3, 3));

        Assert.Equal(25, actual);
    }

    [Fact]
    public void Full_house_returns_zero_when_pattern_is_missing()
    {
        var actual = _sut.CalculateScore(RuleId.FullHouse, new Wurf(2, 2, 2, 2, 5));

        Assert.Equal(0, actual);
    }

    [Fact]
    public void Small_straight_returns_30_for_four_in_a_row()
    {
        var actual = _sut.CalculateScore(RuleId.SmallStraight, new Wurf(1, 2, 3, 4, 6));

        Assert.Equal(30, actual);
    }

    [Fact]
    public void Small_straight_returns_zero_when_no_sequence_exists()
    {
        var actual = _sut.CalculateScore(RuleId.SmallStraight, new Wurf(1, 1, 3, 5, 6));

        Assert.Equal(0, actual);
    }

    [Theory]
    [InlineData(1, 2, 3, 4, 5)]
    [InlineData(2, 3, 4, 5, 6)]
    public void Large_straight_returns_40_for_five_in_a_row(int d1, int d2, int d3, int d4, int d5)
    {
        var actual = _sut.CalculateScore(RuleId.LargeStraight, new Wurf(d1, d2, d3, d4, d5));

        Assert.Equal(40, actual);
    }

    [Fact]
    public void Large_straight_returns_zero_for_duplicates()
    {
        var actual = _sut.CalculateScore(RuleId.LargeStraight, new Wurf(1, 2, 2, 4, 5));

        Assert.Equal(0, actual);
    }

    [Fact]
    public void Kniffel_returns_50_for_five_equal_dice()
    {
        var actual = _sut.CalculateScore(RuleId.Kniffel, new Wurf(6, 6, 6, 6, 6));

        Assert.Equal(50, actual);
    }

    [Fact]
    public void Kniffel_returns_zero_when_not_all_dice_equal()
    {
        var actual = _sut.CalculateScore(RuleId.Kniffel, new Wurf(6, 6, 6, 6, 5));

        Assert.Equal(0, actual);
    }

    [Fact]
    public void Chance_returns_sum_of_all_dice()
    {
        var actual = _sut.CalculateScore(RuleId.Chance, new Wurf(2, 3, 4, 5, 1));

        Assert.Equal(15, actual);
    }
}

public class WurfTests
{
    [Fact]
    public void GetCounts_returns_frequency_for_each_face()
    {
        var wurf = new Wurf(1, 2, 2, 4, 6);

        var counts = wurf.GetCounts();

        Assert.Equal(new[] { 1, 2, 0, 1, 0, 1 }, counts);
    }

    [Fact]
    public void GetCounts_returns_all_zeros_except_matching_face_for_identical_dice()
    {
        var wurf = new Wurf(5, 5, 5, 5, 5);

        var counts = wurf.GetCounts();

        Assert.Equal(new[] { 0, 0, 0, 0, 5, 0 }, counts);
    }

    [Fact]
    public void GetCounts_is_independent_of_input_order()
    {
        var wurf = new Wurf(6, 1, 6, 3, 1);

        var counts = wurf.GetCounts();

        Assert.Equal(new[] { 2, 0, 1, 0, 0, 2 }, counts);
    }
}
