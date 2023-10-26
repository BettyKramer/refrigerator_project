using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refrigerator
{
    public class Refrigerator
    {
        public int Id { get; }
        public string Model { get; }
        public string Color { get; }


        public int NumberOfShelves { get; set; }

        public List<Shelf> Shelves { get; set; }




        public Refrigerator(int Id, string model, string color, int numOfShelves)
        {
            this.Id = Id;
            this.Model = model;
            this.Color = color;
            this.NumberOfShelves = numOfShelves;
            Shelves = new List<Shelf>();
        }




        public override string ToString()
        {
            string str = $"refrigerator id: {Id} model:{Model} color:{Color} num of shelves: {NumberOfShelves}";
            return str;
        }

        //2
        public int GetFreeSpace()
        {
            int sum = 0;
            Shelves.Sum(sh => sum += sh.FreeSpace);
            return sum;
        }

        //4
        public Item GetItemById(int itemId)
        {
            Item item = null;

            Shelves.ForEach(shef => item = shef.GetItemFromShelf(itemId));

            Console.WriteLine("the item is not here");

            return item;
        }

        //public string GetItemById(int id)
        //{
        //   Shelves.ForEach(shef => shef.Id == id);
        //}

        //5
        public void ThrowExpired()
        {
            foreach (Shelf shelf in this.Shelves)
            {
                for (int i = 0; i < shelf.Items.Count; i++)
                {
                    if (shelf.Items[i].ExpiryDate < DateTime.Today)
                    {
                        string str = "found something expired :  " + shelf.Items[i].Name;
                        shelf.FreeSpace += shelf.Items[i].Size;
                        shelf.Items.Remove(shelf.Items[i]);
                    }
                }
            }
        }

        public bool CheckItem (Item item, int foodType, int foodKashrut)
        {
            if (item.ExpiryDate <= DateTime.Today && item.Type == foodType && item.Kashrut == foodKashrut)
                return true;
            return false;
        }



        //6
        public List<Item> GetItemsYouCanEat(int foodType, int foodKashrut)
        {
            List<Item> itemToEat = new List<Item>();
            foreach (Shelf shelf in Shelves)
            {
                foreach (Item item in shelf.Items)
                {
                    if (CheckItem(item,foodType,foodKashrut))
                    {
                        itemToEat.Add(item);
                    }
                }
            }
            return itemToEat;
        }

        //8
        public List<Item> SortByExpiryDate()
        {
            List<Item> sortedByExpiry = new List<Item>();
            foreach (Shelf shelf in Shelves)
            {
                foreach (Item item in shelf.Items) { sortedByExpiry.Add(item); }
            }
            sortedByExpiry.Sort((x, y) => DateTime.Compare(x.ExpiryDate, y.ExpiryDate));
            return sortedByExpiry;
        }

        public List<Shelf> SortByLeftSpace()
        {
            List<Shelf> sortedBySpace = new List<Shelf>();
            foreach (Shelf shelf in Shelves)
            {
                sortedBySpace.Add(shelf);
            }
            sortedBySpace.Sort((x, y) => x.FreeSpace.CompareTo(y.FreeSpace));
            return sortedBySpace;
        }


        public void PrintAllItems()
        {
            Console.WriteLine("items in the refrigerator: ");
            foreach (Shelf shelf in Shelves)
            {
                foreach (Item item in shelf.Items) { Console.WriteLine(item.Name); }
            }
        }



        public List<Item> DeleteByParameter(int foodKashrut, int days)
        {
            List<Item> toThrow = new List<Item>();
            foreach (Shelf shelf in Shelves)
            {
                for (int i = 0; i < shelf.Items.Count; i++)
                {
                    if (shelf.Items[i] != null && shelf.Items[i].Kashrut == foodKashrut && shelf.Items[i].ExpiryDate.AddDays(3) >= DateTime.Today)
                    {
                        toThrow.Add(shelf.Items[i]);
                        shelf.Items.Remove(shelf.Items[i]);
                    }

                }
            }
            return toThrow;

        }

        public void ReturnItem(List<Item> items, int i)
        {
            this.Shelves[i].Items.AddRange(items);
        }

        public int GetSumSpace(List<Item> items)
        {
            int sum = 0;
            foreach (Shelf shelf in Shelves)
                sum += shelf.Items.Sum(x => x.Size);

            return sum;
        }

        public void GoShopping()
        {
            List<Item> toThrowItem = new List<Item>();
            if (this.GetFreeSpace() >= 29) { Console.WriteLine("you can go shopping now"); }
            else
            {
                if (this.GetFreeSpace() >= 20) { Console.WriteLine("you can go shopping"); }
                else { this.ThrowExpired(); }

                if (this.GetFreeSpace() >= 20) { Console.WriteLine("you can go shopping"); }

                else
                {

                    toThrowItem = this.DeleteByParameter(1, 3);
                    if (this.GetFreeSpace() + GetSumSpace(toThrowItem) >= 20)
                    {
                        Console.WriteLine("we threw the next items: ");
                        foreach (Item item in toThrowItem) { Console.WriteLine(item.Name); }
                        Console.WriteLine("you can go now");
                    }
                    else
                    {
                        List<Item> toThrowItem2 = new List<Item>();
                        toThrowItem2 = this.DeleteByParameter(2, 7);
                        if (this.GetFreeSpace() + GetSumSpace(toThrowItem) + GetSumSpace(toThrowItem2) >= 20)
                        {
                            Console.WriteLine("we threw the next items: ");
                            foreach (Item item in toThrowItem) { Console.WriteLine(item.Name); }
                            foreach (Item item in toThrowItem2) { Console.WriteLine(item.Name); }
                            Console.WriteLine("you can go now");
                        }
                        else
                        {
                            List<Item> toThrowItem3 = new List<Item>();
                            toThrowItem3 = this.DeleteByParameter(0, 2);
                            if (this.GetFreeSpace() + GetSumSpace(toThrowItem) + GetSumSpace(toThrowItem2) + GetSumSpace(toThrowItem3) >= 20)
                            {
                                Console.WriteLine("we threw the next items: ");
                                foreach (Item item in toThrowItem) { Console.WriteLine(item.Name); }
                                foreach (Item item in toThrowItem2) { Console.WriteLine(item.Name); }
                                foreach (Item item in toThrowItem3) { Console.WriteLine(item.Name); }
                                Console.WriteLine("you can go now");
                            }
                            else
                            {
                                ReturnItem(toThrowItem, 0);
                                ReturnItem(toThrowItem2, 1);
                                ReturnItem(toThrowItem3, 2);
                                Console.WriteLine("you can't go shopping right now");
                            }

                        }
                    }
                }


            }
        }


        public bool ValidateInput(string input, string type)
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


        public void PrintDetails()
        {
            this.ToString();
            this.PrintAllItems();
        }

        public void AddItem()
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
            foreach (Shelf shelf in this.Shelves)
            {
                if (shelf.FreeSpace >= item.Size)
                {
                    shelf.Items.Add(item);
                    shelf.FreeSpace -= item.Size;
                    Console.WriteLine("we added your item");
                    return;
                }

            }
            Console.WriteLine("we didnt find a place in the fridge");
        }

        public void RemoveItem()
        {
            Console.WriteLine("please the enter item you want to remove");
            Int32.TryParse(Console.ReadLine(), out int ItenId);
            
            this.GetItemById(ItenId);
        }



        public void CleanFridge() { this.ThrowExpired(); }

        public void Eat()
        {
            Console.WriteLine("what do you want to eat?");
            
            Int32.TryParse(Console.ReadLine(), out int itemId);

            Item item = this.GetItemById(itemId);

            Console.WriteLine("here is your item: ");
            item.ToString();

        }

        public void PrintByExpiryDtae()
        {
            List<Item> items = this.SortByExpiryDate();
            foreach (Item item in items) { Console.WriteLine(item.Name + " the expiry date: " + item.ExpiryDate); }
        }
        public void PrintShelvesByPlace()
        {
            List<Shelf> shelves = this.SortByLeftSpace();
            foreach (Shelf shelf in shelves) 
            { 
                Console.WriteLine("shelf id: " + shelf.Id + " place left:" + shelf.FreeSpace);
            }
        }



        public void PrepereForShopping()
        {
            this.GoShopping();
        }

        public void ShutDown()
        {
            Console.WriteLine("bye bye ");
        }


    }
}



