using GoodHamburger.Domain.Products.Enums;

namespace GoodHamburger.Domain.Products.Dtos;

public record ProductDto
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public ProductCategory Category { get; private set; }
}
