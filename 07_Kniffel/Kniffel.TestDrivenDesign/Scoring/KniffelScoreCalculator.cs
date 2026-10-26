namespace Kniffel.TestDrivenDesign.Scoring;

public static class KniffelScoreCalculator
{
    public static int CalculateScore(IReadOnlyList<int> dice, ScoreCategory category)
    {
        ValidateDice(dice);

        return category switch
        {
            ScoreCategory.Ones => SumByFace(dice, 1),
            ScoreCategory.Twos => SumByFace(dice, 2),
            ScoreCategory.Threes => SumByFace(dice, 3),
            ScoreCategory.Fours => SumByFace(dice, 4),
            ScoreCategory.Fives => SumByFace(dice, 5),
            ScoreCategory.Sixes => SumByFace(dice, 6),
            ScoreCategory.ThreeOfAKind => HasOfAKind(dice, 3) ? dice.Sum() : 0,
            ScoreCategory.FourOfAKind => HasOfAKind(dice, 4) ? dice.Sum() : 0,
            ScoreCategory.FullHouse => IsFullHouse(dice) ? 25 : 0,
            ScoreCategory.SmallStraight => IsSmallStraight(dice) ? 30 : 0,
            ScoreCategory.LargeStraight => IsLargeStraight(dice) ? 40 : 0,
            ScoreCategory.Kniffel => HasOfAKind(dice, 5) ? 50 : 0,
            ScoreCategory.Chance => dice.Sum(),
            _ => throw new ArgumentOutOfRangeException(nameof(category), category, "Unknown score category.")
        };
    }

    private static void ValidateDice(IReadOnlyList<int> dice)
    {
        ArgumentNullException.ThrowIfNull(dice);

        if (dice.Count != 5)
        {
            throw new ArgumentException("Exactly five dice are required.", nameof(dice));
        }

        if (dice.Any(value => value < 1 || value > 6))
        {
            throw new ArgumentOutOfRangeException(nameof(dice), "Die values must be between 1 and 6.");
        }
    }

    private static int SumByFace(IEnumerable<int> dice, int face)
    {
        return dice.Where(value => value == face).Sum();
    }

    private static bool HasOfAKind(IEnumerable<int> dice, int requiredCount)
    {
        return dice.GroupBy(value => value).Any(group => group.Count() >= requiredCount);
    }

    private static bool IsFullHouse(IEnumerable<int> dice)
    {
        var groups = dice.GroupBy(value => value)
            .Select(group => group.Count())
            .OrderBy(count => count)
            .ToArray();

        return groups.Length == 2 && groups[0] == 2 && groups[1] == 3;
    }

    private static bool IsSmallStraight(IEnumerable<int> dice)
    {
        var distinct = dice.Distinct().ToHashSet();

        return ContainsAll(distinct, 1, 2, 3, 4)
            || ContainsAll(distinct, 2, 3, 4, 5)
            || ContainsAll(distinct, 3, 4, 5, 6);
    }

    private static bool IsLargeStraight(IEnumerable<int> dice)
    {
        var distinct = dice.Distinct().OrderBy(value => value).ToArray();

        return distinct.SequenceEqual([1, 2, 3, 4, 5]) || distinct.SequenceEqual([2, 3, 4, 5, 6]);
    }

    private static bool ContainsAll(HashSet<int> values, params int[] required)
    {
        return required.All(values.Contains);
    }
}
