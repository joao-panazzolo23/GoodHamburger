using GoodHamburger.Domain.Order.Products.Entities;
using GoodHamburger.Domain.Order.Products.Enums;
using GoodHamburger.Domain.Shared.Entities;

namespace GoodHamburger.Domain.Order.Orders.Entities;

public class OrderItem : Entity
{
    public Guid OrderId { get; private set; }
    public Order Order { get; private set; }
    public Guid ProductId { get; private set; }
    public ProductCategory Category { get; internal set; }
    public decimal Price { get; private set; }
    public Product Product { get; private set; }


    //ef
    private OrderItem()
    {
    }

    public OrderItem(
        Guid orderId,
        Guid productId,
        decimal price
    )
    {
        OrderId = orderId;
        ProductId = productId;
        Price = price;
    }

    private static OrderItem Create(Guid orderId,
        Guid productId,
        decimal price)
    {
        return new OrderItem(orderId, productId, price);
    }


}