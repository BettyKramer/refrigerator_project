using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refrigerator
{
    internal class refrigerator
    {
        public int refrigeratorId { get; }
        public string model { get; }
        public string color { get; }
        public void fillItem()
        {
            Item myItem = new Item("salamy", (int)typefood.food);
        }
        public int numOfShelves { get; }

        List<Shelf> shelves;

        public void toString()
        {
            Console.WriteLine("refrigerator id: " + refrigeratorId + " model: " + model + " color: "
                + color + " num of shelves:" + numOfShelves);

        }

        //2
        public int placeLeftInRefrigerator()
        {
            int sum = 0;
            foreach (Shelf shelf in shelves)
            {
                sum += shelf.getPlaceInShelf();
            }

            return sum;
        }

        //4
        public Item getItemFromRfrigerator(int itemid)
        {
            foreach (Shelf shelf in shelves)
            {
                Item item = shelf.getItemFromShelf(itemid);
                if (item != null) { return item; }
            }
            Console.WriteLine("the item is not here");
            return null;
        }

        //5
        public void throwExpired()
        {
            foreach (Shelf shelf in shelves)
            {
                shelf.throwEexpired();
            }
        }

        //6
        public List<Item> itemsYouCanEat( int foodType, int foodKashrut)
        {
            List<Item> itemToEat = new List<Item>();
            foreach(Shelf shelf in shelves)
            {
                foreach(Item item in shelf.items)
                {
                    if(item.expiryDate<=DateTime.Today&& item.foodType == foodType&&item.foodKashrut==foodKashrut)
                    {
                        itemToEat.Add(item);
                    }
                      
                }
            }
            return itemToEat;
        }


    }

 
}
