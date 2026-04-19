namespace GoodHamburger.Domain.Order.Repositories;

using Entities;

public interface IOrderRepository
{
    public IEnumerable<Order> List();
    public Order Get(Guid id);
    public Task Update(Order order);
    public Task Delete(Order order);
    public Task Create(Order order);
}