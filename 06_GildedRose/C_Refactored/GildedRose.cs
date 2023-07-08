using System.Collections.Generic;
using GildedRoseKata.Refactored.Rules;

namespace GildedRoseKata.Refactored
{
    public class GildedRose
    {

        readonly IList<Item> _items;
        private readonly UpdateService _updateService;

        public GildedRose(IList<Item> items)
        {
            _items = items;
            _updateService = new UpdateService();
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                if (item.Name == UpdateService.AgedBrie)
                {
                    _updateService.UpdateItem(item);
                    continue;
                }


                if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;

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
                else
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != "Sulfuras, Hand of Ragnaros")
                        {
                            item.Quality -= 1;
                        }
                    }
                }

                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.SellIn -= 1;
                }

                if (item.SellIn < 0)
                {
                   
                    {
                        if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item.Quality > 0)
                            {
                                if (item.Name != "Sulfuras, Hand of Ragnaros")
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
                }
            }
        }
    }
}
