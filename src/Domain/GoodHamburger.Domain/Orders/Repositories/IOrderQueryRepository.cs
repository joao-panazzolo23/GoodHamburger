using GoodHamburger.Domain.Orders.Dtos;

namespace GoodHamburger.Domain.Orders.Repositories;

public interface IOrderQueryRepository
{
    Task<IEnumerable<OrderDto>> List();
    Task<OrderDto?> Get(Guid id);
}
