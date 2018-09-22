using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Farfetch.Infra.Cross.DI;
using Web.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Web.Configurations
{
    public static class FiltersConfigurations
    {
        public static MvcOptions ConfigureMvcOptions(this MvcOptions options, IConfiguration configuration, IServiceCollection services)
        {
            options.ConfigureFilters(configuration, services);
            
            return options;
        }

        public static MvcOptions ConfigureFilters(this MvcOptions options, IConfiguration configuration, IServiceCollection services)
        {
            
            options.Filters.Add(new AuthorizationFilter(services));
            options.Filters.Add(new AuthenticationFilter());
            options.Filters.Add(new RequestFilter());

            return options;
        }
    }
}
