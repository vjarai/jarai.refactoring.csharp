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
                _updateService.UpdateItem(item);
            }
        }
    }
}
