﻿namespace GildedRoseKata.Refactored.Rules;

class ConjuredRule : ItemUpdateRule
{
    protected override void UpdateQuality(Item item, int qualityChange)
    {
        base.UpdateQuality(item, 2 * qualityChange);
    }
}