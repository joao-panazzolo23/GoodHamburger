
using FluentAssertions;
using GoodHamburger.Domain.Orders.Discounts;
using GoodHamburger.Domain.Orders.Discounts.Abstract;
using GoodHamburger.Domain.Orders.Entities;
using GoodHamburger.Domain.Products.Enums;

namespace GoodHamburger.Domain.UnitTests;

public class OrderTest
{

    private readonly IDiscountCalculator _calculator;
    public OrderTest()
    {
        _calculator = new DiscountCalculator([
            new ComboDiscountRule(),
            new SandwichAndBeverageRule(),
            new SandwichAndPotatoRule()
        ]);

    }

    private void AssertDiscountCalculation(Order order, decimal expectedDiscount)
    {
        var total = order.Items!.Sum(i => i.Price);

        var discount = _calculator.Calculate([.. order.Items!]);

        order.ApplyDiscount(_calculator);

        order.Total.Should().Be(total * (1 - discount));

        discount.Should().Be(expectedDiscount   );
    }

    private Order BuildTestOrder(List<OrderItem> items)
    {
        var order = new Order("teste", "teste");

        items.ForEach(x => order.AddItem(x));

        return order;
    }

    private static decimal RandomDecimal()
    {
        var faker = new Bogus.Faker();
        return faker.Random.Decimal(1m, 100m);
    }


    [Fact]
    public void FullCombo_ShouldApply_20PercentDiscount()
    {

        var order = BuildTestOrder(
            [
            new(Guid.NewGuid(), Guid.NewGuid(), ProductCategory.Sandwich, RandomDecimal()),
            new(Guid.NewGuid(), Guid.NewGuid(), ProductCategory.FrenchFries, RandomDecimal()),
            new(Guid.NewGuid(), Guid.NewGuid(), ProductCategory.Beverage, RandomDecimal())
            ]
            );

        AssertDiscountCalculation(order, 0.20m);
    }

    [Fact]
    public void SandwichAndBeverage_ShouldApply_15PercentDiscount()
    {
        var order = BuildTestOrder(
            [
            new(Guid.NewGuid(), Guid.NewGuid(), ProductCategory.Sandwich, RandomDecimal()),
            new(Guid.NewGuid(), Guid.NewGuid(), ProductCategory.Beverage, RandomDecimal())
            ]
            );

        AssertDiscountCalculation(order, 0.15m  );
    }

    [Fact]
    public void SandwichAndFries_ShouldApply_10PercentDiscount()
    {
        var order = BuildTestOrder(
            [
            new(Guid.NewGuid(), Guid.NewGuid(), ProductCategory.Sandwich, RandomDecimal()),
            new(Guid.NewGuid(), Guid.NewGuid(), ProductCategory.FrenchFries, RandomDecimal())
            ]
            );

        AssertDiscountCalculation(order, 0.1m);
    }

    [Fact]
    public void NoCombo_ShouldApply_NoDiscount()
    {
        var order = BuildTestOrder(
            [
            new(Guid.NewGuid(), Guid.NewGuid(), ProductCategory.Sandwich, RandomDecimal())
            ]
            );

        AssertDiscountCalculation(order, 0m);
    }

}
