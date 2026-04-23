using FluentValidation;
using GoodHamburger.Application.Orders.Commands;

namespace GoodHamburger.Application.Orders.Validations;

internal class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator() : base()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
