using GoodHamburger.Domain.Order.Products.Entities;

namespace GoodHamburger.Domain.Order.Products.Repositories;

public interface IProductRepository
{
    public Task Create(Product product);
    public Task Update(Product product);
    public Task Delete(Product product);
    public Task<Product?> GetById(Guid id);
}
