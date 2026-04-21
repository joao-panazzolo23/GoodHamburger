using GoodHamburger.Domain.Order.Orders.Entities;
using GoodHamburger.Domain.Order.Products.Entities;
using GoodHamburger.Domain.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburger.Infrastructure.PostgreSQL.DbContext;

public class AppDbContext(
    DbContextOptions options
) : Microsoft.EntityFrameworkCore.DbContext(options)
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //todo: uncomment later to register mappings & run migrations 
        //builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        var entities = ChangeTracker.Entries<Entity>();

        foreach (var entry in entities)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.SetCreatedAt();
                    continue;
                case EntityState.Modified:
                    entry.Entity.SetUpdatedAt();
                    continue;
            }
        }

        return base.SaveChangesAsync(ct);
    }
}