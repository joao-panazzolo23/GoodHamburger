using GoodHamburger.Domain.Orders.Entities;
using GoodHamburger.Domain.Products.Entities;
using GoodHamburger.Domain.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace GoodHamburger.Infrastructure.PostgreSQL.DbContext;

public class AppDbContext(
    DbContextOptions options
) : Microsoft.EntityFrameworkCore.DbContext(options)
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(w =>
            w.Ignore(RelationalEventId.PendingModelChangesWarning));
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
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