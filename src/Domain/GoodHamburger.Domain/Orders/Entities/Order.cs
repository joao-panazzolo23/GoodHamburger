using GoodHamburger.Domain.Orders.Discounts.Abstract;
using GoodHamburger.Domain.Shared.Dto;
using GoodHamburger.Domain.Shared.Entities;

namespace GoodHamburger.Domain.Orders.Entities;

public class Order : Entity
{
    public string Name { get; private set; }
    public string PhoneNumber { get; private set; }
    private List<OrderItem> _items { get; set; } = [];
    public IReadOnlyCollection<OrderItem>? Items => _items;
    public decimal Total { get; private set; }
    public decimal Subtotal { get; private set; }


    public DomainError ApplyDiscount(IDiscountCalculator calculator)
    {
        var discountPercentage = calculator.Calculate(this._items);

        this.Total = this._items.Sum(i => i.Price) * (1 - discountPercentage);

        return CausesError.None;
    }

    public DomainError AddItem(OrderItem item)
    {
        if (_items.Any(i => i.Category == item.Category))
            return CausesError.DuplicateItem;

        _items.Add(item);
        this.Subtotal = _items.Sum(i => i.Price);

        return CausesError.None;
    }

    //ef
    private Order() { }
    public Order(string name, string phone)
    {
        this.Name = name;
        this.PhoneNumber = phone;
    }

    public Order Update(
        string name,
        string phone
        )
    {
        this.Name = name;
        this.PhoneNumber = phone;
        return this;
    }

    public void ClearItems()
    {
        this._items.Clear();
    }
}

