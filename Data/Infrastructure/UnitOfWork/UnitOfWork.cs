using Data.Infrastructure.Context;
using Data.Repositories;
using Data.Repositories.TimeCapsules;
using Microsoft.EntityFrameworkCore;

namespace Data.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly IAppDbContext dbContext;
    
    public UnitOfWork(IAppDbContext dbContext, IAccountRepository accountRepository, ITimeCapsuleRepository timeCapsuleRepository )
    {
        this.dbContext = dbContext;
        Accounts = accountRepository;
        TimeCapsules = timeCapsuleRepository;
    }

    
    public IAccountRepository Accounts { get; private set; }
    public ITimeCapsuleRepository TimeCapsules { get; private set; }
    
    public int SaveChanges()
    {
        return dbContext.SaveChanges();
    }
    public void Dispose()
    {
        dbContext.Dispose();
    }
    public void Reload<T>(T entity) where T : class
    {
        dbContext.Entry(entity).Reload();
    }
    public bool IsModified<T>(T entity) where T : class
    {
        return dbContext.Entry(entity).State == EntityState.Modified;
    }
}