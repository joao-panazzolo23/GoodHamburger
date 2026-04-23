using GoodHamburger.Domain.Products.Entities;
using GoodHamburger.Domain.Products.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodHamburger.Infrastructure.PostgreSQL.Mappings.Products;

internal sealed class ProductMap : AbstractMapper<Product>
{
    protected override void ConfigureMap(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Price);
        builder.Property(x => x.Name);
        builder.Property(x => x.Category);

        //This lil buddy seeds data into the database at the first startup while resolving appdbcontext class
        builder.HasData(GetProducts());
    }

    private static IEnumerable<Product> GetProducts()
    {
        var items = new List<Product>
        {   new("X Burger", 5.00m, ProductCategory.Sandwich),
            new("X Egg", 4.50m, ProductCategory.Sandwich),
            new("X Bacon", 7.00m, ProductCategory.Sandwich),
            new("French Fries", 2.00m, ProductCategory.FrenchFries),
            new("Soda", 2.50m, ProductCategory.Beverage)
        };

        items.ForEach(x => x.SetCreatedAt());

        return items;
    }


}


