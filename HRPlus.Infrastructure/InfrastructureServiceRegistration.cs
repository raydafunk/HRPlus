using HRPlus.Application.Contracts.Email;
using HRPlus.Application.Contracts.Logging;
using HRPlus.Application.Models.Email;
using HRPlus.Infrastructure.EmailService;
using HRPlus.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRPlus.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdpader<>));
            return services;
        }
    }
}       