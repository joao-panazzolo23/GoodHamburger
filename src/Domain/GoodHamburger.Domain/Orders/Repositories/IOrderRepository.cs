
using GoodHamburger.Domain.Orders.Entities;

namespace GoodHamburger.Domain.Orders.Repositories;
public interface IOrderRepository
{
    public Task<Order?> Get(Guid id);
    public Task Update(Order order);
    public Task Delete(Order order);
    public Task Create(Order order);
}