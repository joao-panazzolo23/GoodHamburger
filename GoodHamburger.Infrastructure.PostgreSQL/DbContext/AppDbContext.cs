using Microsoft.EntityFrameworkCore;

namespace GoodHamburger.Infrastructure.PostgreSQL.DbContext;

public class AppDbContext(DbContextOptions options) : Microsoft.EntityFrameworkCore.DbContext(options)
{
    public override Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        
        
        return base.SaveChangesAsync(ct);
    }
}