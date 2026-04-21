using GoodHamburger.Domain.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodHamburger.Infrastructure.PostgreSQL.Mappings;

public abstract class AbstractMapper<T> : IEntityTypeConfiguration<T> where T : Entity
{
    protected abstract void ConfigureMap(EntityTypeBuilder<T> builder);

    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CreatedAt);
        builder.Property(x => x.UpdatedAt);
        ConfigureMap(builder);
    }
}