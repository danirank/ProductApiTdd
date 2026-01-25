namespace Entities;

public class Product
{
    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }



}