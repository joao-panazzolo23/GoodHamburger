using GoodHamburger.Domain.Shared.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodHamburger.Infrastructure.PostgreSQL.Mappings.Orders;

public class OrderMapping : AbstractMapper<Entity>
{
    protected override void ConfigureMap(EntityTypeBuilder<Entity> builder)
    {
        throw new NotImplementedException();
    }
}