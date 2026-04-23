namespace GoodHamburger.Domain.Orders.Repositories;

using Entities;

public interface IOrderRepository
{
    public Task<IEnumerable<Order>> List(int page, int pageSize);
    public Task<Order?> Get(Guid id);
    public Task Update(Order order);
    public Task Delete(Order order);
    public Task Create(Order order);
}