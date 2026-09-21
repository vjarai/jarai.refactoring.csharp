using System.Collections;

namespace Kniffel.Refactored;

/// <summary>
/// Represents a roll of five dice.
/// </summary>
public class DiceRoll : IEnumerable<int>
{
    private readonly IEnumerable<int> _dice;

    public DiceRoll()
    {
        _dice = CreateRandom().Order();
    }

    public DiceRoll(params int[] dice)
    {
        if (dice.Length != 5)
            throw new ArgumentException("A dice roll must contain exactly 5 numbers.");

        _dice = dice.Order();
    }

    public IEnumerator<int> GetEnumerator()
    {
        return _dice.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _dice.GetEnumerator();
    }

    private IEnumerable<int> CreateRandom()
    {
        var random = new Random();

        for (var i = 0; i < 5; i++)
        {
            yield return random.Next(1, 7);
        }
    }

    /// <summary>
    ///     Returns the counts of each die face.
    /// </summary>
    public int[] GetCounts()
    {
        var counts = new int[6];

        foreach (int value in _dice)
        {
            counts[value - 1]++;
        }

        return counts;
    }

    public override string ToString()
    {
        return string.Join(',', _dice);
    }
}
