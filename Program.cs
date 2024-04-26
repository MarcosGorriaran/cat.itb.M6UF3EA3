using cat.itb.M6UF3EA2.helpers;
using cat.itb.M6UF3EA3.helpers;

namespace cat.itb.M6UF3EA3;

public class Driver
{
    public static void Main()
    {
        const string MenuTitle = "Select one of the activities";
        const string AskValue = "Provide me with the option index: ";
        const string SplitText = ". ";
        const string ExitText = "Exit";
        const string ExitOption = "0";
        Menu mainMenu = new Menu(MenuTitle, new Dictionary<string, string>()
        {
            {"1","Import colections"},
            {"2","Drop collection"},
            {"3A","Show book ISBN"},
            {"3B","Show ordered books"},
            {"3C","Show Danno Ferrin books"},
            {"3D","Show specific Java books"},
            {"3E", "Show Books from Charlie or Robi"},
            {"3F", "Show Java books without Vikram"},
            {"3G", "Show cheapest product"},
            {"3H", "Show stock sum"},
            {ExitOption,ExitText}
        }, AskValue);
        string option;

        do
        {
            Console.Write(mainMenu.ToString(SplitText));
            option = Console.ReadLine();

            switch (option.Trim().ToUpper())
            {
                case "1":
                    EA3CRUD.ACT1InsertFiles();
                    break;
                case "2":
                    Console.Write("Target database: ");
                    string database = Console.ReadLine();
                    Console.Write("Target collection: ");
                    string colection = Console.ReadLine();

                    Console.WriteLine(EA3CRUD.dropCollection(database, colection));
                    break;
                case "3A":
                    Console.WriteLine(EA3CRUD.ACT3AShowBookISBN());
                    break;
                case "3B":
                    Console.WriteLine(EA3CRUD.ACT3BGetOrderedList());
                    break;
                case "3C":
                    Console.WriteLine(EA3CRUD.ACT3CShowDannoBooks("Danno Ferrin"));
                    break;
                case "3E":
                    Console.WriteLine(EA3CRUD.ACT3EShowBooks("Charlie Collins", "Robio Sen"));
                    break;
                case "3F":
                    Console.WriteLine(EA3CRUD.ACT3FDiscardBooks("Java","'Vikram Goyal'"));
                    break;
                case "3G":
                    Console.WriteLine(EA3CRUD.ACT3GFindLowestPriceProduct());
                    break;
                case "3H":
                    Console.WriteLine(EA3CRUD.ACT3HFindSumStocks());
                    break;
            }
        } while (option != ExitOption);
    }
}