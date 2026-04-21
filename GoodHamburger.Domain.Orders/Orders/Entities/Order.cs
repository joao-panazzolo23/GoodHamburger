using GoodHamburger.Domain.Order.Orders.Discounts.Abstract;
using GoodHamburger.Domain.Shared.Dto;
using GoodHamburger.Domain.Shared.Entities;

namespace GoodHamburger.Domain.Order.Orders.Entities;

public class Order : Entity
{
    public string Name { get; private set; }
    public decimal Value { get; private set; }
    public Guid CustomerId { get; private set; }
    private List<OrderItem> _items { get; set; } = new();
    public IReadOnlyCollection<OrderItem>? Items { get; private set; }
    public decimal Total { get; private set; }


    public DomainResult ApplyDiscount(IDiscountCalculator calculator)
    {
        this.Total = calculator.Calculate(this._items);

        return new DomainResult(CausesError.None);
    }

    public DomainError AddItem(OrderItem item)
    {
        if (_items.Any(i => i.Category == item.Category))
            return CausesError.DuplicateItem;

            _items.Add(item);
        return CausesError.None;
    }

    private Order()
    {

    }


    public static Order Create()
    {
        return new Order();
    }
}


//Order: 
//CustomerId
//list<items>
//