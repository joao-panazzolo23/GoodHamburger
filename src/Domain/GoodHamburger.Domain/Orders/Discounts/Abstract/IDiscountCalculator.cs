using GoodHamburger.Domain.Orders.Entities;
using System.Data;

namespace GoodHamburger.Domain.Orders.Discounts.Abstract;

public interface IDiscountCalculator
{
    public decimal Calculate(IReadOnlyList<OrderItem> items);

}

public class DiscountCalculator(IEnumerable<IDiscountRule> rules) : IDiscountCalculator
{
    public decimal Calculate(IReadOnlyList<OrderItem> items)
            => rules
                .Where(r => r.IsApplicable(items))
                .Max(r => (decimal?)r.Percentage) ?? 0m;
}
