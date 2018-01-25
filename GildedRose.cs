using System.Collections.Generic;

// Name : 

namespace GildedRose
{
    public class GildedRoseKata
    {
        /// <summary>
        /// Contains the list of items to sell
        /// </summary>
        readonly IList<Item> _items;

        /// <summary>
        /// Constructor but I shouldn't have to tell you that :)
        /// </summary>
        /// <param name="items"></param>
        public GildedRoseKata(IList<Item> items)
        {
            this._items = items;
        }

        /// <summary>
        /// Where the magic happens.
        /// You can change whatever you want here
        /// And please can you clean up a little bit this mess please
        /// PS : No bug
        /// </summary>
        public void UpdateQuality()
        {
            for (var i = 0; i < _items.Count; i++)
            {
                Item item = _items[i];

                if (item.Name != "Aged Brie" && !this.IsBackstagePasse(item))
                {
                    if (item.Quality > 0)
                    {
                        if (this.IsNotLegendary(item))
                        {
                            item.Quality = this.IncrementQuality(item);
                        }
                    }
                }
                else
                {
                    if (this.IsBackstagePasse(item))
                    {
                        QualityThreshold qualityThreshold = this.GetQualityThreshold(_items[i]);
                        int quityIncreaser = Tools.GetEnumDescriptionEnh(qualityThreshold);

                        if (item.SellIn < (int)qualityThreshold)
                        {
                            item = this.ManageQuality(item, quityIncreaser);
                        }
                    }
                    else
                    {
                        if (this.CanIIncreaseQuality(item))
                        {
                            item.Quality = this.IncrementQuality(item);
                        }
                    }
                }

                if (this.IsNotLegendary(item))
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name != "Aged Brie")
                    {
                        if (this.IsBackstagePasse(item))
                        {
                            if (item.Quality > 0)
                            {
                                if (this.IsNotLegendary(item))
                                {
                                    item.Quality = this.IncrementQuality(item, -1);
                                }
                            }
                        }
                        else
                        {
                            item.Quality = this.IncrementQuality(item, item.Quality * -1);
                        }
                    }
                    else
                    {
                        if (this.CanIIncreaseQuality(item))
                        {
                            item = this.ManageQuality(item, 1);
                        }
                    }
                }

                _items[i] = item;
            }
        }

        /// <summary>
        /// Tell if the item is a backstage pass 
        /// Sing "I'm a murloc"
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool IsBackstagePasse(Item item)
        {
            return item.Name.EndsWith("Backstage");
        }

        /// <summary>
        /// Manage the quality of an item
        /// </summary>
        /// <param name="item">item to manage</param>
        /// <param name="qualityIncreaser">The value of the quality should be increase of (I don't think this sentence is correct)</param>
        private Item ManageQuality(Item item, int qualityIncreaser)
        {
            if (this.CanIIncreaseQuality(item))
            {
                item.Quality = this.IncrementQuality(item, qualityIncreaser);
            }

            return item;
        }

        /// <summary>
        /// Return the quality threshold enum depending the sellin left
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public QualityThreshold GetQualityThreshold(Item item)
        {
            if (item.SellIn < (int) QualityThreshold.TripleQuality)
                return QualityThreshold.TripleQuality;
            else if (item.SellIn < (int)QualityThreshold.DoubleQuality)
                return QualityThreshold.DoubleQuality;

            return QualityThreshold.MaxQuality;
        }

        /// <summary>
        /// Can you increased the quality, indeed it's a good question
        /// </summary>
        /// <param name="item">Item you want to increase the quality</param>
        /// <returns></returns>
        public bool CanIIncreaseQuality(Item item)
        {
            if (item.Quality < 50)
            {
                return true;
            }
            else if (item.Quality == 50)
            {
                throw new Exception("What should I do ?");
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Tell you strangely if we have the maximum quality
        /// </summary>
        /// <param name="item">The item you want to increment quality</param>
        /// <param name="qualityIncreaser">The value of the quality should be increase of (I don't think this sentence is correct)</param>
        /// <returns></returns>
        public int IncrementQuality(Item item, int qualityIncreaser = 1)
        {
            if (item.Quality < (int)QualityThreshold.MaxQuality)
                return item.Quality + qualityIncreaser;

            return item.Quality;
        }

        /// <summary>
        /// This awesome a so complicated function test if an object is not legendary
        /// </summary>
        /// <param name="item">Object to test the legendayness</param>
        /// <returns></returns>
        public bool IsNotLegendary(Item item)
        {
            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
