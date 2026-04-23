using GoodHamburger.Application.Result;
using GoodHamburger.Domain.Products.Entities;
using Mediator;

namespace GoodHamburger.Application.Products.Commands;

public record GetMenuCommand(
    string? SearchTerm,
    int Page,
    int PageSize
    ) : IQuery<Result<IEnumerable<Product>>>;