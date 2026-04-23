using GoodHamburger.Application.Result;
using Mediator;

namespace GoodHamburger.Application.Orders.Commands;

public record CreateOrderCommand(
    string Name,
    string PhoneNumber,
    string Email,
    IList<CreateOrderItemCommand> Items
)
    : ICommand<Result<Unit>>;
