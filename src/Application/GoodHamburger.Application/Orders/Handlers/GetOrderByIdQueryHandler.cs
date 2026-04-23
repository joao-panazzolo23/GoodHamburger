using GoodHamburger.Application.Orders.Commands;
using GoodHamburger.Application.Result;
using GoodHamburger.Domain.Orders.Dtos;
using GoodHamburger.Domain.Orders.Repositories;
using Mediator;

namespace GoodHamburger.Application.Orders.Handlers;

public sealed class GetOrderByIdQueryHandler
    (
    IOrderQueryRepository orderRepository
    ) : IQueryHandler<GetOrderByIdQuery, Result<OrderDto?>>
{
    public async ValueTask<Result<OrderDto>> Handle(
        GetOrderByIdQuery query, 
        CancellationToken cancellationToken
        )
    {
        var order = await orderRepository.Get(query.Id);
        if (order is null) return ResultFactory<OrderDto>.NotFound("Order was not found!");

        return ResultFactory<OrderDto>.Ok(order);
    }
}
