using Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace Data.Infrastructure.Context;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>()
            .HasKey(a => a.Id);
        modelBuilder.Entity<Account>(e =>
        {
            e.Property(a => a.UserName).HasMaxLength(24).IsRequired();
            e.Property(a => a.Password).IsRequired();
        });
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Account> Accounts { get; set; }
}