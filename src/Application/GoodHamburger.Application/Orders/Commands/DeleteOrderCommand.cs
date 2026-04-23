using GoodHamburger.Application.Result;
using Mediator;

namespace GoodHamburger.Application.Orders.Commands;

public record DeleteOrderCommand(Guid Id) : ICommand<Result<Unit>>;
