using System.Net;
using GoodHamburger.Presentation.Api.Exceptions.Models;
using GoodHamburger.Presentation.Api.Exceptions.Strategies.Strategies.Abstract;
using Mediator;

namespace GoodHamburger.Presentation.Api.Exceptions.Strategies.Strategies;

/// <summary>
/// That's a custom Exception strategy for Mediator pattern.
/// When there is no handler registered for a command, MissingMessageHandlerException is thrown;
/// </summary>
public class MissingMessageHandlerExceptionStrategy : IExceptionStrategy
{
    public async Task<bool> Handle(
        HttpContext context,
        Exception exception,
        CancellationToken cancellationToken
    )
    {
        if (exception is not MissingMessageHandlerException) return false;
        
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var result = new ExceptionResult(
            HttpStatusCode.InternalServerError,
            [],
            typeof(MissingMessageHandlerException).Assembly.GetName().Name);

        await context.Response.WriteAsJsonAsync(result, cancellationToken);

        return true;
    }
}