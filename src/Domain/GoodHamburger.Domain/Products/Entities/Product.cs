using GoodHamburger.Domain.Products.Enums;
using GoodHamburger.Domain.Shared.Entities;

namespace GoodHamburger.Domain.Products.Entities;

public class Product : Entity
{
    public Product(string name, decimal price, ProductCategory productCategory)
    {
        Name = name;
        Price = price;
        Category = productCategory;
    }

    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public ProductCategory Category { get; private set; }
}