namespace refrigerator
{
    public class Shelf
    {
        public int Id { get; set; }

        public int FloorNumber { get; set; }

        public int PlaceInShelf { get; set; }

        public List<Item> Items;
        public Item getItem()
        {
            return this.Items[0];
        }

        public Shelf(int shelfId, int floorNumber, int placeInShelf)
        {
            this.Id = shelfId;
            this.FloorNumber = floorNumber;
            this.PlaceInShelf = placeInShelf;
            this.Items =new List<Item>();
        }

        public Shelf()
        {
            this.Id = 1;
            this.FloorNumber = 1;
            this.PlaceInShelf = 100;
            this.Items = new List<Item>();
        }

        public int getPlaceInShelf()
        {
            int sum = 0;
            foreach (Item item in this.Items)
            {
                sum += item.Size;
            }
            return this.PlaceInShelf - sum;
        }


        //3
        public void addItem(Item item)
        {
            this.Items.Add(item);
            this.PlaceInShelf -= item.Size;
        }

       
   
        public override string ToString()
        {
            string str = $"self id: {Id} floor number: {FloorNumber} place in shelf:{PlaceInShelf}";
            return str;


        }   


        public Item GetItemFromShelf(int itemid)
        {
            foreach (Item item in this.Items)
            {
                if (itemid == item.Id)
                {
                    this.PlaceInShelf += item.Size;
                    return item;
                }
                   
            }
            return null;
        }

        public void ThrowEexpired()
        {
            foreach(Item item in this.Items)
            {
                if (item.ExpiryDate < DateTime.Today)
                {
                    Console.WriteLine("found something expired"+item.Name);
                    this.Items.Remove(item);
                    this.PlaceInShelf += item.Size;
                }
            }
        }

    }
}