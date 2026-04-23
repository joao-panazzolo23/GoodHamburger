using GoodHamburger.Domain.Products.Enums;

namespace GoodHamburger.Domain.Orders.Dtos;

public record OrderItemDto
{
    public string ProductName { get; set; }
    public ProductCategory ProductCategory { get; set; }
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public decimal Price { get; set; }
}
