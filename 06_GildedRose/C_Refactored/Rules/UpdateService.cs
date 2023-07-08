using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRoseKata.Refactored.Rules
{
    public class UpdateService
    {
        private Dictionary<string, UpdateRule> _rules;

        public const string AgedBrie = "Aged Brie";

        public const string BackstagePassesToATafkal80EtcConcert = "Backstage passes to a TAFKAL80ETC concert";

        public const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";

        public UpdateService()
        {
            _rules = new Dictionary<string, UpdateRule>()
            {
                { AgedBrie, new UpdateRule(){QualityChangePerDay = 1} },
                { SulfurasHandOfRagnaros, new UpdateRule{QualityChangePerDay = 0, MinQuality = 80, MaxQuality = 80} }
            };
        }

        public void UpdateItem(Item itemToUpdate)
        {
            var rule = _rules[itemToUpdate.Name];
            rule.Update(itemToUpdate);
        }
    }
}