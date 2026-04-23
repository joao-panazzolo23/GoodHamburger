using Dapper;
using GoodHamburger.Domain.Products.Dtos;
using GoodHamburger.Domain.Products.Repositories;

namespace GoodHamburger.Infrastructure.PostgreSqlDapper.Repositories.Products;

internal sealed class ProductQueryRepository
    (
    PostgreSqlSession session
    ): IProductQueryRepository
{
    public Task<IEnumerable<ProductDto>> List(string? search, int page, int pageSize)
    {
        var sql = @"SELECT 
                           ""Id"",
                           ""Name"",
                           ""Price"",
                           ""Category"",
                           ""CreatedAt"",
                           ""UpdatedAt""

                          FROM ""Products""

                          ORDER BY ""Category"" DESC
                    ";
        return session.Connection.QueryAsync<ProductDto>(sql);

    }
}
