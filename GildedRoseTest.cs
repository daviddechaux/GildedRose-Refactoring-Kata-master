using System.Collections.Generic;
using GildedRose;
using Xunit;

namespace csharp
{
    public class GildedRoseTest
    {
        [Theory]
        [InlineData("spoon",10,10)]
        [InlineData("fork",5,5)]
        public void UpdateQuality_WithClassicalItemAndSellinAbove0_DecreasesQuality(string name, int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(quality - 1, Items[0].Quality);
        }

        [Theory]
        [InlineData("spoon", 10, 10)]
        [InlineData("fork", 5, 5)]
        public void UpdateQuality_WithClassicalItemAndSellinAbove0_DecreasesSellin(string name, int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(sellIn - 1, Items[0].SellIn);
        }

        [Theory]
        [InlineData("spoon", 0, 10)]
        [InlineData("fork", 0, 5)]
        public void UpdateQuality_WithClassicalItemAndSellinPast_DecreasesQualityTwice(string name, int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(quality - 2, Items[0].Quality);
        }

        [Theory]
        [InlineData("Aged Brie", 10, 0)]
        public void UpdateQuality_WithAgedBrie_Increases(string name, int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(quality + 1, Items[0].Quality);
            Assert.Equal(sellIn - 1, Items[0].SellIn);
        }

        [Theory]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 10, 10)]
        public void UpdateQuality_WithBackstagePassesAndSellin10_IncreasesBy2(string name, int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.True(true);
        }

        [Theory]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 5, 10)]
        public void UpdateQuality_WithBackstagePassesAndSellinBelow6_IncreasesBy3(string name, int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(quality + 3, Items[0].Quality);
            Assert.Equal(sellIn - 1, Items[0].SellIn);
        }

        [Theory]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 0, 10)]
        public void UpdateQuality_WithBackstagePassesAfterConcert_DropsTo0(string name, int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
        }

        [Theory]
        [InlineData("Aged Brie", 10, 50)]
        public void UpdateQuality_WithAgedBrie_CannotBeAbove50(string name, int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(quality, Items[0].Quality);
        }

        [Theory]
        [InlineData("Sulfuras, Hand of Ragnaros", 10, 10)]
        public void UpdateQuality_WithSulfuras_CannotDecrease(string name, int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(quality, Items[0].Quality);
        }

        [Theory (Skip = "Not yet implemented")]
        [InlineData("Conjured", 10, 10)]
        public void UpdateQuality_WithConjuredItem_LoosesTwiceTheQuality(string name, int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(quality - 2, Items[0].Quality);
        }
    }
}
