using GoodHamburger.Domain.Products.Dtos;

namespace GoodHamburger.Domain.Products.Repositories;

public interface IProductQueryRepository
{
    public Task<IEnumerable<ProductDto>> List(string? search, int page, int pageSize);
}
