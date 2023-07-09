using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata.Refactored2;

public class GildedRose
{
    private readonly List<DecoratedItem> _decoratedItems;
    private readonly DecoratedItemFactory _factory = new DecoratedItemFactory();

    private IList<Item> Items;

    public GildedRose(IList<Item> items)
    {
        Items = items;
        _decoratedItems = _factory.CreateDecoratedItems(items).ToList();
    }

    public void UpdateQuality()
    {
        foreach (var item in _decoratedItems)
            item.Update();
    }
}