using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace GoodHamburger.Infrastructure.PostgreSqlDapper;

public class PostgreSqlSession : IDisposable
{
    public readonly IDbConnection Connection;
    public PostgreSqlSession(IConfiguration configuration)
    {
        Connection = new NpgsqlConnection(configuration[@"ConnectionStrings:DefaultConnection"]);
        Connection.Open();
    }

    void IDisposable.Dispose() => Connection.Dispose();
}
