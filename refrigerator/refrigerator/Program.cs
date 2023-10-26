
using refrigerator;
using System.Diagnostics;
using System.Text;

public class Program
{

    public static List<Refrigerator> SortFridgeByPlace(List<Refrigerator> refrigerators)
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


    public static void ShowMenu()
    {
        Console.WriteLine();
        StringBuilder sb = new StringBuilder();
        sb.Append("Press 1: the program will print all the items on the refrigerator and all its contents");
        sb.Append("Click 2: the program will print how much space is left in the fridge");
        sb.Append("Press 3: The program will allow the user to put an item in the refrigerator.");
        sb.Append("Press 4: The program will allow the user to remove an item from the refrigerator");
        sb.Append("Press 5: the program will clean the refrigerator and print all the checked items to the user.");
        sb.Append("Press 6: the program will ask the user What do I want to eat and bring the function to bring a product.");
        sb.Append("Click 7: the program will print all the products sorted by their expiration date.");
        sb.Append("Press 8: the program will print all the shelves arranged according to the free space left on them.");
        sb.Append("Press 9: the program will print all the refrigerators arranged according to the free space left in them.");
        sb.Append("Click 10: The program will prepare the refrigerator for shopping");
        sb.Append("Press 100: system shutdown.");
        Console.WriteLine(sb.ToString());
    }

    public static void Main(string[] args)
    {
        List<Refrigerator> refrigerators = new List<Refrigerator>();

        //fiil 1 frg
        Refrigerator refrigerator = new Refrigerator(0, "bosh", "grey", 5);
        Refrigerator refrigerator2 = new Refrigerator(1, "samsung", "black", 3);

        Shelf shelf = new Shelf(21, 1, 50);
        Shelf shelf1 = new Shelf(22, 2, 100);
        Shelf shelf2 = new Shelf(23, 3, 200);


        refrigerator.Shelves.Add(shelf);
        refrigerator.Shelves.Add(shelf1);
        refrigerator2.Shelves.Add(shelf2);

        refrigerators.Add(refrigerator);
        refrigerators.Add(refrigerator2);


        int choise = 1;

        while (choise != 100)
        {
            ShowMenu();
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
                    Console.WriteLine(refrigerators[0].ToString());
                    refrigerators[0].PrintDetails();
                    break;
                case 2:
                    Console.WriteLine("place left in the fridge: " + refrigerators[0].GetFreeSpace());                    break;
                case 3:
                    refrigerators[0].AddItem();
                    break;
                case 4:
                    refrigerators[0].RemoveItem();
                    break;
                case 5:
                    refrigerators[0].CleanFridge();
                    break;
                case 6:
                    refrigerators[0].Eat();
                    break;
                case 7:
                    refrigerators[0].PrintByExpiryDtae();
                    break;
                case 8:
                    refrigerators[0].PrintShelvesByPlace();
                    break;
                case 9:
                    SortFridgeByPlace(refrigerators);
                    break;
                case 10:
                    refrigerators[0].PrepereForShopping();
                    break;
                case 100:
                    refrigerators[0].ShutDown();
                    break;
            }
        }


    }


}