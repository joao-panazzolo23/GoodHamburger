using FluentValidation;
using GoodHamburger.Application.Pipelines.Behaviors;
using GoodHamburger.Domain.Order.Orders.Discounts;
using GoodHamburger.Domain.Order.Orders.Discounts.Abstract;
using Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace GoodHamburger.Application.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        return services
            .AddValidatorsFromAssembly(typeof(ApplicationExtensions).Assembly)
            .AddPipelineBehaviors();
    }


    private static IServiceCollection AddPipelineBehaviors(this IServiceCollection services)
    {
        return services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services.AddScoped<IDiscountRule, SandwichAndPotatoRule>()
                       .AddScoped<IDiscountRule, SandwichAndSideDishRule>()
                       .AddScoped<IDiscountRule, ComboDiscountRule>()
                       .AddScoped<IDiscountCalculator, DiscountCalculator>()
                       ;
    }

}