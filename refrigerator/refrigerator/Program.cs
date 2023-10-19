


using refrigerator;

public class Program
{

    public  List<Refrigerator> sortByPlace(List<Refrigerator> refrigerators)
    {
        List<Refrigerator> sortedByPlace = new List<Refrigerator>();
        sortedByPlace= refrigerators.OrderByDescending(refrigerator => refrigerator.placeLeftInRefrigerator()).ToList();
        return sortedByPlace;

    }





    static void Main(string[] args)
    {

    }
}