using GoodHamburger.Application.Orders.Commands;
using GoodHamburger.Application.Result;
using GoodHamburger.Domain.Orders.Dtos;
using GoodHamburger.Domain.Orders.Repositories;
using Mediator;

namespace GoodHamburger.Application.Orders.Handlers;

public sealed class GetOrdersByNameHandler
    (
    IOrderQueryRepository orderRepository
    ): IQueryHandler<ListOrdersQuery, Result<IEnumerable<OrderDto>>>
{
    public async ValueTask<Result<IEnumerable<OrderDto>>> Handle(ListOrdersQuery query, CancellationToken cancellationToken)
    {
        var result = await orderRepository.List();
        return ResultFactory<IEnumerable<OrderDto>>.Ok(result);
    }
}
