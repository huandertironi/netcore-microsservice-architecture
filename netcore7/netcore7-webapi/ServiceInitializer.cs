using Microsoft.AspNetCore.Authentication;
using netcore7_core.Infrastructure.Bootstrap;
using netcore7_core.Infrastructure.Middleware;

namespace netcore7_webapi
{
    public static partial class ServiceInitializer
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services) {

            services.AddControllers();

            services = services.BuildCoreServices();
            
            services.AddAuthentication("AuthenticationHandler")
                .AddScheme<AuthenticationSchemeOptions, AuthenticationHandler>
                    ("AuthenticationHandler", null);

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;

        }
    }
}