using Scalar.AspNetCore;

namespace GoodHamburger.Presentation.Api.Extensions;

public static class DocumentationExtensions
{
    public static IServiceCollection AddDocumentation(this IServiceCollection services, IHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            services.AddOpenApi();
        }
        return services;
    }

    public static IApplicationBuilder UseScalarInterface(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment()) return app;

        app.MapOpenApi();

        app.MapScalarApiReference(options =>
        {
            options.WithTitle("GoodHamburger - Hope you like it! :D")
                .WithClassicLayout()
                .HideSearch()
                .ShowOperationId()
                .SortTagsAlphabetically()
                .SortOperationsByMethod()
                .PreserveSchemaPropertyOrder()
                .WithTheme(theme: ScalarTheme.DeepSpace)
                ;
        });

        return app;
    }
}