using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Farfetch.Infra.Data.Imp.Contexts;

namespace Web.Configurations
{
    public static class DatabaseConfigurations
    {
        private const string appSettingsConnStringContratacao = "Farfetch";

        public static IServiceCollection ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContextFarfetch>(options =>
            options.UseSqlServer(configuration.GetConnectionString(appSettingsConnStringContratacao),
                    x => x.MigrationsAssembly("Farfetch.Infra")));

            return services;
        }

        public static IApplicationBuilder UseMigrations(this IApplicationBuilder app, IHostingEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<DbContextFarfetch>().Database.Migrate();
                serviceScope.ServiceProvider.GetService<DbContextFarfetch>().EnsureSeeded();
            }

            return app;
        }
    }
}
