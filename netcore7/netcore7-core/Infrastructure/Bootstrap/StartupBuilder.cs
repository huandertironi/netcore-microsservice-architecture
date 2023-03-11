using Microsoft.Extensions.DependencyInjection;
using netcore7_core.Infrastructure.Config;
using netcore7_core.Infrastructure.Repository;
using netcore7_core.Services;

namespace netcore7_core.Infrastructure.Bootstrap
{
    public static class StartupBuilder
    {
        public static IServiceCollection BuildCoreServices(this IServiceCollection services) {

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<DatabaseContext>();
            services.AddScoped<DatabaseConfig>();

            return services;

        }
    }
}