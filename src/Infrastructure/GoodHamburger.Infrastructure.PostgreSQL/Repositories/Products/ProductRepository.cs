using GoodHamburger.Domain.Products.Entities;
using GoodHamburger.Domain.Products.Repositories;
using GoodHamburger.Infrastructure.PostgreSQL.DbContext;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburger.Infrastructure.PostgreSQL.Repositories.Products;

internal sealed class ProductRepository(
    AppDbContext context
    ) : IProductRepository
{
    public async Task<Product?> GetById(Guid id)
    {
        return await context.Products.SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Product>> List(string? search, int page, int pageSize)
    {
        return await context.Products.Where(p => string.IsNullOrWhiteSpace(search) || p.Name.Contains(search))
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();
    }
}
