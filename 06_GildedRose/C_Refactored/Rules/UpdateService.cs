using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRoseKata.Refactored.Rules
{
    public class UpdateService
    {
        private readonly Dictionary<string, UpdateRule> _rules;
        private readonly UpdateRule _defaultRule = new UpdateRule();

        private const string AgedBrie = "Aged Brie";
        private const string BackstagePassesToATafkal80EtcConcert = "Backstage passes to a TAFKAL80ETC concert";
        private const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";

        public UpdateService()
        {
            _rules = new Dictionary<string, UpdateRule>()
            {
                { AgedBrie, new UpdateRule(){QualityChangePerDay = 1} },
                { SulfurasHandOfRagnaros, new UpdateRule{QualityChangePerDay = 0, SellInChangePerDay = 0, MinQuality = 80, MaxQuality = 80} },
                { BackstagePassesToATafkal80EtcConcert, new BackstagePassRule() },
           };
        }

        public void UpdateItem(Item itemToUpdate)
        {
            if (!_rules.TryGetValue(itemToUpdate.Name, out var rule))
                rule = _defaultRule;

            rule.Update(itemToUpdate);
        }
    }
}