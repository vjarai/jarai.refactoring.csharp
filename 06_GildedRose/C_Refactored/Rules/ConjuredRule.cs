namespace GildedRoseKata.Refactored.Rules;

class ConjuredRule : UpdateRule
{
    protected override void UpdateQuality(Item item, int qualityChange)
    {
        base.UpdateQuality(item, 2 * qualityChange);
    }
}