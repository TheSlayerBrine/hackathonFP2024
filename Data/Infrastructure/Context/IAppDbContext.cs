using Data.Entities;
using Microsoft.EntityFrameworkCore;
namespace Data.Infrastructure.Context;

public interface IAppDbContext : IEntityFrameworkContext
{
    public DbSet<Account> Accounts { get; }
}