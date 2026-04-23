using GoodHamburger.Domain.Products.Entities;
using GoodHamburger.Domain.Products.Repositories;
using GoodHamburger.Infrastructure.PostgreSQL.DbContext;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburger.Infrastructure.PostgreSQL.Repositories.Products;

internal sealed class ProductRepository(
    AppDbContext context
    ) : IProductRepository
{
    public async Task Create(Product product)
    {
        await context.Products.AddAsync(product);
    }

    public Task Delete(Product product)
    {
        context.Products.Remove(product);
        return Task.CompletedTask;
    }

    public async Task<Product?> GetById(Guid id)
    {
        return await context.Products.SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task Update(Product product)
    {
        context.Products.Update(product);
    }
}
