using Week29;

//Set a minimum price for products
var minPrice = 0.1;

//Create a new Purchase object
var newPurchase = new Purchase();

//Loop until quit
while (true)
{
    //Let the user choose to add a product, search for an added product or quit
    DisplayMenu();
    var keyPressed = Console.ReadKey(true).Key;
    switch (keyPressed)
    {
        case ConsoleKey.A:
            AddProduct(newPurchase);
            break;
        case ConsoleKey.S:
            SearchProduct(newPurchase);
            break;
        case ConsoleKey.Q:
            Environment.Exit(0);
            break;
        default:
            ClearAndPrintLine("Invalid key");
            continue;
    }
}

//Function to display main menu
void DisplayMenu()
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Press A to add a new product, S to search or Q to quit");
}

//Add a new product
void AddProduct(Purchase purchase)
{
    //Prompt for and validate category, name, and price
    var category = GetUserStringInput("Please enter a product category");
    var name = GetUserStringInput("Please enter a product name");
    var price = GetProductPrice();

    //Add new product to purchase
    var newProduct = new Product(category, name, price);
    purchase.Products.Add(newProduct);

    //Display all products after adding a new one
    PrintAllProducts(purchase);
}

//Get and validate price input
double GetProductPrice()
{
    double price;
    do
    {
        ClearAndPrintLine("Please enter a product price using only numbers above " + minPrice);
    } while (!double.TryParse(Console.ReadLine()?.Trim(), out price) || price < minPrice);
    
    return price;
}

//Search for a product by name in the current purchase
void SearchProduct(Purchase purchase)
{
    //Validate search term
    var query = GetUserStringInput("Please enter a search query");

    //Search for and display the product(s) that matches the query
    var foundProducts = purchase.Products.Where(product => string.Equals(product.Name, query, StringComparison.CurrentCultureIgnoreCase)).ToList();

    if(foundProducts.Count > 0)
    {
        PrintAllProducts(purchase, foundProducts );
    }
    else
    {
        ClearAndPrintLine("Search result not found");
    }
}

//Print all products in a purchase
void PrintAllProducts(Purchase purchase, List<Product>? productResults = null)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    //Format the output to get nice columns
    const string format = "{0,-20} {1,-10} {2,-20}";
    Console.WriteLine(format, "CATEGORY", "NAME", "PRICE");

    //Print each product in the purchase, highlighting specific product(s) if relevant
    foreach (var product in purchase.OrderedProducts)
    {
        Console.ForegroundColor = productResults != null && productResults.Contains(product) 
            ? ConsoleColor.Red 
            : ConsoleColor.Cyan;
        Console.WriteLine(format, product.Category, product.Name, product.Price);
    }

    //Display total cost of the purchase
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Total cost: " + purchase.TotalCost);
}

//Repeat a message until user input is valid (non-empty and not a number)
string GetUserStringInput(string prompt)
{
    string? input;
    do
    {
        ClearAndPrintLine(prompt);
        input = Console.ReadLine()?.Trim();
    } while (string.IsNullOrEmpty(input) || double.TryParse(input, out _));
    return input;
}

//Clear console and print a specific prompt
void ClearAndPrintLine(string prompt)
{   
    Console.Clear();
    Console.WriteLine(prompt);
}