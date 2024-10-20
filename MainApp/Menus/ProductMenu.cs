using Resources.Enums;
using Resources.Models;
using Resources.Services;

namespace MainApp.Menus;

public class ProductMenu
{
    private readonly ProductService _productService = new ProductService();
    public void CreateMenu()
    {
        Product product = new Product();

        Console.Clear();

        Console.Write("Enter The Title Of The Book: ");
        product.Title = Console.ReadLine() ?? "";

        Console.Write("Enter Books Genre: ");
        product.Genre = Console.ReadLine() ?? "";

        Console.Write("Enter Books Price: ");
        product.Price = Console.ReadLine() ?? "";

        var result = _productService.AddToList(product);
        
        switch(result)
        {
            case ResultStatus.Success:
                Console.WriteLine("\nYour book was created successfully.");
                break;
            case ResultStatus.Exists:
                Console.WriteLine("\nA book with this name already exists.");
                break;
            case ResultStatus.Failed:
                Console.WriteLine("\nSomething went wrong while creating the product.");
                break;
            case ResultStatus.SuccessWithErrors:
                Console.WriteLine("\nProduct was created successfully. But product list was not saved. ");
                break;
        }

        Console.WriteLine("Press any key to continue. ");
        Console.ReadKey();
    }
    public void ViewAllMenu()
    {
        var productList = _productService.GetAllProducts();

        Console.Clear();
        Console.WriteLine("View All Books\n");
         
        if (productList.Any())
        {
            foreach (Product product in productList)
            {
                Console.WriteLine($"{product.Title}\n{product.Genre}\n{product.Id}");
                Console.WriteLine($"Price: {product.Price}\n");
            }
        }
        else
        {
            Console.WriteLine("No books in list.\n");
        }

        Console.WriteLine("\nPress any key to continue. ");
        Console.ReadKey();
    }
}
