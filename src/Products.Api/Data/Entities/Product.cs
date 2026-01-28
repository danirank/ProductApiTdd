using System.ComponentModel.DataAnnotations;

namespace Entities;

public class Product
{
    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    [Key]
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }



}