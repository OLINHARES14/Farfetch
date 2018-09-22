using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Farfetch.Infra.Mapper;

namespace Web.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapperSetup(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper();
            AutoMapperConfig.RegisterMappings();
        }
    }
}
