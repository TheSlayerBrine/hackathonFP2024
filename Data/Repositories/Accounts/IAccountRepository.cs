using Data.Entities;
using Data.Infrastructure.Repository;

namespace Data.Repositories;

public interface IAccountRepository : IRepository<Account>
{
   public Account GetById(int id);
   public Account GetByName(string nickname);
    public Account GetByEmail(string email);
}