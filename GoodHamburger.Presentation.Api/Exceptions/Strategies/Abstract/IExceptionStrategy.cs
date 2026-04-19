namespace GoodHamburger.Presentation.Api.Handlers.Strategies.Abstract;

public interface IExceptionStrategy
{
    Task<bool> Handle(HttpContext httpContext, Exception exception, CancellationToken cancellationToken);
}