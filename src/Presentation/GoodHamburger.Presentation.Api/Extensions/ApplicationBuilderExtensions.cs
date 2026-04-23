using System.Text.Json.Serialization;

namespace GoodHamburger.Presentation.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IServiceCollection AddControllerWithOptions(this IServiceCollection services)
    {
        services.AddControllers().AddJsonOptions(x =>
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); ;
        return services;
    }
    public static IApplicationBuilder UseControllers(this IApplicationBuilder app)
    {
        ((IEndpointRouteBuilder)app).MapControllers();
        return app;
    }
}