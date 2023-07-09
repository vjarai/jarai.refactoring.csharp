using System.Collections.Generic;
using GildedRoseKata.Refactored2.Rules;

namespace GildedRoseKata.Refactored2;

public class DecoratedItemFactory
{
    private const string AgedBrie = "Aged Brie";
    private const string BackstagePassesToATafkal80EtcConcert = "Backstage passes to a TAFKAL80ETC concert";
    private const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";
    private const string Cunjured = "Conjured";
    private readonly ItemUpdateRule _defaultRule = new();
    private readonly Dictionary<string, ItemUpdateRule> _specialRules;

    public DecoratedItemFactory()
    {
        _specialRules = new Dictionary<string, ItemUpdateRule>
        {
            {
                AgedBrie,
                new ItemUpdateRule { QualityChangePerDay = 1 }
            },
            {
                SulfurasHandOfRagnaros,
                new ItemUpdateRule
                    { QualityChangePerDay = 0, SellInChangePerDay = 0, MinQuality = 80, MaxQuality = 80 }
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

    private DecoratedItem CreateDecoratedItem(Item item)
    {
        if (!_specialRules.TryGetValue(item.Name, out var rule))
            rule = _defaultRule;

        return new DecoratedItem(item, rule);
    }

    public IEnumerable<DecoratedItem> CreateDecoratedItems(IEnumerable<Item> items)
    {
        foreach (var item in items)
            yield return CreateDecoratedItem(item);
    }
}