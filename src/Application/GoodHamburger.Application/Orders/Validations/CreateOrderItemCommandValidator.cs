using FluentValidation;
using GoodHamburger.Application.Orders.Commands;

namespace GoodHamburger.Application.Orders.Validations;

internal sealed class CreateOrderItemCommandValidator : AbstractValidator<CreateOrderItemCommand>
{
    public CreateOrderItemCommandValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty();
    }
}