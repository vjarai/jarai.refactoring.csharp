using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void AgedBrie()
        {
            // Arrange
            var items = new List<Item>
            {
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
            };

            var app = new GildedRose(items);

            // ACT
            app.UpdateQuality();


            // ASSERT
            Assert.Equal("Aged Brie", items[0].Name);
        }
    }
}
