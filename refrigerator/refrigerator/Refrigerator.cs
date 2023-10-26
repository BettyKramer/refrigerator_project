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
        public Item RemoveItemById(int itemId)
        {
            Item item = null;
            Shelves.ForEach(shef => item = shef.RemoveItemFromShelf(itemId));
            return item;
        }
        public string ThrowExpired()
        {
            string str = "found something expired :  ";
            foreach (Shelf shelf in this.Shelves)
            {
                for (int i = 0; i < shelf.Items.Count; i++)
                {
                    if (shelf.Items[i].ExpiryDate < DateTime.Today)
                    {
                        str += " " + shelf.Items[i].Name;
                        shelf.FreeSpace += shelf.Items[i].Size;
                        shelf.Items.Remove(shelf.Items[i]);
                    }
                }
            }
            return str;
        }
        public bool CheckItem(Item item, int foodType, int foodKashrut)
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
                    if (CheckItem(item, foodType, foodKashrut))
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
                    if (shelf.Items[i] != null && shelf.Items[i].Kashrut == foodKashrut && shelf.Items[i].ExpiryDate.AddDays(days) >= DateTime.Today)
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
        public bool CheckIfCanGo(int space1, int space2)
        {
            if (this.GetFreeSpace() >= space1)
            {
                return true;
            }
            else
            {
                if (this.GetFreeSpace() >= space2)
                {
                    return true;
                }
                else
                { this.ThrowExpired(); }

                if (this.GetFreeSpace() >= space2)
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckToDelete(List<Item> toThrowItem, int space)
        {
            if (this.GetFreeSpace() + GetSumSpace(toThrowItem) >= space)
            {
                Console.WriteLine("we threw the next items: ");
                foreach (Item item in toThrowItem)
                { Console.WriteLine(item.Name); }
                return true;
            }
            return false;
        }
        public void GoShopping()
        {
            const int twenty = 20;
            const int twentyNine = 29;
            List<Item> toThrowItem = new List<Item>();
            if (CheckIfCanGo(twenty, twentyNine))
            {
                Console.WriteLine("you can go now");
                return;
            }
            else
            {
                toThrowItem = this.DeleteByParameter(2, 3);
                if (CheckToDelete(toThrowItem, twenty))
                {
                    Console.WriteLine("you can go now");
                    return;
                }
                else
                {
                    toThrowItem.AddRange(this.DeleteByParameter(2, 7));
                    if (CheckToDelete(toThrowItem, twenty))
                    {
                        Console.WriteLine("you can go now");
                        return;
                    }

                    else
                    {
                        toThrowItem.AddRange(this.DeleteByParameter(0, 2));
                        if (CheckToDelete(toThrowItem, twenty))
                        {
                            Console.WriteLine("you can go now");
                            return;
                        }

                        else
                        {
                            ReturnItem(toThrowItem, 0);
                            Console.WriteLine("you can't go shopping right now");
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
        public void Eat(int type, int kashrut)
        {
            Shelves.ForEach(shelf => shelf.GetItemByTypeAndKashrut(type, kashrut)); 
        }
        public void PrintByExpiryDtae()
        {
            List<Item> items = this.SortByExpiryDate();
            foreach (Item item in items)
            {
                Console.WriteLine(item.Name + " the expiry date: " + item.ExpiryDate);
            }
        }
        public void PrintShelvesByPlace()
        {
            List<Shelf> shelves = this.SortByLeftSpace();
            foreach (Shelf shelf in shelves)
            {
                Console.WriteLine("shelf id: " + shelf.Id + " place left:" + shelf.FreeSpace);
            }
        }
    }
}



