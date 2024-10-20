namespace MainApp.Menus;

public class Menu
{
    private readonly ProductMenu _productMenu = new ProductMenu();

    public void MainMenu()
    {
        Console.BackgroundColor = ConsoleColor.Gray;
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Clear();
        Console.WriteLine("CREATE YOUR OWN BOOK \n");
        Console.WriteLine("*******************************\n");
        Console.WriteLine("Main Menu");
        Console.WriteLine("1. Create A Book");
        Console.WriteLine("2. View All Books");
        Console.WriteLine("3. View Single Book");
        Console.WriteLine("4. Delete Book");
        Console.Write("\nEnter your choice:\n ");
        Console.WriteLine("\n*******************************");

        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                _productMenu.CreateMenu();
                break;

            case "2":
                _productMenu.ViewAllMenu();
                break;

            case "3":
                break;

            default:
                Console.WriteLine("\nIncorrect choice, please try again.");
                Console.ReadKey();
                break;
        }

    }
}
