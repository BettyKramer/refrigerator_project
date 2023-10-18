namespace refrigerator
{
    class Item
    {
        public string itemName { get; }
        public int itemId { get; }
        foodOrDrnik fd ;
        kashroot kasher;
        public DateTime expiryDate { get; }
        public int size { get; }

        public void toString()
        {
            Console.WriteLine("item name: "+itemName+" item id: "+itemId+" type: "+fd+" kasher: "+kasher+
                " expiry date: "+expiryDate+" size: "+size);
        }

        enum foodOrDrnik { FOOD, DRINK }
        enum kashroot { MEAT, MMILK ,PARVE}
    }

}

