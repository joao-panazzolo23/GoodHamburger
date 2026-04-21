namespace GoodHamburger.Presentation.Api.Exceptions.Strategies.Strategies.Abstract;

public interface IExceptionStrategy
{
    Task<bool> Handle(HttpContext context, Exception exception, CancellationToken cancellationToken);
}