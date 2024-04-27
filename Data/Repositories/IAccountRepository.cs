using Data.Entities;
using Data.Infrastructure.Repository;

namespace Data.Repositories;

public interface IAccountRepository : IRepository<Account>
{
    Account GetById(int id);
    Account GetByName(string nickname);
    Account GetByEmail(string email);
}