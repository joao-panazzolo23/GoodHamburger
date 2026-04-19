using GoodHamburger.Domain.Shared.Data;
using GoodHamburger.Infrastructure.PostgreSQL.Data;
using GoodHamburger.Infrastructure.PostgreSQL.DbContext;
using GoodHamburger.Infrastructure.PostgreSQL.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace GoodHamburger.Infrastructure.PostgreSQL.Extensions;

public static class PostgreSqlExtensions
{
    public static IServiceCollection AddPostgreSqlDb(this IServiceCollection services, IConfiguration configuration)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        return services.AddDbContext(configuration)
                .AddRepositories()
            ;
    }

    private static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
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

    //todo: add repositories DI 
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services.AddScoped<IUnityOfWork, UnityOfWork>();
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