# GildedRose-Refactoring-Kata-master
***Under test, please do not commit anything***

*The original test comes from here, it's has been updated to make them in a shorter amout of time (< 30 min).*
https://github.com/emilybache/GildedRose-Refactoring-Kata   
https://github.com/NotMyself/GildedRose    

In order to make it easier, we added some unit tests, they don't cover everything (but still an important part) and some may need to be completed.

There is a global "integration" test named "ApprovalTest" this test ensure that the run of your program.cs is still the same as expected. You will have to edit "ApprovalTest.ThirtyDays.approved.txt" once the conjured item added.
# Do
* Add your name at the top of the `GildedRose` class please
* Read carrefully the following text
* Ask question if needed
* Enjoy
* Any remark is welcome
* Feel totally free to create new tests

# Don't
* Google, you won't have enough time. But I'm not your father, feel free to do it anyway.
* Modify the Item class
* Modify Program.cs (do only to decomment the conjured item)

# Gilded Rose Inn

> Hi and welcome to the team `Gilded Rose`. As you know, we are a small inn with a prime location in a prominent city ran by a friendly innkeeper named Allison.   
We also buy and sell only the finest goods. Unfortunately, our goods are constantly degrading in quality as they approach their sell by date.  
We have a system in place that updates our inventory for us.   
It was developed by a no-nonsense type named `Leeroy`, who has moved on to new adventures.   
Your task is to add the new feature to our system so that we can begin selling a new category of items. First an introduction to our system:

All items have a **SellIn** value which denotes the number of days we have to sell the item.  
All items have a **Quality** value which denotes how valuable the item is.  
At the end of each day our system lowers both values for every item.  

Pretty simple, right? Well this is where it gets interesting:
* Once the sell by date has passed, Quality degrades twice as fast
* The Quality of an item is never negative
* **Aged Brie** actually increases in Quality the older it gets
* The Quality of an item is never more than 50
* **Sulfuras**, being a legendary item, never has to be sold or decreases in Quality
* **Backstage passes**, like **Aged brie**, increases in Quality as it's SellIn value approaches  
    * Quality increases by 2 when there are 10 days or less
    * Quality increases by 3 when there are 5 days or less 
    * Quality drops to 0 after the concert  
* We have recently signed a supplier of conjured items. This requires an update to our system:

* **Conjured** items degrade in Quality twice as fast as normal items  


Feel free to make **any changes** to the `UpdateQuality` method and add any new code as long as everything ~~still~~ works correctly. However, **do not** alter the **Item class or Items property** as those belong to the goblin in the corner who will insta-rage and one-shot you as he doesn't believe in shared code ownership.  
You can make the UpdateQuality method and Items property static if you like, we'll cover for you.

Just for clarification, an item can never have its Quality increase above 50, however "Sulfuras" is a legendary item and as such its Quality is 80 and it never alters.

