using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace NetflixAppDataAccessLayer.Contexts;

public class NetflixDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var ConStr = new ConfigurationManager()
            .AddJsonFile("AppSettingsCon.json")
            .Build()
            .GetConnectionString("DefaultConnection");

        optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer(ConStr);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
