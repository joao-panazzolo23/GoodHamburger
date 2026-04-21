using System.Net;
using GoodHamburger.Domain.Shared.Exceptions;
using GoodHamburger.Presentation.Api.Exceptions.Models;
using GoodHamburger.Presentation.Api.Exceptions.Strategies.Strategies.Abstract;

namespace GoodHamburger.Presentation.Api.Exceptions.Strategies.Strategies;

public class DomainExceptionsStrategy : IExceptionStrategy
{
    public async Task<bool> Handle(HttpContext context, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not DomainException) return false;

        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        var result = new ExceptionResult(
            HttpStatusCode.BadRequest, null,
            typeof(DomainException).Assembly.GetName().Name,
            exception.Message);

        await context.Response.WriteAsJsonAsync(result, cancellationToken);

        return true;
    }
}