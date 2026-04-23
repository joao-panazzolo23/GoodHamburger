using FluentValidation;
using GoodHamburger.Application.Orders.Commands;

namespace GoodHamburger.Application.Orders.Validations;

internal sealed class GetOrdersByNameQueryValidator : AbstractValidator<ListOrdersQuery>
{
    public GetOrdersByNameQueryValidator()
    {

    }
}
