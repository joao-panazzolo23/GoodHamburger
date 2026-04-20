using GoodHamburger.Domain.Shared.Entities;

namespace GoodHamburger.Application.Products.Entities;

public class Product : Entity
{
    public string Name { get; set; }
    public string Price { get; set; }
}