using GoodHamburger.Application.Orders.Commands;
using GoodHamburger.Application.Result;
using GoodHamburger.Application.Shared.Result;
using GoodHamburger.Domain.Order.Orders.Entities;
using GoodHamburger.Domain.Order.Orders.Repositories;
using GoodHamburger.Domain.Order.Products.Repositories;
using GoodHamburger.Domain.Shared.Data;
using GoodHamburger.Domain.Shared.Dto;
using Mediator;

namespace GoodHamburger.Application.Orders.Handlers;

public sealed class CreateOrderHandler(
    IOrderRepository repository,
    IUnityOfWork unitOfWork, 
    IProductRepository productRepository
) : ICommandHandler<CreateOrderCommand, Result<Unit>>
{
    public async ValueTask<Result<Unit>> Handle(
        CreateOrderCommand command,
        CancellationToken cancellationToken
    )
    {
        var result = new DomainResult();

        var order = Order.Create();

        foreach (var item in command.Items)
        {
            var product = await productRepository.GetById(item.ProductId);

            if (product is null) return ResultFactory<Unit>.NotFound(message: "Product was not found");

            var orderItem = new OrderItem(
                order.Id,
                product.Id, 
                product.Price
            );

            order.AddItem(orderItem);
        }

        if (result.HasError) return ResultFactory<Unit>.BadRequest();

        await repository.Create(order);
        await unitOfWork.Commit(cancellationToken);

        return ResultFactory<Unit>.Ok();
    }
}