using EmployerService.Application.Abstract_Services;
using EmployerService.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployerService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmployerRepository, EmployerRepository>();
            services.AddScoped<IEmployerService, Application.Services.EmployerService>();
            return services;
        }
    }
}
