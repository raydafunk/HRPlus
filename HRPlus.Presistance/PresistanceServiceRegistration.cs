using HRPlus.Application.Contracts.Presistence;
using HRPlus.Presistance.DatabaaseContext;
using HRPlus.Presistance.Repositories;
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
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRespostiory<>));
        services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
        services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
        services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();

        return services;
    }
}
