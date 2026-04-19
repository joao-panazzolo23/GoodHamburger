using System.Net;
using GoodHamburger.Presentation.Api.Exceptions.Models;
using GoodHamburger.Presentation.Api.Exceptions.Strategies.Strategies.Abstract;
using GoodHamburger.Presentation.Api.Exceptions.Subclasses;

namespace GoodHamburger.Presentation.Api.Exceptions.Strategies.Strategies;

public class SystemExceptionStrategy : IExceptionStrategy
{
    public async Task<bool> Handle(HttpContext context, Exception exception, CancellationToken cancellationToken)
    {
        if ( exception is not SystemException) return false; 
        
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var result = new ExceptionResult(
            HttpStatusCode.InternalServerError,
            [],
            typeof(IExceptionStrategy).Assembly.GetName().Name);

        await context.Response.WriteAsJsonAsync(result, cancellationToken);

        return true;
    }
}