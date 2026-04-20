using GoodHamburger.Application.Orders.Commands;
using GoodHamburger.Application.Shared.Result;
using GoodHamburger.Domain.Order.Entities;
using GoodHamburger.Domain.Order.Repositories;
using GoodHamburger.Domain.Shared.Data;
using Mediator;

namespace GoodHamburger.Application.Orders.Handlers;

internal sealed class CreateOrderHandler(
    IOrderRepository repository,
    IUnityOfWork unitOfWork
) : ICommandHandler<CreateOrderCommand, Result<Unit>>
{
    public async ValueTask<Result<Unit>> Handle(
        CreateOrderCommand command,
        CancellationToken cancellationToken
    )
    {
        var order = Order.Create(command.CustomerId);

        foreach (var item in command.Items)
        {
            var orderItem = new OrderItem(
                order.Id,
                item.ProductId,
                item.Quantity
            );

            order.AddItem(orderItem);
        }

        await repository.Create(order);
        await unitOfWork.Commit(cancellationToken);

        return ResultFactory<Unit>.Ok();
    }
}