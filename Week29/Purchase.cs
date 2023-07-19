public class Purchase
{
    public readonly List<Product> Products = new();
    public int TotalCost => Products.Sum(product => product.Price);
    public IEnumerable<Product> OrderedProducts => Products.OrderBy(product => product.Price);
}