using GoodHamburger.Application.Result;
using Mediator;

namespace GoodHamburger.Application.Orders.Commands;

public record CreateOrderItemCommand(
    Guid ProductId
) : ICommand<Result<Unit>>;