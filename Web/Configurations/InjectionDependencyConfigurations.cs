using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Farfetch.Infra.Cross.DI;

namespace Web.Configurations
{
    public static class InjectionDependencyConfigurations
    {
        public static IServiceCollection ConfigureDI(this IServiceCollection services, IConfiguration configuration)
        {
            DIFactory.ConfigureDI(services);

            return services;
        }
    }
}