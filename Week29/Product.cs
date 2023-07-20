public class Product
{
    public string? Category { get; }
    public string? Name { get; }
    public int Price { get; }

    public Product(string? category, string? name, int price)
    {
        Category = category;
        Name = name;
        Price = price;
    }
}