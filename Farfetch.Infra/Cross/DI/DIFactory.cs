using Farfetch.App.Services.Contracts;
using Farfetch.App.Services.Imp;
using Farfetch.Domain.Services.Contracts.Entities;
using Farfetch.Domain.Services.Contracts.Infra.Data.Contexts;
using Farfetch.Domain.Services.Contracts.Infra.Data.Repositories;
using Farfetch.Domain.Services.Contracts.Infra.Data.UoW;
using Farfetch.Domain.Services.Contracts.Tasks;
using Farfetch.Domain.Services.Imp.Entities;
using Farfetch.Domain.Services.Imp.Tasks;
using Farfetch.Infra.Data.Imp.Contexts;
using Farfetch.Infra.Data.Imp.Repositories;
using Farfetch.Infra.Data.Imp.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace Farfetch.Infra.Cross.DI
{
    public class DIFactory
    {
        public static void ConfigureDI(IServiceCollection services)
        {
            ConfigureDataAccess(services);
            ConfigureApplicationServices(services);
            ConfigureDomainServices(services);
        }

        private static void ConfigureDataAccess(IServiceCollection services)
        {
            services.AddScoped<IDbContextFarfetch, DbContextFarfetch>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IToggleRepository, ToggleRepository>();
            services.AddScoped<IServiceRotaRepository, ServiceRotaRepository>();
            services.AddScoped<IServiceRotaToggleRepository, ServiceRotaToggleRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        }

        private static void ConfigureApplicationServices(IServiceCollection services)
        {
            services.AddScoped<IToggleAppService, ToggleAppService>();
            services.AddScoped<IServiceRotaAppService, ServiceRotaAppService>();
            services.AddScoped<IServiceRotaToggleAppService, ServiceRotaToggleAppService>();
            services.AddScoped<IOrderAppService, OrderAppService>();
            services.AddScoped<IAuthorizationFilterAppService, AuthorizationFilterAppService>();
        }

        private static void ConfigureDomainServices(IServiceCollection services)
        {   
            services.AddScoped<IToggleServiceTask, ToggleServiceTask>();
            services.AddScoped<IToggleEntityService, ToggleEntityService>();

            services.AddScoped<IServiceRotaServiceTask, ServiceRotaServiceTask>();
            services.AddScoped<IServiceRotaEntityService, ServiceRotaEntityService>();

            services.AddScoped<IServiceRotaToggleServiceTask, ServiceRotaToggleServiceTask>();
            services.AddScoped<IServiceRotaToggleEntityService, ServiceRotaToggleEntityService>();

            services.AddScoped<IOrderServiceTask, OrderServiceTask>();
            services.AddScoped<IOrderEntityService, OrderEntityService>();

            services.AddScoped<IAuthorizationFilterServiceTask, AuthorizationFilterServiceTask>();
        }
    }
}
