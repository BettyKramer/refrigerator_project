
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
        sb.AppendLine("Press 1: the program will print all the items on the refrigerator and all its contents");
        sb.AppendLine("Click 2: the program will print how much space is left in the fridge");
        sb.AppendLine("Press 3: The program will allow the user to put an item in the refrigerator.");
        sb.AppendLine("Press 4: The program will allow the user to remove an item from the refrigerator");
        sb.AppendLine("Press 5: the program will clean the refrigerator and print all the checked items to the user.");
        sb.AppendLine("Press 6: the program will ask the user What do I want to eat and bring the function to bring a product.");
        sb.AppendLine("Click 7: the program will print all the products sorted by their expiration date.");
        sb.AppendLine("Press 8: the program will print all the shelves arranged according to the free space left on them.");
        sb.AppendLine("Press 9: the program will print all the refrigerators arranged according to the free space left in them.");
        sb.AppendLine("Click 10: The program will prepare the refrigerator for shopping");
        sb.AppendLine("Press 100: system shutdown.");
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

        int choise = 0;

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
                    Console.WriteLine("please the enter item you want to remove");
                    Int32.TryParse(Console.ReadLine(), out int ItenId);
                    refrigerators[0].RemoveItemById(ItenId);
                    break;
                case 5:
                    Console.WriteLine(refrigerators[0].ThrowExpired()); 
                    break;
                case 6:
                    Console.WriteLine("what do you want to eat? enter 1 for food. 2 for drink");
                    Int32.TryParse(Console.ReadLine(), out int type);
                    Console.WriteLine("enter 1 for meat. 2 for dairy. 3for parve");
                    Int32.TryParse(Console.ReadLine(), out int kashrut);
                    refrigerators[0].Eat(type,kashrut);
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
                    refrigerators[0].GoShopping(); 
                    break;
                case 100:
                    Console.WriteLine("bye bye ");
                    break;
            }
        }


    }


}