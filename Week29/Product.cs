//Class for creating a single product with category, name and price
public class Product
{
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