List<Purchase> purchases = new();

var newPurchase = new Purchase();

while (true)
{
    Console.WriteLine("Press A to add a new product, press Q to quit");
    var key = Console.ReadKey().Key;
    
    if (key == ConsoleKey.A)
    {
        string category;
        do
        {
            Console.WriteLine("Please enter a product category");
        } while (string.IsNullOrEmpty(category = Console.ReadLine()));

        string name;
        do
        {
            Console.WriteLine("Please enter a product name");
        } while (string.IsNullOrEmpty(name = Console.ReadLine()));
    
        int price;
        do
        {
            Console.WriteLine("Please enter a product price using only numbers");
        } while (!int.TryParse(Console.ReadLine(), out price));
    
        newPurchase.Products.Add(new Product(name, price, category));
        Console.WriteLine("total cost:" + newPurchase.TotalCost);
    }
    else if(key == ConsoleKey.Q)
        break;
}