public class Product
{
    public string Name { get; }
    public int Price { get; }
    public string Category { get; }

    public Product(string name, int price, string category)
    {
        Name = name;
        Price = price;
        Category = category;
    }
}