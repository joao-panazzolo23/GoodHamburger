using GoodHamburger.Domain.Order.Repositories;
using GoodHamburger.Infrastructure.PostgreSQL.DbContext;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburger.Infrastructure.PostgreSQL.Repositories.Orders;

public class OrderRepository(AppDbContext context) : IOrderRepository
{
    public async Task<IEnumerable<Domain.Order.Entities.Order>> List(int page, int pageSize)
    {
        return await context.Orders
            .OrderBy(p => p.Id) 
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<Domain.Order.Entities.Order?> Get(Guid id)
    {
        return await context.Orders.SingleOrDefaultAsync(x => x.Id == id);
    }

    public Task Update(Domain.Order.Entities.Order order)
    {
        //we could do something like 
        //context.Entry(order).State = EntityState.Modified;
        //considering performance matters
        context.Orders.Update(order);
        return Task.CompletedTask;
    }

    public Task Delete(Domain.Order.Entities.Order order)
    {
        context.Orders.Remove(order);
        return Task.CompletedTask;
    }

    public async Task Create(Domain.Order.Entities.Order order)
    {
        await context.Orders.AddAsync(order);
    }
}