using GoodHamburger.Application.Orders.Dtos;
using GoodHamburger.Application.Result;
using Mediator;

namespace GoodHamburger.Application.Orders.Commands;

public class GetOrderByIdQuery : IQuery<Result<OrderDto>>
{
    public Guid Id { get; set; }
}
