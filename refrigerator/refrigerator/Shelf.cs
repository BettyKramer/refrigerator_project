namespace refrigerator
{
    internal class Shelf
    {
        public int shelfId { get; set; }
        public int floorNumber { get; set; }

        public int placeInShelf { get; set; }

        public List<Item> items;
        public Item getItem()
        {
            return this.items[0];
        }

        public Shelf(int shelfId, int floorNumber, int placeInShelf)
        {
            this.shelfId = shelfId;
            this.floorNumber = floorNumber;
            this.placeInShelf = placeInShelf;
            this.items =new List<Item>();
        }

        public Shelf()
        {
            this.shelfId = 1;
            this.floorNumber = 1;
            this.placeInShelf = 100;
            this.items = new List<Item>();
        }

        public int getPlaceInShelf()
        {
            int sum = 0;
            foreach (Item item in this.items)
            {
                sum += item.size;
            }
            return this.placeInShelf - sum;
        }


        //3
        public void addItem(Item item)
        {
            this.items.Add(item);
            this.placeInShelf -= item.size;
        }

        public void toString()
        {
            Console.WriteLine("self id: " + shelfId + " floor number: " + floorNumber + " place in shelf: " + placeInShelf);
        }


        public Item getItemFromShelf(int itemid)
        {
            foreach (Item item in this.items)
            {
                if (itemid == item.itemId)
                {
                    this.placeInShelf += item.size;
                    return item;
                }
                   
            }
            return null;
        }

        public void throwEexpired()
        {
            foreach(Item item in this.items)
            {
                if (item.expiryDate < DateTime.Today)
                {
                    Console.WriteLine("found something expired"+item.itemName);
                    this.items.Remove(item);
                    this.placeInShelf += item.size;
                }
            }
        }

    }
}