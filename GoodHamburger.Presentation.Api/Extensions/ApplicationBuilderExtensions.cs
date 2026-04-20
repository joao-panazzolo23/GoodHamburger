namespace GoodHamburger.Presentation.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseControllers(this IApplicationBuilder app)
    {
        ((IEndpointRouteBuilder)app).MapControllers();
        return app;
    }
}