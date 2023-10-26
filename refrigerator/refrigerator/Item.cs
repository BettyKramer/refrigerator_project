namespace refrigerator
{
   


    public class Item
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int ShelfNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Size { get; set; }
        public int Type { set; get; }
        public int Kashrut { set; get; }

        public Item(string itemName,int id, int foodType, int foodKasher, DateTime epx, int size) {
           
            this.Name = itemName;
            this.Id = id;
            this.Type = foodType;
            this.Kashrut = foodKasher;
            this.ExpiryDate = epx;
            this.Size = size;
        }
        public override string ToString()
        {
            string str = $"item name:  {Name}  item id:  {Id}   type: {Type}  kasher: {Kashrut} expiry date:{ExpiryDate} size:{Size}";
            return str ;
        }
    }
}

