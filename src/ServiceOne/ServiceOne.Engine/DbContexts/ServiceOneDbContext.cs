using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServiceOne.Engine.Entities;

namespace ServiceOne.Engine.DbContexts
{
    public class ServiceOneDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ServiceOneDbContext(DbContextOptions<ServiceOneDbContext> dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            _configuration = configuration;
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarModel> CarModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarModel>().HasIndex(x => x.Name).IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("ServiceOne"), 
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "ServiceOne"));
        }
    }
}