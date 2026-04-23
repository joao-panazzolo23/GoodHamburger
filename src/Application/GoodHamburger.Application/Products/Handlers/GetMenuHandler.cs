using GoodHamburger.Application.Products.Commands;
using GoodHamburger.Application.Result;
using GoodHamburger.Domain.Products.Entities;
using GoodHamburger.Domain.Products.Repositories;
using Mediator;

namespace GoodHamburger.Application.Products.Handlers;

public sealed class GetMenuHandler
     (
    IProductRepository productRepository
    ) : IQueryHandler<GetMenuCommand, Result<IEnumerable<Product>>>
{
    public async ValueTask<Result<IEnumerable<Product>>> Handle(
        GetMenuCommand query, 
        CancellationToken cancellationToken
        )
    {
        var products = await productRepository.List(query.SearchTerm, query.Page, query.PageSize);
        return ResultFactory<IEnumerable<Product>>.Ok(data:products);
    }
}
