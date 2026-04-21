using FluentValidation;
using GoodHamburger.Application.Orders.Commands;

namespace GoodHamburger.Application.Orders.Validations;

internal sealed class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.PhoneNumber)
            .NotEmpty();

        RuleFor(x => x.Items)
            .NotEmpty()
            .ForEach(x => x.SetValidator(new CreateOrderItemCommandValidator()));
    }
}