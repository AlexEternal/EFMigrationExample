using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceOne.Engine.DbContexts;

namespace ServiceOne.Engine
{
    public static class StartupExtensions
    {
        public static void AddServiceOne(this IServiceCollection services, IConfiguration configuration)
        {
            var migrationsAssembly = Assembly.GetCallingAssembly().GetName().Name;

            services.AddDbContext<ServiceOneDbContext>(builder =>
                builder.UseNpgsql(configuration.GetConnectionString("ServiceOne"),
                    x => x.MigrationsAssembly(migrationsAssembly)));
        }
    }
}
