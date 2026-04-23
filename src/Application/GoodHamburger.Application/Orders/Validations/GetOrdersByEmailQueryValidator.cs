using FluentValidation;
using GoodHamburger.Application.Orders.Commands;

namespace GoodHamburger.Application.Orders.Validations;

internal sealed class GetOrdersByEmailQueryValidator : AbstractValidator<GetOrdersByEmailQuery>
{
    public GetOrdersByEmailQueryValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
    }
}
