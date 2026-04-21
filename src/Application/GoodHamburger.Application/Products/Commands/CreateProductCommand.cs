using GoodHamburger.Application.Result;
using Mediator;

namespace GoodHamburger.Application.Products.Commands;

public record CreateProductCommand(string Name, decimal Price) : ICommand<Result<Unit>>;