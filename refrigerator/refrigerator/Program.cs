
using refrigerator;

public class Program
{
    static bool ValidateInput(string input, string type)
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
    static List<Refrigerator> sortFridgeByPlace(List<Refrigerator> refrigerators)
    {
        List<Refrigerator> sortedByPlace = new List<Refrigerator>();
        sortedByPlace = refrigerators.OrderByDescending(refrigerator => refrigerator.placeLeftInRefrigerator()).ToList();
        foreach (Refrigerator refrigerator in sortedByPlace)
        {
            Console.WriteLine("fridge details: ");
                refrigerator.toString();
            Console.WriteLine("place left in the fridge: "+refrigerator.placeLeftInRefrigerator());
            Console.WriteLine();
        }
        return sortedByPlace;

    }

    static void showMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Press 1: the program will print " +
            "all the items on the refrigerator and all its " +
            "contents.\r\nClick 2: the program will print how" +
            " much space is left in the fridge\r\nPress 3: The" +
            " program will allow the user to put an item in the" +
            " refrigerator.\r\nPress 4: The program will allow " +
            "the user to remove an item from the refrigerator.\r\nPress 5:" +
            " the program will clean the refrigerator and print all the checked " +
            "items to the user.\r\nPress 6: the program will ask the user &quot;What " +
            "do I want to eat?&quot; and bring the function to bring a product.\r\nClick 7:" +
            " the program will print all the products sorted by their expiration " +
            "date.\r\nPress 8: the program will print all the shelves arranged " +
            "according to the free space left on them.\r\nPress 9: the program will " +
            "print all the refrigerators arranged according to the free space left" +
            " in them.\r\nClick 10: The program will prepare the refrigerator for " +
            "shopping\r\nPress 100: system shutdown.");
    }

    static void press1(Refrigerator fridge)
    {
        fridge.toString();
        fridge.printAllItems();
    }

    static void press2(Refrigerator fridge) 
    { 
        Console.WriteLine("place left in the fridge: "+fridge.placeLeftInRefrigerator()); 
    }

    static void press3(Refrigerator fridge)
    {
        Console.WriteLine("enter name");
         string input = Console.ReadLine();

        if(!ValidateInput(input, "string"))
        {
            Console.WriteLine("illigal input");
            return;
        }
        string name =input;


        Console.WriteLine("enter id");
         input = Console.ReadLine();
        if (!ValidateInput(input, "int"))
        {
            Console.WriteLine("illigal input");
            return;
        }
        int id =Convert.ToInt32( input);


        Console.WriteLine("enter 1 for food, 2 for drink");
        input= Console.ReadLine();
        if (!ValidateInput(input, "int"))
        {
            Console.WriteLine("illigal input");
            return;
        }
        int foodOdrink = int.Parse(input);


        Console.WriteLine("enter kashrut: 1 for meat, 2 for milk , 3 for parve");
         input= Console.ReadLine();
        if (!ValidateInput(input, "int"))
        {
            Console.WriteLine("illigal input");
            return;
        }
        int kasher = int.Parse(input);

        Console.WriteLine("enter expiry date (dd/mm/yyyy)");
        input= Console.ReadLine();
        if (!ValidateInput(input, "date"))
        {
            Console.WriteLine("illigal input");
            return; 
        }
        DateTime date = DateTime.Parse(input);


        Console.WriteLine("enter size of the item");
        input= Console.ReadLine();
        if (!ValidateInput(input, "int"))
        {
            Console.WriteLine("illigal input");
            return;
        }
        int size = int.Parse(input);


        Item item = new Item(name, id, foodOdrink, kasher, date, size);
        foreach (Shelf shelf in fridge.shelves)
        {
            if (shelf.placeInShelf >= item.size)
            {
                shelf.items.Add(item);
                shelf.placeInShelf -= item.size;
                Console.WriteLine("we added your item");
                return;
            }
           
        }
        Console.WriteLine("we didnt find a place in the fridge");
    }



    static void press4(Refrigerator fridge)
    {
        Console.WriteLine("please the enter item you want to remove");
        string input = Console.ReadLine();
        fridge.getItemByName(input);
    }



    static void press5(Refrigerator fridge){fridge.throwExpired();}

    static  void press6(Refrigerator fridge)
    {
        Console.WriteLine("what do you want to eat?");
        string name = Console.ReadLine();
        Item item = fridge.getItemByName(name);
        Console.WriteLine("here is your item: ");
        item.toString();

    }

    static void press7(Refrigerator fridge)
    {
        List<Item> items = fridge.sortByExpiryDate();
        foreach (Item item in items) { Console.WriteLine(item.itemName+" the expiry date: "+ item.expiryDate); }
    }

    static void press8(Refrigerator fridge)
    {
        List<Shelf> shelves = fridge.sortByLeftSpace();
        foreach (Shelf shelf in shelves) { Console.WriteLine("shelf id: " + shelf.shelfId + " place left:" + shelf.placeInShelf); }
    }
    static void press9(List<Refrigerator> refrigerators)
    {
        sortFridgeByPlace(refrigerators);
    }


    static void press10(Refrigerator fridge)
    {
        fridge.goShopping();
    }

    static void press100(Refrigerator fridge)
    {
        Console.WriteLine("bye bye ");
    }


    static void Main(string[] args)
    {
     
        List<Refrigerator> myFriges = new List<Refrigerator>();

        //fiil 1 frg
        Refrigerator rfg  = new Refrigerator();
        Refrigerator rfg2 = new Refrigerator(1,"samsung","black",3);

        Shelf shelf = new Shelf(21,1,50);
        Shelf shelf1 = new Shelf(22,2,100);
        Shelf shelf2=new Shelf(23,3,200);


        rfg.shelves.Add(shelf);
        rfg.shelves.Add(shelf1);
        rfg2.shelves.Add(shelf2);

        myFriges.Add(rfg);
        myFriges.Add(rfg2);


        int choise = 1;

        while(choise != 100) {
            showMenu();
            try
            {
                choise = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Iligal Choise");
                choise = 100;
            }

            switch (choise)
            {
                case 1:
                    press1(myFriges[0]);
                    break;
                case 2:
                    press2(myFriges[0]);
                    break;
                case 3:
                    press3(myFriges[0]);
                    break;
                case 4:
                    press4(myFriges[0]);
                    break;
                case 5:
                    press5(myFriges[0]);
                    break;
                case 6:
                    press6(myFriges[0]);
                    break;
                case 7:
                    press7(myFriges[0]);
                    break;
                case 8:
                    press8(myFriges[0]);
                    break;
                case 9:
                    press9(myFriges);
                    break;
                case 10:
                    press10(myFriges[0]);
                    break;
                case 100:
                    press100(myFriges[0]);
                    break;
            }
        }
    

    }


}