using System.Net;
using GoodHamburger.Presentation.Api.Exceptions.Models;
using GoodHamburger.Presentation.Api.Exceptions.Strategies.Strategies.Abstract;
using GoodHamburger.Presentation.Api.Exceptions.Subclasses;

namespace GoodHamburger.Presentation.Api.Exceptions.Strategies.Strategies;

public class ApplicationExceptionStrategy : IExceptionStrategy
{
    public bool CanHandle(Exception exception) => exception is AppValidationException;

    public async Task<bool> Handle(
        HttpContext context,
        Exception exception,
        CancellationToken cancellationToken)
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        if (exception is not AppValidationException validationException) return false;

        var response = new ExceptionResult(
            HttpStatusCode.BadRequest,
            validationException.Errors,
            "Application"
        );

        await context.Response.WriteAsJsonAsync(response, cancellationToken);


        return true;
    }
}