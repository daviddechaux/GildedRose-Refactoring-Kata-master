using System;
using System.Collections.Generic;

namespace GildedRose
{
    /// <summary>
    /// Please do not change this class
    /// </summary>
    public static class Program
    {
        public static void Main()
        {
            IList<Item> items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49},
				// this conjured item does not work properly yet
				new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            var app = new GildedRoseKata(items);


            for (var i = 0; i < 31; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("-------- Day " + i + " --------");
                Console.ResetColor();
                
                for (var j = 0; j < items.Count; j++)
                {
                    if (app.IsBackstagePasse(items[j]))
                        Console.ForegroundColor = ConsoleColor.Green;
                    else if (items[j].Name == "Aged Brie")
                        Console.ForegroundColor = ConsoleColor.Green;
                    else if (items[j].Name == "Conjured Mana Cake")
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    else if (app.IsNotLegendary(items[j]))
                        Console.ForegroundColor = ConsoleColor.White;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;//Should be Orange, but nevermind

                    Console.WriteLine($"Name : {items[j].Name}, SellIn : {items[j].SellIn}, Quality : {items[j].Quality}");
                    Console.ResetColor();
                }

                Console.WriteLine("");
                app.UpdateQuality();
            }

            Console.Read();
        }
    }
}
