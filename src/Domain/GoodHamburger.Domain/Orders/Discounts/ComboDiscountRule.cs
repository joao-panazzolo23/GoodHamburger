using GoodHamburger.Domain.Order.Orders.Discounts.Abstract;
using GoodHamburger.Domain.Order.Orders.Entities;
using GoodHamburger.Domain.Order.Products.Enums;

namespace GoodHamburger.Domain.Order.Orders.Discounts;

public class ComboDiscountRule : IDiscountRule
{
    public decimal Percentage => 0.20m;

    public bool IsApplicable(IReadOnlyList<OrderItem> items)
        => items.Any(i => i.Category == ProductCategory.Sandwich)
        && items.Any(i => i.Category == ProductCategory.FrenchFries)
        && items.Any(i => i.Category == ProductCategory.Beverage);
}




