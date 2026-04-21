using GoodHamburger.Domain.Order.Orders.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodHamburger.Infrastructure.PostgreSQL.Mappings.Orders;

internal class OrderItemMap : AbstractMapper<OrderItem>
{
    protected override void ConfigureMap(EntityTypeBuilder<OrderItem> builder)
    {
        builder.Property(x => x.Price);

        builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);

        builder.HasOne(x => x.Order).WithMany(x => x.Items).HasForeignKey(x => x.OrderId);
    }
}
