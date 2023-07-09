using GildedRoseKata.Refactored2.Rules;

namespace GildedRoseKata.Refactored2;

public class DecoratedItem : Item
{
    private readonly Item _innerItem;
    private readonly ItemUpdateRule _updateRule;

    public DecoratedItem(Item innerItem, ItemUpdateRule updateRule)
    {
        _innerItem = innerItem;
        _updateRule = updateRule;
    }

    public new string Name
    {
        get { return _innerItem.Name; }
        set { _innerItem.Name = value; }
    }

    public new int SellIn
    {
        get { return _innerItem.SellIn; }
        set { _innerItem.SellIn = value; }
    }

    public new int Quality
    {
        get { return _innerItem.Quality; }
        set { _innerItem.Quality = value; }
    }

    public void Update()
    {
        _updateRule.UpdateItem(_innerItem);
    }
}