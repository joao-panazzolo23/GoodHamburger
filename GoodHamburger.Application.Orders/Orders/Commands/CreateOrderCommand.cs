using GoodHamburger.Application.Shared.Result;
using Mediator;

namespace GoodHamburger.Application.Orders.Commands;

public record CreateOrderCommand(
    Guid CustomerId,
    IList<CreateOrderItemCommand> Items
)
    : ICommand<Result<Unit>>;

public record CreateOrderItemCommand(
    Guid ProductId,
    int Quantity
) : ICommand<Result<Unit>>;