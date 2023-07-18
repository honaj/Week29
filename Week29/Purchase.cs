public class Purchase
{
    public string Name;
    public List<Product> Products;
    public int TotalCost => Products.Sum(product => product.price);

    public Purchase(string name, List<Product> products)
    {
        Name = name;
        Products = products;
    }
}