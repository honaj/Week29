//Class for creating a single product with category, name and price
public class Product
{
    //All variables are read-only after initialization
    public string? Category { get; }
    public string? Name { get; }
    public double Price { get; }

    public Product(string? category, string? name, double price)
    {
        Category = category;
        Name = name;
        Price = price;
    }
}