using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GildedRoseKata.Refactored.Rules;

namespace GildedRoseKata.Refactored
{
    public class BackstagePassRule : UpdateRule
    {
        public override void Update(Item item)
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
}
