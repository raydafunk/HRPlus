using HRPlus.Presistance.DatabaaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRPlus.Presistance;
public static class PresistanceServiceRegistration
{
    public static IServiceCollection AddPresistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<HRPlusDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("HrPlusDatabaseConnectionString"));
        });
        return services;
    }
}
