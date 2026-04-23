using GoodHamburger.Application.Products.Commands;
using GoodHamburger.Application.Result;
using GoodHamburger.Domain.Products.Dtos;
using GoodHamburger.Domain.Products.Entities;
using GoodHamburger.Domain.Products.Repositories;
using Mediator;

namespace GoodHamburger.Application.Products.Handlers;

public sealed class GetMenuHandler
     (
    IProductQueryRepository productRepository
    ) : IQueryHandler<GetMenuCommand, Result<IEnumerable<ProductDto>>>
{
    public async ValueTask<Result<IEnumerable<ProductDto>>> Handle(
        GetMenuCommand query, 
        CancellationToken cancellationToken
        )
    {
        var products = await productRepository.List(query.SearchTerm, query.Page, query.PageSize);
        return ResultFactory<IEnumerable<ProductDto>>.Ok(data:products);
    }
}
