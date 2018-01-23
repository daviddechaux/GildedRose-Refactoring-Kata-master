using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose
{
    [TestClass]
    public class GildedRoseTest
    {
        private GildedRoseKata _gildedRose;

        [TestInitialize]
        public void Init()
        {
            _gildedRose = new GildedRoseKata(null);
        }

        [TestMethod]
        public void IsLegendary()
        {
            //Arrange
            Item legendary = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 0 };
            Item notLegendary = new Item { Name = "This is not Sulfuras", SellIn = 0, Quality = 0 };

            //Act - Assert
            Assert.IsFalse(_gildedRose.IsNotLegendary(legendary));
            Assert.IsTrue(_gildedRose.IsNotLegendary(notLegendary));
        }

        [TestMethod]
        public void IncrementQuality()
        {
            //Arrange
            Item item = new Item { Name = "Coco l'asticot", SellIn = 0, Quality = 0 };

            //Act 
            int quality = _gildedRose.IncrementQuality(item);

            //Assert
            Assert.AreEqual(1, quality);
        }

        [TestMethod]
        public void CanIIncreaseQuality()
        {
            //Arrange
            Item quanteNeuf = new Item { Name = "Coco l'asticot", SellIn = 0, Quality = 49 };
            Item cinquante = new Item { Name = "Coco l'asticot", SellIn = 0, Quality = 50 };
            Item autre = new Item { Name = "Coco l'asticot", SellIn = 0, Quality = 51 };

            //Act
            bool bQuaranteNeuf = _gildedRose.CanIIncreaseQuality(quanteNeuf);
            //bool bCinquante = _gildedRose.CanIIncreaseQuality(cinquante);
            bool bAutre = _gildedRose.CanIIncreaseQuality(autre);

            //Arrange
            Assert.AreEqual(true, bQuaranteNeuf);
            //Assert.AreEqual(true, bCinquante);// Weird
            Assert.AreEqual(false, bAutre);
        }
    }
}
