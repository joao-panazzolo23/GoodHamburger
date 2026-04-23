using GoodHamburger.Application.Result;
using GoodHamburger.Domain.Orders.Dtos;
using Mediator;

namespace GoodHamburger.Application.Orders.Commands;

public record ListOrdersQuery() : IQuery<Result<IEnumerable<OrderDto>>>;