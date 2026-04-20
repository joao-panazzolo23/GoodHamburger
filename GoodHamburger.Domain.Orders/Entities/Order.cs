using GoodHamburger.Domain.Shared.Entities;

namespace GoodHamburger.Domain.Order.Entities;

public class Order : Entity
{
    public string Name { get; private set; }
    public decimal Value { get; private set; }
    public Guid CustomerId { get; private set; }
    private List<OrderItem> _items { get; set; } = new();
    public IReadOnlyCollection<OrderItem>? Items { get; private set; }

    public Order AddItem(OrderItem item)
    {
        _items.Add(item);
        return this;
    }

    //ef core
    public Order()
    {
        
    }
    
    private Order(Guid customerId)
    {
        CustomerId = customerId;
    }

    public static Order Create(Guid customerId)
    {
        return new Order(customerId);
    }
}


//Order: 
//CustomerId
//list<items>
//