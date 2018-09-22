using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web.Filters;

namespace Web.Configurations
{
    public static class AppSettingsOptionsConfigurations
    {        
        public static WebHostBuilderContext ConfigAppSettingsFiles(this WebHostBuilderContext hostingContext, IConfigurationBuilder config)
        {      
            config.AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true);

            config.AddEnvironmentVariables();

            return hostingContext;
        }

        public static IServiceCollection ConfigureAppSettingsOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();

            return services;
        }
    }
}
