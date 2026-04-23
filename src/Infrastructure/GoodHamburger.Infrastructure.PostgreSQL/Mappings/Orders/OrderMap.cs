using GoodHamburger.Domain.Orders.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodHamburger.Infrastructure.PostgreSQL.Mappings.Orders;

public class OrderMap : AbstractMapper<Order>
{
    protected override void ConfigureMap(EntityTypeBuilder<Order> builder)
    {
        builder.Property(x => x.Name);
        builder.Property(x => x.Total);
        builder.Property(x => x.Name);
        builder.Property(x => x.PhoneNumber);

        builder.HasMany(x => x.Items)
            .WithOne(x => x.Order)
            .HasForeignKey(x => x.OrderId)
            .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

    }
}