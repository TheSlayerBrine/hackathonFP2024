using Data.Entities;
using Microsoft.EntityFrameworkCore;
namespace Data.Infrastructure.Context;

public interface IAppDbContext : IEntityFrameworkContext
{
    public DbSet<Account> Accounts { get; }
    public DbSet<TimeCapsule> TimeCapsules { get; }
    public DbSet<Attachment> Attachments { get; }
}