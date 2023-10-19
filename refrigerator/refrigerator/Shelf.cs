namespace refrigerator
{
    internal class Shelf
    {
        public int shelfId { get; }
        public int floorNumber { get; }

        public int placeInShelf { get; set; }

        public List<Item> items;
        public Item getItem()
        {
            return this.items[0];
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
        }

        public void toString()
        {
            Console.WriteLine("self id: " + shelfId + " floor number: " + floorNumber + " place in shelf: " + placeInShelf);
        }


        public Item getItemFromShelf(int itemid)
        {
            foreach (Item item in this.items)
            {
                if(itemid==item.itemId)
                    return item;
            }
            return null;
        }

        public void throwEexpired()
        {
            foreach(Item item in this.items)
            {
                if (item.expiryDate < DateTime.Today)
                {
                    Console.WriteLine("found something expired");
                    this.items.Remove(item);
                }
            }
        }

    }
}