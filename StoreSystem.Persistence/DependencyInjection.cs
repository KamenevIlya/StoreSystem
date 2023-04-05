using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreSystem.Application.Interfaces;

namespace StoreSystem.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<StoreSystemDbContext>(options =>
            {
                options.UseSqlServer(connectionString); 
            });
            services.AddScoped<IStoreSystemDbContext>(provider => provider.GetService<StoreSystemDbContext>());
            return services;
        }
    }
}
