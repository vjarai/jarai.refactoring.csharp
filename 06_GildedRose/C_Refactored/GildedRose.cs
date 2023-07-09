using System.Collections.Generic;
using GildedRoseKata.Refactored.Rules;

namespace GildedRoseKata.Refactored;

public class GildedRose
{
    private const string AgedBrie = "Aged Brie";
    private const string BackstagePassesToATafkal80EtcConcert = "Backstage passes to a TAFKAL80ETC concert";
    private const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";
    private const string Cunjured = "Conjured";

    private readonly UpdateRule _defaultRule = new();

    private IList<Item> Items;

    private readonly Dictionary<string, UpdateRule> _specialRules;

    public GildedRose(IList<Item> items)
    {
        Items = items;

        _specialRules = new Dictionary<string, UpdateRule>
        {
            {
                AgedBrie,
                new UpdateRule { QualityChangePerDay = 1 }
            },
            {
                SulfurasHandOfRagnaros,
                new UpdateRule { QualityChangePerDay = 0, SellInChangePerDay = 0, MinQuality = 80, MaxQuality = 80 }
            },
            {
                BackstagePassesToATafkal80EtcConcert,
                new BackstagePassRule()
            },
            {
                Cunjured,
                new ConjuredRule()
            }
        };
    }

    public void UpdateQuality()
    {
        foreach (var item in Items)
            UpdateItem(item);
    }


    private void UpdateItem(Item itemToUpdate)
    {
        if (!_specialRules.TryGetValue(itemToUpdate.Name, out var rule))
            rule = _defaultRule;

        rule.UpdateItem(itemToUpdate);
    }
}