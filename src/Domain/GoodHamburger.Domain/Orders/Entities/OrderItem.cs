using GoodHamburger.Domain.Products.Entities;
using GoodHamburger.Domain.Products.Enums;
using GoodHamburger.Domain.Shared.Entities;

namespace GoodHamburger.Domain.Orders.Entities;

public class OrderItem : Entity
{
    public OrderItem(
        Guid orderId, 
        Guid productId, 
        ProductCategory category, 
        decimal price
        )
    {
        OrderId = orderId;
        ProductId = productId;
        Category = category;
        Price = price;
    }

    //ef
    private OrderItem()
    {
    }

    public Guid OrderId { get; private set; }
    public Order Order { get; private set; }
    public Guid ProductId { get; private set; }
    public ProductCategory Category { get; private set; }
    public decimal Price { get; private set; }
    public Product Product { get; private set; }


}