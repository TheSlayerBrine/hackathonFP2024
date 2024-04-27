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
        modelBuilder.Entity<TimeCapsule>()
            .HasMany(t => t.Attachments)
            .WithOne(a => a.TimeCapsule)
            .HasForeignKey(a => a.TimeCapsuleId);
        modelBuilder.Entity<Attachment>()
            .HasKey(a => a.Id);
        modelBuilder.Entity<TimeCapsule>()
            .HasKey(t => t.Id);
        modelBuilder.Entity<Account>()
            .HasMany(a => a.TimeCapsules)
            .WithMany(t => t.Collaborators);
    }
    public DbSet<TimeCapsule> TimeCapsules { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<Account> Accounts { get; set; }
}