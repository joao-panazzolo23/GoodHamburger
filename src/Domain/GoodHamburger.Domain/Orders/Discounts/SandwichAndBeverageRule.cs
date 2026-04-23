using GoodHamburger.Domain.Orders.Discounts.Abstract;
using GoodHamburger.Domain.Orders.Entities;
using GoodHamburger.Domain.Products.Enums;

namespace GoodHamburger.Domain.Orders.Discounts;

public class SandwichAndBeverageRule : IDiscountRule
{
    public decimal Percentage => 0.15m;

    public bool IsApplicable(IReadOnlyList<OrderItem> items)
        => items.Any(i => i.Category == ProductCategory.Sandwich)
        && items.Any(i => i.Category == ProductCategory.Beverage);
}




