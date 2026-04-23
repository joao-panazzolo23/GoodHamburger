namespace GoodHamburger.Domain.Orders.Dtos;

public record OrderDto : IEquatable<OrderDto>
{
    public Guid Id { get; set; }
    public decimal Total { get; set; }
    public decimal Subtotal { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public IList<OrderItemDto> Items { get; set; }
}
