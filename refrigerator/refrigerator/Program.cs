
using refrigerator;

public class Program
{

    public static List<Refrigerator> sortFridgeByPlace(List<Refrigerator> refrigerators)
    {
        List<Refrigerator> sortedByPlace = new List<Refrigerator>();
        sortedByPlace = refrigerators.OrderByDescending(refrigerator => refrigerator.GetFreeSpace()).ToList();
        foreach (Refrigerator refrigerator in sortedByPlace)
        {
            Console.WriteLine("fridge details: ");
            refrigerator.ToString();
            Console.WriteLine("place left in the fridge: " + refrigerator.GetFreeSpace());
            Console.WriteLine();
        }
        return sortedByPlace;

    }


    public static void showMenu()
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

    public static void Main(string[] args)
    {
        List<Refrigerator> myFriges = new List<Refrigerator>();

        //fiil 1 frg
        Refrigerator rfg = new Refrigerator(0,"bosh","grey",5);
        Refrigerator rfg2 = new Refrigerator(1, "samsung", "black", 3);

        Shelf shelf = new Shelf(21, 1, 50);
        Shelf shelf1 = new Shelf(22, 2, 100);
        Shelf shelf2 = new Shelf(23, 3, 200);


        rfg.Shelves.Add(shelf);
        rfg.Shelves.Add(shelf1);
        rfg2.Shelves.Add(shelf2);

        myFriges.Add(rfg);
        myFriges.Add(rfg2);


        int choise = 1;

        while (choise != 100)
        {
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
                    myFriges[0].printDetails();
                    break;
                case 2:
                    myFriges[0].placeLeftInFridge();
                    break;
                case 3:
                    myFriges[0].addItem();
                    break;
                case 4:
                    myFriges[0].removeItem();
                    break;
                case 5:
                    myFriges[0].cleanFridge();
                    break;
                case 6:
                    myFriges[0].eat();
                    break;
                case 7:
                    myFriges[0].printByExpiryDtae();
                    break;
                case 8:
                    myFriges[0].printShelvesByPlace();
                    break;
                case 9:
                    sortFridgeByPlace(myFriges);
                    break;
                case 10:
                    myFriges[0].prepereForShopping();
                    break;
                case 100:
                    myFriges[0].shutDown();
                    break;
            }
        }


    }


}