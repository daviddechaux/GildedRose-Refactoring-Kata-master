using System.Collections.Generic;

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
        /// And please can you clean up a little bit this mess please
        /// PS : No bug
        /// </summary>
        public void UpdateQuality()
        {
            for (var i = 0; i < _items.Count; i++)
            {
                if (_items[i].Name != "Aged Brie" && _items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (_items[i].Quality > 0)
                    {
                        if (this.IsNotLegendary(_items[i]))
                        {
                            _items[i].Quality = _items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (_items[i].Quality < 50)
                    {
                        _items[i].Quality = _items[i].Quality + 1;

                        if (_items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (_items[i].SellIn < 11)
                            {
                                if (_items[i].Quality < 50)
                                {
                                    _items[i].Quality = _items[i].Quality + 1;
                                }
                            }

                            if (_items[i].SellIn < 6)
                            {
                                if (_items[i].Quality < 50)
                                {
                                    _items[i].Quality = _items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (this.IsNotLegendary(_items[i]))
                {
                    _items[i].SellIn = _items[i].SellIn - 1;
                }

                if (_items[i].SellIn < 0)
                {
                    if (_items[i].Name != "Aged Brie")
                    {
                        if (_items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (_items[i].Quality > 0)
                            {
                                if (this.IsNotLegendary(_items[i]))
                                {
                                    _items[i].Quality = _items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            _items[i].Quality = _items[i].Quality - _items[i].Quality;
                        }
                    }
                    else
                    {
                        if (_items[i].Quality < 50)
                        {
                            _items[i].Quality = IncrementQuality(_items[i]);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        /// Tell you strangely if we have the maximum quality
        /// </summary>
        /// <param name="item">The item you want to increment quality</param>
        /// <returns></returns>
        public int IncrementQuality(Item item)
        {
            return item.Quality + 1;
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
