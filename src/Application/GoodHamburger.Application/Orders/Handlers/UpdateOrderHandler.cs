using GoodHamburger.Application.Orders.Commands;
using GoodHamburger.Application.Result;
using GoodHamburger.Domain.Orders.Discounts.Abstract;
using GoodHamburger.Domain.Orders.Entities;
using GoodHamburger.Domain.Orders.Repositories;
using GoodHamburger.Domain.Products.Repositories;
using GoodHamburger.Domain.Shared.Data;
using GoodHamburger.Domain.Shared.Dto;
using Mediator;

namespace GoodHamburger.Application.Orders.Handlers;

public sealed class UpdateOrderHandler(
    IOrderRepository orderRepository,
    IProductRepository productRepository,
    IUnityOfWork unityOfWork,
    IDiscountCalculator discountCalculator
    ) : ICommandHandler<UpdateOrderCommand, Result<Unit>>
{
    public async ValueTask<Result<Unit>> Handle(
        UpdateOrderCommand command,
        CancellationToken cancellationToken
        )
    {
        var result = new DomainResult();

        var order = await orderRepository.Get(command.Id);

        if (order == null) return ResultFactory<Unit>.NotFound($"{nameof(order)} was not found!");

        var orderResult = order.Update(command.Name, command.PhoneNumber);

        result.Add(orderResult);

        order.ClearItems();

        foreach (var item in command.Items)
        {
            var product = await productRepository.GetById(item.ProductId);

            if (product is null) return ResultFactory<Unit>.BadRequest($"Product with Id {item.ProductId} was not found!");

            var orderItem = new OrderItem(
                    order.Id,
                    item.ProductId,
                    product.Category,
                    product.Price
                    );

            order.AddItem(orderItem);
        }

        order.ApplyDiscount(discountCalculator);

        await orderRepository.Update(order);

        await unityOfWork.Commit(cancellationToken);

        return ResultFactory<Unit>.Ok(message: $"{nameof(order)} updated successfully!");


    }
}
