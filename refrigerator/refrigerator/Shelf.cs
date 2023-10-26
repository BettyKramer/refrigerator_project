using System.Xml.Linq;
using System;

namespace refrigerator
{
    public class Shelf
    {
        public int Id { get; set; }
        public int FloorNumber { get; set; }
        public int FreeSpace { get; set; }

        public List<Item> Items;
        public Item getItem()
        {
            return this.Items[0];
        }
        public Shelf(int shelfId, int floorNumber, int placeInShelf)
        {
            this.Id = shelfId;
            this.FloorNumber = floorNumber;
            this.FreeSpace = placeInShelf;
            this.Items = new List<Item>();
        }
        public Shelf()
        {
            this.Id = 1;
            this.FloorNumber = 1;
            this.FreeSpace = 100;
            this.Items = new List<Item>();
        }
        public void AddItem(Item item)
        {
            this.Items.Add(item);
            this.FreeSpace -= item.Size;
        }
        public override string ToString()
        {
            string str = $"self id: {Id} floor number: {FloorNumber} place in shelf:{FreeSpace}";
            return str;


        }
        public Item RemoveItemFromShelf(int itemid)
        {
            foreach (Item item in this.Items)
            {
                if (itemid == item.Id)
                {
                    this.FreeSpace += item.Size;
                    this.Items.Remove(item);
                    Console.WriteLine("we removed your item");
                    return item;
                }
            }
            return null;
        }
        public Item GetItem(string name)
        {
            foreach (Item item in this.Items)
            {
                if (item.Name.Equals(name))
                {
                    this.FreeSpace += item.Size;
                    this.Items.Remove(item);
                    Console.WriteLine("we removed your item");
                    return item;
                }
            }
            Console.WriteLine("we didnt find your item");
            return null;
        }
        public void ThrowEexpired()
        {
            foreach (Item item in this.Items)
            {
                if (item.ExpiryDate < DateTime.Today)
                {
                    Console.WriteLine("found something expired" + item.Name);
                    this.Items.Remove(item);
                    this.FreeSpace += item.Size;
                }
            }
        }
        public Item GetItemByTypeAndKashrut(int type, int kashrut)
        {
            Item item= this.Items.Find(item =>item.Type==type&&item.Kashrut==kashrut);
            RemoveItemFromShelf(item.Id);
            return item;
        }
    }
}