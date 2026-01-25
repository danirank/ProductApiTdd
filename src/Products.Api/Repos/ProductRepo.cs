using Entities;

namespace Repos;

public class ProductRepo
{
    public async Task<List<Product>> GetAllAsync()
    {
        return new List<Product>
        {
            new Product("Iphone", 14999),
            new Product("Lenovo", 17999)
        };
    }
}