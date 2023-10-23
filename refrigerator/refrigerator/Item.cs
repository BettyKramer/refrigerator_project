namespace refrigerator
{
   


    public class Item
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public int ShelfNumber { get; set; }
       
        public DateTime expiryDate { get; set; }
        public int size { get; set; }

        public int type { set; get; }
        public int Kashrut { set; get; }



        public Item(string itemName,int id, int foodType, int foodKasher, DateTime epx, int size) {
           
            this.Name = itemName;
            this.Id = id;
            this.type = foodType;
            this.Kashrut = foodKasher;
            this.expiryDate = epx;
            this.size = size;
        }
     
        public void toString()
        {
            Console.WriteLine($"item name:  {Name}  item id:  { Id}   type: { type}  kasher: { Kashrut} expiry date:{expiryDate} size:{ size}");
        }

    
    }



}

