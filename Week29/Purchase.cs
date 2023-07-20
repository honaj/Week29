//Class for storing a purchase of multiple products
public class Purchase
{
    public readonly List<Product> Products = new();
    
    //Total cost of all products
    public double TotalCost => Products.Sum(product => product.Price);
    
    //Products ordered by price
    public IEnumerable<Product> OrderedProducts => Products.OrderBy(product => product.Price);
}