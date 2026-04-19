using Mediator;

namespace GoodHamburger.Presentation.Api.Behaviors;

public interface IPipelineBehavior<TMessage, TResponse>
    where TMessage : notnull, IMessage
{
    ValueTask<TResponse> Handle(
        TMessage message,
        MessageHandlerDelegate<TMessage, TResponse> next,
        CancellationToken cancellationToken
    );
}
