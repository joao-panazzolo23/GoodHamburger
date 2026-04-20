using GoodHamburger.Infrastructure.PostgreSQL.Extensions;

namespace GoodHamburger.Presentation.Api.Extensions;

public static class DatabaseExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddPostgreSqlDb(configuration);
    }
    public static IApplicationBuilder UseDatabase(this IApplicationBuilder app)
    {
        ((WebApplication)app).Services.MigrateDataBase();
        return app;
    }
    
}