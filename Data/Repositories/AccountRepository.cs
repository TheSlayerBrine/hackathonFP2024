using Data.Entities;
using Data.Infrastructure.Context;
using Data.Infrastructure.Repository;

namespace Data.Repositories;

public class AccountRepository : Repository<Account>, IAccountRepository
{
    private readonly IAppDbContext dbContext;
    public AccountRepository(IAppDbContext dbContext) : base((AppDbContext)dbContext)
    {
        this.dbContext = dbContext;
    }
    public void Add(Account entity)
    {
        dbContext.Accounts.Add(entity);
    }

    public void Delete(Account entity)
    {
        dbContext.Accounts.Remove(entity);
    }
    public Account Find(int id)
    {
        return dbContext.Accounts.Where(x => x.Id == id).FirstOrDefault();
    }
    public Account GetById(int id)
    {
        var Account = dbContext.Accounts.FirstOrDefault(x => x.Id == id);
        return Account;
    }
    public IEnumerable<Account> GetAll()
    {
        return dbContext.Accounts.ToList();
    }

    public Account GetByName(string name)
    {
        return dbContext.Accounts.Where(x => x.UserName == name).FirstOrDefault();
    }

    public Account GetByEmail(string email)
    {
        return dbContext.Accounts.Where(x => x.Email == email).FirstOrDefault();
    }
}