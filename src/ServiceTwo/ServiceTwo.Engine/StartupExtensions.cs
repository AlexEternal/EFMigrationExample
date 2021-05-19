using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceTwo.Engine.DbContexts;

namespace ServiceTwo.Engine
{
    public static class StartupExtensions
    {
        public static void AddServiceTwo(this IServiceCollection services, IConfiguration configuration)
        {
            var migrationsAssembly = Assembly.GetCallingAssembly().GetName().Name;

            services.AddDbContext<ServiceTwoDbContext>(builder =>
                builder.UseNpgsql(configuration.GetConnectionString("ServiceTwo"),
                    x => x.MigrationsAssembly(migrationsAssembly)));
        }
    }
}
