namespace GoodHamburger.Contracts.Products;

public interface IProductModule
{
    Task<bool> Exists(Guid productId);
}