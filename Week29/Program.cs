List<Purchase> purchases = new();

var newPurchase = new Purchase();

//Loop until quit
while (true)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Press A to add a new product, S to search or Q to quit");
    var key = Console.ReadKey(true).Key;
    
    //Add a new product
    if (key == ConsoleKey.A)
    {
        //Get and validate product values
        string? category;
        do
        {
            Console.WriteLine("Please enter a product category");
        } while (string.IsNullOrEmpty(category = Console.ReadLine()));

        string? name;
        do
        {
            Console.WriteLine("Please enter a product name");
        } while (string.IsNullOrEmpty(name = Console.ReadLine()));
    
        int price;
        do
        {
            Console.WriteLine("Please enter a product price using only numbers");
        } while (!int.TryParse(Console.ReadLine(), out price));
        
        //Add product to list
        var newProduct = new Product(category, name, price);
        newPurchase.Products.Add(newProduct);
        
        PrintAllProducts(newPurchase);
    }
    
    else if (key == ConsoleKey.S)
    {
        Console.WriteLine("Please enter a search query");
        
        string? query;
        while (string.IsNullOrEmpty(query = Console.ReadLine()))
        {
            Console.WriteLine("You did not enter a search query");
        }

        var result = newPurchase.Products.Find(product => string.Equals(product.Name, query, StringComparison.OrdinalIgnoreCase));
        if (result != null)
        {
            PrintAllProducts(newPurchase, query);
        }
        else
        {
            Console.WriteLine("Search result not found");
        }
    }
    
    else if(key == ConsoleKey.Q)
        break;
}

return;

//Print all added products in columns, with total cost at the at the bottom. Also highlights search result if used
void PrintAllProducts(Purchase purchase, string? searchQuery = null)
{
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    const string format = "{0,-20} {1,-10} {2,-20}";
    Console.WriteLine(format, "NAME", "PRICE", "CATEGORY");
    
    foreach (var product in purchase.OrderedProducts)
    {
        Console.ForegroundColor = product.Name == searchQuery ? ConsoleColor.Red : ConsoleColor.Cyan;
        Console.WriteLine(format, product.Name, product.Price, product.Category);
    }
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Total cost: " + purchase.TotalCost);
}