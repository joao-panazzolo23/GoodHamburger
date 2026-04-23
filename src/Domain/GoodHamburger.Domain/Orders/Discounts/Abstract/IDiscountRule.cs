using GoodHamburger.Domain.Orders.Entities;

namespace GoodHamburger.Domain.Orders.Discounts.Abstract;

public interface IDiscountRule
{
    public decimal Percentage { get; }
    public bool IsApplicable(IReadOnlyList<OrderItem> items);
}
