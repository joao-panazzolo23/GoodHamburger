using GoodHamburger.Domain.Order.Products.Enums;
using GoodHamburger.Domain.Shared.Entities;

namespace GoodHamburger.Domain.Order.Products.Entities;

public class Product : Entity
{
    public Product(string name, decimal price, ProductCategory productCategory)
    {
        Name = name;
        Price = price;
        ProductCategory = productCategory;
    }

    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public ProductCategory ProductCategory { get; private set; }
}