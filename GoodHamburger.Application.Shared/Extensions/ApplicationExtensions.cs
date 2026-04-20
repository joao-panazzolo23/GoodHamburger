using FluentValidation;
using GoodHamburger.Application.Shared.Pipelines.Behaviors;
using Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace GoodHamburger.Application.Shared.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        return services
            .AddValidatorsFromAssembly(typeof(ApplicationExtensions).Assembly)
            .AddPipelineBehaviors()
            .AddMediator(options => { options.ServiceLifetime = ServiceLifetime.Scoped; });
    }

    private static IServiceCollection AddPipelineBehaviors(this IServiceCollection services)
    {
        return services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}