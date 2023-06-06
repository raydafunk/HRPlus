using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRPlus.Infrastructure
{
    public static class InfrastructuresServiceRegistration
    {
        public static IServiceCollection ConfigureInfrastureServices(this IServiceCollection services, IConfiguration configuration) 
        {
            return services;
        }
    }
}