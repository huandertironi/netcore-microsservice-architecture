using Microsoft.Extensions.DependencyInjection;
using netcore5_core.Infrastructure.Config;
using netcore5_core.Infrastructure.Repository;
using netcore5_core.Services;

namespace netcore5_core.Infrastructure.Bootstrap
{
    public static class StartupBuilder
    {
        public static IServiceCollection BuildServices(IServiceCollection services) {

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<DatabaseContext>();
            services.AddScoped<DatabaseConfig>();

            return services;

        }
    }
}