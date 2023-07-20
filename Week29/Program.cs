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
        Console.Clear();
        //Get and check category
        string? category;
        do
        {
            Console.WriteLine("Please enter a product category");
        } while (string.IsNullOrEmpty(category = Console.ReadLine()?.Trim()));
    
        Console.Clear();
        //Get and check name
        string? name;
        do
        {
            Console.WriteLine("Please enter a product name");
        } while (string.IsNullOrEmpty(name = Console.ReadLine()?.Trim()));
        
        Console.Clear();
        //Get and check price, it also needs to be positive
        double price;
        do
        {
            Console.WriteLine("Please enter a product price using only numbers above 0.1");
        } while (!double.TryParse(Console.ReadLine()?.Trim(), out price) || price < 0.1);
        
        //Add product to list
        var newProduct = new Product(category, name, price);
        newPurchase.Products.Add(newProduct);
        
        PrintAllProducts(newPurchase);
    }
    
    //Search for a specific product by name
    else if (key == ConsoleKey.S)
    {
        Console.Clear();
        Console.WriteLine("Please enter a search query");
        
        //Validate search query
        string? query;
        while (string.IsNullOrEmpty(query = Console.ReadLine()?.Trim()))
        {
            Console.Clear();
            Console.WriteLine("You did not enter a search query");
        }
        
        //Try to find product(s)
        var result = newPurchase.Products.Where(product => string.Equals(product.Name, query, StringComparison.OrdinalIgnoreCase)).ToList();
        if (result.Any())
        {
            Console.Clear();
            PrintAllProducts(newPurchase, result);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Search result not found");
        }
    }
    
    //
    else if(key == ConsoleKey.Q)
        break;
}

return;

//Print all added products in columns, with total cost at the at the bottom. Also highlights search result if used
void PrintAllProducts(Purchase purchase, List<Product>? queryResults = null)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    const string format = "{0,-20} {1,-10} {2,-20}";
    Console.WriteLine(format, "CATEGORY", "NAME", "PRICE");
    
    //Prints with a different color if the product matches the search query
    foreach (var product in purchase.OrderedProducts)
    {
        Console.ForegroundColor = queryResults != null && queryResults.Contains(product) ? ConsoleColor.Red : ConsoleColor.Cyan;
        Console.WriteLine(format, product.Category, product.Name, product.Price);
    }
    
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Total cost: " + purchase.TotalCost);
}