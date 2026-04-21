using GoodHamburger.Application.Shared.Exceptions.Dtos;
using GoodHamburger.Presentation.Api.Exceptions.Handlers;
using GoodHamburger.Presentation.Api.Exceptions.Strategies.Strategies;
using GoodHamburger.Presentation.Api.Exceptions.Strategies.Strategies.Abstract;
using GoodHamburger.Presentation.Api.Exceptions.Subclasses;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburger.Presentation.Api.Extensions;

public static class ExceptionExtensions
{
    public static IServiceCollection AddExceptions(this IServiceCollection services)
    {
        return services.AddExceptionStrategies().AddExceptionFactory().AddExceptionHandler();
    }

    private static IServiceCollection AddExceptionStrategies(this IServiceCollection services)
    {
        return services.AddTransient<IExceptionStrategy, SystemExceptionStrategy>()
                .AddTransient<IExceptionStrategy, MissingMessageHandlerExceptionStrategy>()
                .AddTransient<IExceptionStrategy, ApplicationExceptionStrategy>()
                .AddTransient<IExceptionStrategy, DomainExceptionsStrategy>()
            ;
    }

    private static IServiceCollection AddExceptionHandler(this IServiceCollection services)
    {
        return services.AddExceptionHandler<GlobalExceptionHandler>()
            .AddProblemDetails(options =>
            {
                options.CustomizeProblemDetails = context =>
                {
                    context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);
                };
            });
    }

    private static IServiceCollection AddExceptionFactory(this IServiceCollection services)
    {
        return services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                var errors = new List<ExceptionDetail>();

                foreach (var entry in context.ModelState)
                {
                    errors.AddRange(entry.Value!.Errors.Select(error =>
                        new ExceptionDetail(entry.Key, error.ErrorMessage
                        )));
                }

                throw new AppValidationException(errors);
            };
        });
    }
}