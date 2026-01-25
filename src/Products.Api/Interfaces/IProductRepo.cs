using Entities;

namespace Interfaces;

public interface IProductRepo
{
    Task<List<Product>> GetAllAsync();
}