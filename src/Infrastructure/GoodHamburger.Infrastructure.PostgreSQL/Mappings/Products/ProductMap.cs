using GoodHamburger.Domain.Order.Products.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodHamburger.Infrastructure.PostgreSQL.Mappings.Products;

internal sealed class ProductMap : AbstractMapper<Product>
{
    protected override void ConfigureMap(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Price);
        builder.Property(x => x.Name);
        builder.Property(x => x.ProductCategory);
    }
}
