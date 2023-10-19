namespace refrigerator
{
    public enum typefood {food=1, drink };

    public enum kashre { MEAT, MILK, PARVE };


    public class Item
    {
        public string itemName { get; }
        public int itemId { get; }
       
        public DateTime expiryDate { get; }
        public int size { get; }

        public int foodType { set; get; }
        public int foodKashrut { set; get; }

        public Item(string itemName, int foodType) { 
            this.itemName = itemName;
            this.foodType = foodType;
        }

        public void toString()
        {
            Console.WriteLine("item name: " + itemName + " item id: " + itemId + " type: " + foodType + " kasher: " + foodKashrut +
                " expiry date: " + expiryDate + " size: " + size);
        }

    
    }



}

