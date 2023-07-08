using System;

namespace GildedRoseKata.Refactored;

public class SellableItem : Item
{
    public new int Quality
    {
        get { return base.Quality; }
        set
        {
            if (value >= 0 && value <= 80)
                base.Quality = value;
        }
    }

    public void Update()
    {
        throw new NotImplementedException();
    }
}