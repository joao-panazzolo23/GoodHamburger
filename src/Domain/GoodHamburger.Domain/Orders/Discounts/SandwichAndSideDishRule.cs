using GoodHamburger.Domain.Order.Orders.Discounts.Abstract;
using GoodHamburger.Domain.Order.Orders.Entities;
using GoodHamburger.Domain.Order.Products.Enums;

namespace GoodHamburger.Domain.Order.Orders.Discounts;

public class SandwichAndSideDishRule : IDiscountRule
{
    public decimal Percentage => 0.15m;

    public bool IsApplicable(IReadOnlyList<OrderItem> items)
        => items.Any(i => i.Category == ProductCategory.Sandwich)
        && items.Any(i => i.Category == ProductCategory.Beverage);
}




