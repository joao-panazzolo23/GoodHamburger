using GoodHamburger.Application.Orders.Commands;
using GoodHamburger.Application.Result;
using GoodHamburger.Domain.Order.Orders.Entities;
using GoodHamburger.Domain.Orders.Discounts.Abstract;
using GoodHamburger.Domain.Orders.Repositories;
using GoodHamburger.Domain.Products.Repositories;
using GoodHamburger.Domain.Shared.Data;
using GoodHamburger.Domain.Shared.Dto;
using Mediator;

namespace GoodHamburger.Application.Orders.Handlers;

public sealed class CreateOrderHandler(
    IOrderRepository repository,
    IUnityOfWork unitOfWork,
    IProductRepository productRepository, 
    IDiscountCalculator calculator
) : ICommandHandler<CreateOrderCommand, Result<Unit>>
{
    public async ValueTask<Result<Unit>> Handle(
        CreateOrderCommand command,
        CancellationToken cancellationToken
    )
    {
        var result = new DomainResult();

        var order = new Order(command.Name, command.PhoneNumber);

        foreach (var item in command.Items)
        {
            var product = await productRepository.GetById(item.ProductId);

            if (product is null) return ResultFactory<Unit>.NotFound(message: $"Product {item.ProductId} was not found!");

            var orderItem = new OrderItem(
                order.Id,
                product.Id,
                product.Price
            );

            var orderResult = order.AddItem(orderItem);

            result.Add(orderResult);
        }

        if (result.HasError)
            return ResultFactory<Unit>.BadRequest(message: "Unable to create an Order", errors: result.Errors);

        order.ApplyDiscount(calculator);

        await repository.Create(order);
        await unitOfWork.Commit(cancellationToken);

        return ResultFactory<Unit>.Ok();
    }
}