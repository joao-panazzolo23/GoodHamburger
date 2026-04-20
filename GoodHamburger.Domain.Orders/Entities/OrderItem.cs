using GoodHamburger.Domain.Shared.Entities;

namespace GoodHamburger.Domain.Order.Entities;

public class OrderItem : Entity
{
    //ef
    private OrderItem()
    {
    }

    public OrderItem(
        Guid orderId, 
        Guid productId,
        int quantity
    )
    {
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
        
    }

    private static OrderItem Create()
    {
        return new OrderItem();
    }

    public Guid OrderId { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
}