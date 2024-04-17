using Microsoft.Extensions.DependencyInjection;
using RWM.Domain.Contractors.Services;
using RWM.Services.Services;

namespace RWM.Servicese.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IBookingService, BookingService>();
        }
    }
}
