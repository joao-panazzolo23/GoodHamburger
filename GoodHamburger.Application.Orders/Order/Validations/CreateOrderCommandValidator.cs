using FluentValidation;
using GoodHamburger.Application.Orders.Order.Commands;

namespace GoodHamburger.Application.Orders.Order.Validations;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
        RuleFor(x => x.Value).NotEmpty().GreaterThan(0);
    }
}