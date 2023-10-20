
using refrigerator;

public class Program
{

    static List<Refrigerator> sortByPlace(List<Refrigerator> refrigerators)
    {
        List<Refrigerator> sortedByPlace = new List<Refrigerator>();
        sortedByPlace = refrigerators.OrderByDescending(refrigerator => refrigerator.placeLeftInRefrigerator()).ToList();
        return sortedByPlace;

    }

    static void showMenu()
    {
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

    static void press2(Refrigerator fridge) { fridge.placeLeftInRefrigerator(); }

    static void press3(Refrigerator fridge)
    {
        Console.WriteLine("enter name");
        string name = Console.ReadLine();
        Console.WriteLine("enter id");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("enter drink or food");
        int foodOdrink = int.Parse(Console.ReadLine());
        Console.WriteLine("enter kashrut");
        int kasher = int.Parse(Console.ReadLine());
        Console.WriteLine("enter expiry date");
        DateTime date = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("enter size of the item");
        int size = int.Parse(Console.ReadLine());
        Item item = new Item(name, id, foodOdrink, kasher, date, size);
        foreach (Shelf shelf in fridge.shelves)
        {
            if (shelf.placeInShelf > item.size)
            {
                shelf.items.Add(item);
                break;
            }
        }
    }

    static void press4(Refrigerator fridge)
    {
        Console.WriteLine("please enter item id");
        int id = char.Parse(Console.ReadLine());
        fridge.getItemFromRfrigerator(id);
    }



    ///todo
    static void press5(Refrigerator fridge)
    {

        Console.WriteLine();

    }

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
        foreach (Item item in items) { Console.WriteLine(item.itemName); }
    }

    static void press8(Refrigerator fridge)
    {
        List<Shelf> shelves = fridge.sortByLeftSpace();
        foreach (Shelf shelf in shelves) { Console.WriteLine("shelf id: " + shelf.shelfId + " place left:" + shelf.placeInShelf); }
    }




    //todo
    void press9()
    {

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
        //better to add new list () for each list in the classes
        List<Refrigerator> myFtiges = new List<Refrigerator>();

        //fiil 1 frg
        Refrigerator rfg  = new Refrigerator();
        Shelf shelf = new Shelf();

        shelf.items = new List<Item>();

        //rfg.refrigeratorId = 1;

        rfg.shelves = new List<Shelf>();
        rfg.shelves.Add(shelf);

      


        myFtiges.Add(rfg);

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
                    press1(myFtiges[0]);
                    break;
                case 2:
                    press2(myFtiges[0]);
                    break;
                case 3:
                    press3(myFtiges[0]);
                    break;
                case 4:
                    press4(myFtiges[0]);
                    break;
                case 5:
                    press5(myFtiges[0]);
                    break;
            }
        }
    

    }


}