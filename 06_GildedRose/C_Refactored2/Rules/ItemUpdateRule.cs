using System;

namespace GildedRoseKata.Refactored2.Rules;

public class ItemUpdateRule
{
    public int MaxQuality { get; set; } = 50;

    public int MinQuality { get; set; } = 0;

    public int QualityChangePerDay { get; set; } = -1;

    public int SellInChangePerDay { get; set; } = -1;

    public virtual void UpdateItem(Item itemToUpdate)
    {
        itemToUpdate.SellIn += SellInChangePerDay;

        UpdateQuality(itemToUpdate, QualityChangePerDay);
    }

    protected virtual void UpdateQuality(Item item, int qualityChange)
    {
        if (item.SellIn < 0)
            qualityChange *= 2;

        item.Quality += qualityChange;

        item.Quality = Math.Max(item.Quality, MinQuality);
        item.Quality = Math.Min(item.Quality, MaxQuality);

    }
}