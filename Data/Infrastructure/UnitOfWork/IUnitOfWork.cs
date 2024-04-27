using Data.Repositories;

namespace Data.Infrastructure.UnitOfWork;

public interface IUnitOfWork
{
    public IAccountRepository Accounts { get; }
    int SaveChanges();
    void Reload<T>(T entity) where T : class;
    bool IsModified<T>(T entity) where T : class;
    void Dispose();
}