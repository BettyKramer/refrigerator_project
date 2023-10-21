namespace refrigerator
{
    public enum typefood {food=1, drink };

    public enum kashre { MEAT=1, MILK, PARVE };


    public class Item
    {
        public string itemName { get; set; }
        public int itemId { get; set; }
       
        public DateTime expiryDate { get; set; }
        public int size { get; set; }

        public int foodType { set; get; }
        public int foodKashrut { set; get; }



        public Item(string itemName,int id, int foodType, int foodKasher, DateTime epx, int size) {
           
            this.itemName = itemName;
            this.itemId = id;
            this.foodType = foodType;
            this.foodKashrut = foodKasher;
            this.expiryDate = epx;
            this.size = size;
        }
        


        public Item()
        {
            this.itemName = "eggs";
            this.itemId = 10;
            this.foodType = 1;
            this.foodKashrut = 3;
            this.expiryDate = DateTime.Now;
            this.size = 10;
        }
     

        public void toString()
        {
            Console.WriteLine("item name: " + itemName + " item id: " + itemId + " type: " + foodType + " kasher: " + foodKashrut +
                " expiry date: " + expiryDate + " size: " + size);
        }

    
    }



}

