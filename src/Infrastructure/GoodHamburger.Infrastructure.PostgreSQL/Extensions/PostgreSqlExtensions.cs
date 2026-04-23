using GoodHamburger.Domain.Orders.Repositories;
using GoodHamburger.Domain.Products.Repositories;
using GoodHamburger.Domain.Shared.Data;
using GoodHamburger.Infrastructure.PostgreSQL.Data;
using GoodHamburger.Infrastructure.PostgreSQL.DbContext;
using GoodHamburger.Infrastructure.PostgreSQL.Options;
using GoodHamburger.Infrastructure.PostgreSQL.Repositories.Orders;
using GoodHamburger.Infrastructure.PostgreSQL.Repositories.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace GoodHamburger.Infrastructure.PostgreSQL.Extensions;

public static class PostgreSqlExtensions
{
    public static IServiceCollection AddPostgreSqlDb(
        this IServiceCollection services)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        return services
            .ConfigureDbOptions()
            .AddDbContext()
            .AddRepositories()
            ;
    }
    private static IServiceCollection ConfigureDbOptions(this IServiceCollection services)
    {
        services.AddOptions<DatabaseOptions>()
                .BindConfiguration("ConnectionStrings")
                .ValidateDataAnnotations()
                .ValidateOnStart();

        return services;
    }


    private static IServiceCollection AddDbContext(
        this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>((sp, options) =>
        {
            var dbSettings = sp
                .GetRequiredService<IOptions<DatabaseOptions>>()
                .Value;

            options.UseNpgsql(dbSettings.DefaultConnection);
        });

        return services;
    }
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
                .AddScoped<IUnityOfWork, UnityOfWork>()
                .AddScoped<IOrderRepository, OrderRepository>()
                .AddScoped<IProductRepository, ProductRepository>()
            ;
    }

    public static IServiceProvider MigrateDataBase(this IServiceProvider serviceProvider)
    {
        serviceProvider.CreateScope()
            .ServiceProvider
            .GetRequiredService<AppDbContext>()
            .Database
            .Migrate();

        return serviceProvider;
    }
}