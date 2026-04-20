using GoodHamburger.Domain.Shared.Entities;

namespace GoodHamburger.Domain.Products.Entities;

public class Product : Entity
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
}