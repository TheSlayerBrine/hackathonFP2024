using Data.Repositories;
using Data.Repositories.TimeCapsules;

namespace Data.Infrastructure.UnitOfWork;

public interface IUnitOfWork
{
    public IAccountRepository Accounts { get; }
    public ITimeCapsuleRepository TimeCapsules { get; }
    int SaveChanges();
    void Reload<T>(T entity) where T : class;
    bool IsModified<T>(T entity) where T : class;
    void Dispose();
}