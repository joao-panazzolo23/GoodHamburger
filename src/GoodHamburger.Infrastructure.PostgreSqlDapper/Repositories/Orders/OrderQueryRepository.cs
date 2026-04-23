using Dapper;
using GoodHamburger.Domain.Orders.Dtos;
using GoodHamburger.Domain.Orders.Repositories;

namespace GoodHamburger.Infrastructure.PostgreSqlDapper.Repositories.Orders;

internal sealed class OrderQueryRepository(PostgreSqlSession session) : IOrderQueryRepository

{
    public async Task<OrderDto?> Get(Guid id)
    {
        var sql = @"SELECT 
                        O.""Id"", 
                        O.""Name"", 
                        O.""PhoneNumber"", 
                        O.""Total"", 
                        O.""Subtotal"", 
                        O.""CreatedAt"", 
                        O.""UpdatedAt"", 

                        OI.""Id"", 
                        OI.""ProductId"", 
                        OI.""Price"", 
                        P.""Name"" AS ""ProductName""    
                        
                        FROM ""Orders"" O
                        
                        LEFT JOIN ""OrderItems"" OI
                        ON O.""Id"" = OI.""OrderId""

                        LEFT JOIN ""Products"" P
                        ON OI.""ProductId"" = P.""Id""

                        WHERE O.""Id"" = @Id
    ";

        var orderDict = new Dictionary<Guid, OrderDto>();

        var result = await session.Connection.QueryAsync<OrderDto, OrderItemDto, OrderDto>(
            sql,
            (order, item) =>
            {
                if (!orderDict.TryGetValue(order.Id, out var existingOrder))
                {
                    existingOrder = order;
                    existingOrder.Items = new List<OrderItemDto>();
                    orderDict.Add(existingOrder.Id, existingOrder);
                }

                if (item != null)
                {
                    existingOrder.Items.Add(item);
                }

                return existingOrder;
            },
            new { Id = id },
            splitOn: "Id,Id"
        );

        return orderDict.Values.FirstOrDefault();
    }

    public async Task<IEnumerable<OrderDto>> List()
    {
        var sql = @"SELECT 
                        O.""Id"", 
                        O.""Name"", 
                        O.""PhoneNumber"", 
                        O.""Total"", 
                        O.""Subtotal"", 
                        O.""CreatedAt"", 
                        O.""UpdatedAt"",

                        OI.""Id"", 
                        OI.""ProductId"", 
                        OI.""Price"", 
                        OI.""CreatedAt"", 
                        OI.""UpdatedAt"",
                        P.""Name"" AS ""ProductName""    
                        
                        FROM ""Orders"" O
                        
                        LEFT JOIN ""OrderItems"" OI
                        ON O.""Id"" = OI.""OrderId""

                        LEFT JOIN ""Products"" P
                        ON O.""Id"" = OI.""ProductId"";
    ";

        var orderDict = new Dictionary<Guid, OrderDto>();

        await session.Connection.QueryAsync<OrderDto, OrderItemDto, OrderDto>(
            sql,
            (order, item) =>
            {
                if (!orderDict.TryGetValue(order.Id, out var existingOrder))
                {
                    existingOrder = order;
                    existingOrder.Items = new List<OrderItemDto>();
                    orderDict.Add(existingOrder.Id, existingOrder);
                }

                if (item != null)
                {
                    existingOrder.Items.Add(item);
                }

                return existingOrder;
            },
            splitOn: "Id"
        );

        return orderDict.Values;
    }
}
