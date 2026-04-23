using GoodHamburger.Domain.Orders.Repositories;
using GoodHamburger.Domain.Products.Repositories;
using GoodHamburger.Infrastructure.PostgreSqlDapper.Repositories.Orders;
using GoodHamburger.Infrastructure.PostgreSqlDapper.Repositories.Products;
using Microsoft.Extensions.DependencyInjection;

namespace GoodHamburger.Infrastructure.PostgreSqlDapper;

public static class DapperExtensions
{
    public static IServiceCollection AddQueryRepositories(this IServiceCollection services)
    {
        return services.AddScoped<PostgreSqlSession>()
                       .AddScoped<IOrderQueryRepository, OrderQueryRepository>()
                       .AddScoped<IProductQueryRepository, ProductQueryRepository>()
            ;
    }
}
