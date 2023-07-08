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
                if (item.Name == UpdateService.AgedBrie
                    || item.Name == UpdateService.BackstagePassesToATafkal80EtcConcert
                    || item.Name == UpdateService.SulfurasHandOfRagnaros)
                {
                    _updateService.UpdateItem(item);
                    continue;
                }

                if (item.Quality > 0)
                {
                    item.Quality -= 1;
                }

                item.SellIn -= 1;

                if (item.SellIn < 0)
                {
                    if (item.Quality > 0)
                    {
                        item.Quality -= 1;
                    }
                }
            }
        }
    }
}
