using GoodHamburger.Domain.Shared.Data;
using GoodHamburger.Infrastructure.PostgreSQL.DbContext;

namespace GoodHamburger.Infrastructure.PostgreSQL.Data;

public class UnityOfWork(AppDbContext context) : IUnityOfWork
{
    public Task<int> Commit(CancellationToken ct = default) => context.SaveChangesAsync(ct);

    public async Task Rollback() =>  await context.Database.CurrentTransaction?.RollbackAsync()!;
}