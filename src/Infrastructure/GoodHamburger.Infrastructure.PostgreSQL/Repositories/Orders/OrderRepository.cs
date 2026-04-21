using GoodHamburger.Domain.Order.Orders.Entities;
using GoodHamburger.Domain.Order.Orders.Repositories;
using GoodHamburger.Infrastructure.PostgreSQL.DbContext;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburger.Infrastructure.PostgreSQL.Repositories.Orders;

public class OrderRepository(AppDbContext context) : IOrderRepository
{
    public async Task<IEnumerable<Order>> List(int page, int pageSize)
    {
        return await context.Orders
            .OrderBy(p => p.Id) 
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<Order?> Get(Guid id)
    {
        return await context.Orders.SingleOrDefaultAsync(x => x.Id == id);
    }

    public Task Update(Order order)
    {
        //we could do something like 
        //context.Entry(order).State = EntityState.Modified;
        //considering performance matters
        context.Orders.Update(order);
        return Task.CompletedTask;
    }

    public Task Delete(Order order)
    {
        context.Orders.Remove(order);
        return Task.CompletedTask;
    }

    public async Task Create(Order order)
    {
        await context.Orders.AddAsync(order);
    }
}