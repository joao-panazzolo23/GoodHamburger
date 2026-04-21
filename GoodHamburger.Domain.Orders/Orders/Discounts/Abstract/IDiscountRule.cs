using GoodHamburger.Domain.Order.Orders.Entities;

namespace GoodHamburger.Domain.Order.Orders.Discounts.Abstract;

public interface IDiscountRule
{
    public decimal Percentage { get; }
    public bool IsApplicable(IReadOnlyList<OrderItem> items);
}
