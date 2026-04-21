namespace GoodHamburger.Domain.Shared.Data;

public interface IUnityOfWork
{
    Task<int> Commit(CancellationToken ct = default);
    Task Rollback();
}