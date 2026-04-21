using GoodHamburger.Domain.Order.Products.Enums;
using GoodHamburger.Domain.Shared.Entities;

namespace GoodHamburger.Domain.Order.Products.Entities;

public class Product : Entity
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public ProductCategory ProductCategory { get; private set; }
}