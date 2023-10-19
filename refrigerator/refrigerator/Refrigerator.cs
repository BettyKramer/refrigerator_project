using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refrigerator
{
    internal class Refrigerator
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
            int sum = 0, sumb = 0;

            foreach (Shelf shelf in shelves)
            {
                foreach (Item item in shelf.items)
                {
                    sum += item.size;
                }
                sumb += shelf.placeInShelf - sum;


            }

            return sumb;
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
        public List<Item> itemsYouCanEat(int foodType, int foodKashrut)
        {
            List<Item> itemToEat = new List<Item>();
            foreach (Shelf shelf in shelves)
            {
                foreach (Item item in shelf.items)
                {
                    if (item.expiryDate <= DateTime.Today && item.foodType == foodType && item.foodKashrut == foodKashrut)
                    {
                        itemToEat.Add(item);
                    }

                }
            }
            return itemToEat;
        }

        //8
        public List<Item> sortByExpiryDate()
        {
            List<Item> sortedByExpiry = new List<Item>();
            foreach (Shelf shelf in shelves)
            {
                foreach (Item item in shelf.items) { sortedByExpiry.Add(item); }
            }
            sortedByExpiry.Sort((x, y) => DateTime.Compare(x.expiryDate, y.expiryDate));
            return sortedByExpiry;
        }

        public List<Shelf> sortByLeftSpace()
        {
            List<Shelf> sortedBySpace = new List<Shelf>();
            foreach (Shelf shelf in shelves)
            {
                shelf.placeInShelf = shelf.getPlaceInShelf();
                sortedBySpace.Add(shelf);
            }
            sortedBySpace.Sort();
            return sortedBySpace;
        }
        public List<Item> deleteByParameter(int foodKashrut, int days)
        {
            List<Item> toThrow = new List<Item>();
            foreach (Shelf shelf in shelves)
            {
                foreach (Item item in shelf.items)
                {
                    if (item.foodKashrut == foodKashrut && item.expiryDate.AddDays(3) >= DateTime.Today)
                    {
                        toThrow.Add(item);
                        shelf.items.Remove(item);
                    }

                }
            }
            return toThrow;

        }
        public void returnItem(List<Item> items, int i)
        {
            this.shelves[i].items.AddRange(items);
        }
        public int sumSpace(List<Item> items)
        {
            int sum = 0;
            foreach (Item item in items)
            {
                sum += item.size;
            }
            return sum;
        }
        public void goShopping()
        {
            List<Item> toThrowItem = new List<Item>();
            if (this.placeLeftInRefrigerator() >= 29) { Console.WriteLine("you can go shopping now"); }
            else
            {
                if (this.placeLeftInRefrigerator() >= 20) { Console.WriteLine("you can go shopping"); }
                else { this.throwExpired(); }

                if (this.placeLeftInRefrigerator() >= 20) { Console.WriteLine("you can go shopping"); }

                else
                {

                    toThrowItem = this.deleteByParameter(1, 3);
                    if (this.placeLeftInRefrigerator() + sumSpace(toThrowItem) >= 20)
                    {
                        Console.WriteLine("we threw the next items: ");
                        foreach (Item item in toThrowItem) { Console.WriteLine(item.itemName); }
                        Console.WriteLine("you can go now");
                    }
                    else
                    {
                        List<Item> toThrowItem2 = new List<Item>();
                        toThrowItem2 = this.deleteByParameter(2, 7);
                        if (this.placeLeftInRefrigerator() + sumSpace(toThrowItem) + sumSpace(toThrowItem2) >= 20)
                        {
                            Console.WriteLine("we threw the next items: ");
                            foreach (Item item in toThrowItem) { Console.WriteLine(item.itemName); }
                            foreach (Item item in toThrowItem2) { Console.WriteLine(item.itemName); }
                            Console.WriteLine("you can go now");
                        }
                        else
                        {
                            List<Item> toThrowItem3 = new List<Item>();
                            toThrowItem2 = this.deleteByParameter(0, 2);
                            if (this.placeLeftInRefrigerator() + sumSpace(toThrowItem) + sumSpace(toThrowItem2) + sumSpace(toThrowItem3) >= 20)
                            {
                                Console.WriteLine("we threw the next items: ");
                                foreach (Item item in toThrowItem) { Console.WriteLine(item.itemName); }
                                foreach (Item item in toThrowItem2) { Console.WriteLine(item.itemName); }
                                foreach (Item item in toThrowItem3) { Console.WriteLine(item.itemName); }
                                Console.WriteLine("you can go now");
                            }
                            else
                            {
                                returnItem(toThrowItem, 0);
                                returnItem(toThrowItem2, 1);
                                returnItem(toThrowItem3, 2);
                                Console.WriteLine("you can't go shopping right now");
                            }

                        }
                    }
                }


            }
        }


    }
}



