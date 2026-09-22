using System.Collections;

namespace Kniffel.Refactored;

/// <summary>
/// Represents a roll of five dice.
/// </summary>
public class DiceRoll : IEnumerable<int>
{
    private readonly int[] _dice;


    public DiceRoll()
    {
        _dice = new int[5];

        var random = new Random();

        for (var i = 0; i < 5; i++)
        {
            _dice[i] = random.Next(1, 7);
        }

        _dice = _dice.Order().ToArray();
    }

    public DiceRoll(params int[] dice)
    {
        if (dice.Length != 5)
            throw new ArgumentException("A dice roll must contain exactly 5 numbers.");

        _dice = dice.Order().ToArray();
    }

    public IEnumerator<int> GetEnumerator()
    {
        return _dice.AsEnumerable().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _dice.GetEnumerator();
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
