using GoodHamburger.Domain.Orders.Dtos;
using GoodHamburger.Domain.Orders.Entities;
using GoodHamburger.Domain.Orders.Repositories;
using GoodHamburger.Infrastructure.PostgreSQL.DbContext;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburger.Infrastructure.PostgreSQL.Repositories.Orders;

public class OrderRepository(AppDbContext context) : IOrderRepository
{
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

    public async Task<Order?> Get(Guid id)
    {
        return await context.Orders
            .FirstOrDefaultAsync(o => o.Id == id);
    }
}