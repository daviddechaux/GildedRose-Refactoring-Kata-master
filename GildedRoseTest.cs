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
            Item secondItem = new Item { Name = "Coco l'asticot", SellIn = 0, Quality = 9000 };

            //Act 
            int quality = _gildedRose.IncrementQuality(item);
            int secondQuality = _gildedRose.IncrementQuality(secondItem);

            //Assert
            Assert.AreEqual(1, quality);
            Assert.AreEqual(9000, secondQuality);
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

            //Assert
            Assert.AreEqual(true, bQuaranteNeuf);
            //Assert.AreEqual(true, bCinquante);// Weird
            Assert.AreEqual(false, bAutre);
        }

        [TestMethod]
        public void IsBackstagePasse()
        {
            //Act
            Item item = new Item { Name = "Backstage", SellIn = 0, Quality = 49 };
            Item secondItem = new Item { Name = "random item", SellIn = 0, Quality = 49 };

            //Arrange
            bool result = _gildedRose.IsBackstagePasse(item);
            bool secondResult = _gildedRose.IsBackstagePasse(secondItem);

            //Assert
            Assert.IsTrue(result);
            Assert.IsFalse(secondResult);
        }

        [TestMethod]
        public void GetQualityThreshold()
        {
            //Act
            Item firstItem = new Item { Name = "random item", SellIn = 3, Quality = 49 };
            Item secondItem = new Item { Name = "random item", SellIn = 8, Quality = 49 };
            Item thirdItem = new Item { Name = "random item", SellIn = 30, Quality = 49 };

            //Arrange
            QualityThreshold first =  _gildedRose.GetQualityThreshold(firstItem);
            QualityThreshold second = _gildedRose.GetQualityThreshold(secondItem);
            QualityThreshold third = _gildedRose.GetQualityThreshold(thirdItem);

            //Assert
            Assert.AreEqual(first, QualityThreshold.TripleQuality);
            Assert.AreEqual(second, QualityThreshold.DoubleQuality);
            Assert.AreEqual(third, QualityThreshold.MaxQuality);
        }
    }
}
