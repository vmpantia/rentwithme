using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace RWM.Core.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCore(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
