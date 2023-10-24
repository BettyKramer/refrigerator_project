using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refrigerator
{
    public class Refrigerator
    {
        public int refrigeratorId { get; }
        public string model { get; }
        public string color { get; }
   
     
        public int numOfShelves { get; }

        public List<Shelf> shelves { get;set; }


       public Refrigerator()
        {
            refrigeratorId = 1;
            this.model = "bocsh";
            this.color = "grey";
            this.numOfShelves = 5;
            shelves = new List<Shelf>();
        }

        public Refrigerator(int refId,string model, string color,int numOfShelves)
        {
            this.refrigeratorId = refId;
            this.model = model;
            this.color = color;
            this.numOfShelves= numOfShelves;
            shelves = new List<Shelf>();
        }




        public void toString()
        {
            Console.WriteLine("refrigerator id: " + refrigeratorId + "\n model: " + model + "\n color: "
                + color + "\n num of shelves:" + numOfShelves);

        }

        //2
        public int placeLeftInRefrigerator()
        {
            int sum = 0;
            foreach(Shelf shelf in shelves)
            {
                sum += shelf.placeInShelf;
            }
            return sum;
        }

        //4
        public Item getItemFromRfrigerator(int itemid)
        {
            foreach (Shelf shelf in shelves)
            {
                Item item = shelf.getItemFromShelf(itemid);
                if (item != null) 
                {
                    shelf.placeInShelf += item.size;
                    return item; 
                }
            }
            Console.WriteLine("the item is not here");
            return null;
        }

        public Item getItemByName(string name)
        {
            foreach (Shelf shelf in shelves)
            {
                foreach (Item item in shelf.items)
                {
                    if (item.Name.Equals(name))
                    {
                        shelf.placeInShelf += item.size;
                        shelf.items.Remove(item);
                        Console.WriteLine("we removed your item");
                        return item;
                    }
                }
            }
            Console.WriteLine("there is no such an item");
            return null;
        }

        //5
        public void throwExpired()
        {
            foreach (Shelf shelf in this.shelves)
            {
                for(int i = 0;i < shelf.items.Count ;i++)
                {
                    if (shelf.items[i].expiryDate < DateTime.Today)
                    {
                        Console.WriteLine("found something expired :  "+ shelf.items[i].Name);
                        shelf.placeInShelf += shelf.items[i].size;
                        shelf.items.Remove(shelf.items[i]);
                        
                    }
                }
                
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
                    if (item.expiryDate <= DateTime.Today && item.type == foodType && item.Kashrut == foodKashrut)
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
                sortedBySpace.Add(shelf);
            }
            sortedBySpace.Sort((x,y)=>x.placeInShelf.CompareTo(y.placeInShelf));
            return sortedBySpace;
        }


        public void printAllItems()
        {
            Console.WriteLine("items in the refrigerator: ");
            foreach (Shelf shelf in shelves)
            {
                foreach(Item item in shelf.items) { Console.WriteLine(item.Name); }
            }
        }



        public List<Item> deleteByParameter(int foodKashrut, int days)
        {
            List<Item> toThrow = new List<Item>();
            foreach (Shelf shelf in shelves)
            {
                for(int i=0; i<shelf.items.Count;i++)
                {
                    if (shelf.items[i]!=null&&shelf.items[i].Kashrut == foodKashrut && shelf.items[i].expiryDate.AddDays(3) >= DateTime.Today)
                    {
                        toThrow.Add(shelf.items[i]);
                        shelf.items.Remove(shelf.items[i]);
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
                        foreach (Item item in toThrowItem) { Console.WriteLine(item.Name); }
                        Console.WriteLine("you can go now");
                    }
                    else
                    {
                        List<Item> toThrowItem2 = new List<Item>();
                        toThrowItem2 = this.deleteByParameter(2, 7);
                        if (this.placeLeftInRefrigerator() + sumSpace(toThrowItem) + sumSpace(toThrowItem2) >= 20)
                        {
                            Console.WriteLine("we threw the next items: ");
                            foreach (Item item in toThrowItem) { Console.WriteLine(item.Name); }
                            foreach (Item item in toThrowItem2) { Console.WriteLine(item.Name); }
                            Console.WriteLine("you can go now");
                        }
                        else
                        {
                            List<Item> toThrowItem3 = new List<Item>();
                            toThrowItem3 = this.deleteByParameter(0, 2);
                            if (this.placeLeftInRefrigerator() + sumSpace(toThrowItem) + sumSpace(toThrowItem2) + sumSpace(toThrowItem3) >= 20)
                            {
                                Console.WriteLine("we threw the next items: ");
                                foreach (Item item in toThrowItem) { Console.WriteLine(item.Name); }
                                foreach (Item item in toThrowItem2) { Console.WriteLine(item.Name); }
                                foreach (Item item in toThrowItem3) { Console.WriteLine(item.Name); }
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


        public  bool ValidateInput(string input, string type)
        {
            switch (type)
            {
                case "int":
                    return int.TryParse(input, out int val);
                case "date":
                    return DateTime.TryParse(input, out DateTime val2);

            }
            return true;
        }


        public void printDetails()
        {
            this.toString();
            this.printAllItems();
        }

        public void placeLeftInFridge()
        {
            Console.WriteLine("place left in the fridge: " + this.placeLeftInRefrigerator());
        }

        public void addItem()
        {
            Console.WriteLine("enter name");
            string input = Console.ReadLine();

            if (!this.ValidateInput(input, "string"))
            {
                Console.WriteLine("illigal input");
                return;
            }
            string name = input;


            Console.WriteLine("enter id");
            input = Console.ReadLine();
            if (!ValidateInput(input, "int"))
            {
                Console.WriteLine("illigal input");
                return;
            }
            int id = Convert.ToInt32(input);


            Console.WriteLine("enter 1 for food, 2 for drink");
            input = Console.ReadLine();
            if (!ValidateInput(input, "int"))
            {
                Console.WriteLine("illigal input");
                return;
            }
            int foodOdrink = int.Parse(input);


            Console.WriteLine("enter kashrut: 1 for meat, 2 for milk , 3 for parve");
            input = Console.ReadLine();
            if (!ValidateInput(input, "int"))
            {
                Console.WriteLine("illigal input");
                return;
            }
            int kasher = int.Parse(input);

            Console.WriteLine("enter expiry date (dd/mm/yyyy)");
            input = Console.ReadLine();
            if (!ValidateInput(input, "date"))
            {
                Console.WriteLine("illigal input");
                return;
            }
            DateTime date = DateTime.Parse(input);


            Console.WriteLine("enter size of the item");
            input = Console.ReadLine();
            if (!ValidateInput(input, "int"))
            {
                Console.WriteLine("illigal input");
                return;
            }
            int size = int.Parse(input);


            Item item = new Item(name, id, foodOdrink, kasher, date, size);
            foreach (Shelf shelf in this.shelves)
            {
                if (shelf.placeInShelf >= item.size)
                {
                    shelf.items.Add(item);
                    shelf.placeInShelf -= item.size;
                    Console.WriteLine("we added your item");
                    return;
                }

            }
            Console.WriteLine("we didnt find a place in the fridge");
        }

        public void removeItem()
        {
            Console.WriteLine("please the enter item you want to remove");
            string input = Console.ReadLine();
            this.getItemByName(input);
        }



        public void cleanFridge() { this.throwExpired(); }

        public void eat()
        {
            Console.WriteLine("what do you want to eat?");
            string name = Console.ReadLine();
            Item item = this.getItemByName(name);
            Console.WriteLine("here is your item: ");
            item.toString();

        }

        public void printByExpiryDtae( )
        {
            List<Item> items = this.sortByExpiryDate();
            foreach (Item item in items) { Console.WriteLine(item.Name + " the expiry date: " + item.expiryDate); }
        }

        public void printShelvesByPlace()
        {
            List<Shelf> shelves = this.sortByLeftSpace();
            foreach (Shelf shelf in shelves) { Console.WriteLine("shelf id: " + shelf.shelfId + " place left:" + shelf.placeInShelf); }
        }
      


        public void prepereForShopping()
        {
            this.goShopping();
        }

        public void shutDown()
        {
            Console.WriteLine("bye bye ");
        }




    }
}



