using System.Collections;

namespace Kniffel.Refactored;

public class Wurf : IEnumerable<int>
{
    private readonly IEnumerable<int> _wuerfel;

    public Wurf()
    {
        _wuerfel = CreateRandom().Order();
    }

    public Wurf(params int[] wuerfel)
    {
        if (wuerfel.Length != 5)
            throw new ArgumentException("A Wurf must contain exactly 5 numbers.");

        _wuerfel = wuerfel.Order();
    }


    public IEnumerator<int> GetEnumerator()
    {
        return _wuerfel.AsEnumerable().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _wuerfel.GetEnumerator();
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
    ///     Returns the counts of each die face (Häufigkeitsverteilung)
    /// </summary>
    public int[] GetCounts()
    {
        var counts = new int[6];

        foreach (int wert in _wuerfel)
        {
            counts[wert - 1]++;
        }

        return counts;
    }

    public override string ToString()
    {
        return string.Join(',', _wuerfel);
    }
}