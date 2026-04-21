namespace GoodHamburger.Presentation.Api.Extensions;

public static class MediatorExtensions
{
    public static IServiceCollection AddMediatorService(this IServiceCollection services)
    {
        services.AddMediator(options =>
        {
            options.ServiceLifetime = ServiceLifetime.Scoped;
        });

        return services;
    }
}