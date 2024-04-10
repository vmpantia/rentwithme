using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RWM.Infrastructure.Databases.Contexts;

namespace RWM.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RWMDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("MigrationDb")));
        }
    }
}
