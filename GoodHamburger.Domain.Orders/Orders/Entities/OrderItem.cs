using GoodHamburger.Domain.Order.Products.Enums;
using GoodHamburger.Domain.Shared.Entities;

namespace GoodHamburger.Domain.Order.Orders.Entities;

public class OrderItem : Entity
{
    public Guid OrderId { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public ProductCategory Category { get; internal set; }


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
    }

    private static OrderItem Create()
    {
        return new OrderItem();
    }

    private void ApplyDiscount()
    {

    }


}