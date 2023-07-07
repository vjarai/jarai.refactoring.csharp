using System.Collections.Generic;

namespace GildedRoseKata.Refactored
{
    public class GildedRose
    {
        private const string AgedBrie = "Aged Brie";
        private const string BackstagePassesToATafkal80EtcConcert = "Backstage passes to a TAFKAL80ETC concert";
        private const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";

        readonly IList<Item> _items;
        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                if (item.Name == AgedBrie || item.Name == BackstagePassesToATafkal80EtcConcert)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;

                        if (item.Name == BackstagePassesToATafkal80EtcConcert)
                        {
                            if (item.SellIn < 11)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality += 1;
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality += 1;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != SulfurasHandOfRagnaros)
                        {
                            item.Quality -= 1;
                        }
                    }
                }

                if (item.Name != SulfurasHandOfRagnaros)
                {
                    item.SellIn -= 1;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name != AgedBrie)
                    {
                        if (item.Name != BackstagePassesToATafkal80EtcConcert)
                        {
                            if (item.Quality > 0)
                            {
                                if (item.Name != SulfurasHandOfRagnaros)
                                {
                                    item.Quality -= 1;
                                }
                            }
                        }
                        else
                        {
                            item.Quality -= item.Quality;
                        }
                    }
                    else
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality += 1;
                        }
                    }
                }
            }
        }
    }
}
