using Data.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Configurations;


    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this WebApplication application) 
        {
            using var scope = application.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>(); 
            dbContext.Database.Migrate();
        }
    }
