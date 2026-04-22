using GoodHamburger.Domain.Order.Orders.Discounts.Abstract;
using GoodHamburger.Domain.Shared.Dto;
using GoodHamburger.Domain.Shared.Entities;

namespace GoodHamburger.Domain.Order.Orders.Entities;

public class Order : Entity
{
    public string Name { get; private set; }
    public string PhoneNumber { get; private set; }
    private List<OrderItem> _items { get; set; } = new();
    public IReadOnlyCollection<OrderItem>? Items { get; private set; }
    public decimal Total { get; private set; }


    public DomainError ApplyDiscount(IDiscountCalculator calculator)
    {
        this.Total = calculator.Calculate(this._items);

        return CausesError.None;
    }

    public DomainError AddItem(OrderItem item)
    {
        if (_items.Any(i => i.Category == item.Category))
            return CausesError.DuplicateItem;

        _items.Add(item);
        return CausesError.None;
    }

    //ef
    private Order() { }
    public Order(string name, string phone)
    {
        this.Name = name;
        this.PhoneNumber = phone;
    }
}


//Order: 
//CustomerId
//list<items>
//