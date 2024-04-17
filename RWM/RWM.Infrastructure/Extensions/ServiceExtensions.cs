using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RWM.Domain.Contractors.Repositories;
using RWM.Infrastructure.Databases.Contexts;
using RWM.Infrastructure.Databases.Repositories;

namespace RWM.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RWMDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("MigrationDb")));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IConfigurationRepository, ConfigurationRepository>();
        }
    }
}
