namespace GildedRoseKata.Refactored2.Rules;

public class BackstagePassRule : ItemUpdateRule
{
    public override void UpdateItem(Item item)
    {
        item.Quality += 1;

        if (item.SellIn < 11)
            item.Quality += 1;

        if (item.SellIn < 6)
            item.Quality += 1;

        if (item.Quality > 50)
            item.Quality = 50;

        item.SellIn--;

        if (item.SellIn < 0)
            item.Quality = 0;
    }
}