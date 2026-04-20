using GoodHamburger.Application.Products.Repositories;
using GoodHamburger.Contracts.Products;

namespace GoodHamburger.Application.Products.Modules;

/// <summary>
/// Anti-Corruption layer to "Products" bounded context
/// </summary>
/// <param name="productRepository"></param>
public class ProductModule(
    IProductRepository productRepository
) : IProductModule
{
    public async Task<bool> Exists(Guid productId)
    {
        return await productRepository.GetById(productId) is not null;
    }
}