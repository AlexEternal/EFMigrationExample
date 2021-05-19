using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServiceTwo.Engine.Entities;

namespace ServiceTwo.Engine.DbContexts
{
    public class ServiceTwoDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ServiceTwoDbContext(DbContextOptions<ServiceTwoDbContext> dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            _configuration = configuration;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(x => x.Name).IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("ServiceTwo"),
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "ServiceTwo"));
        }
    }
}