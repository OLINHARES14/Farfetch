﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Web.Configurations;

namespace Web
{
    public class Startup
    {
        private const string corsPolicyName = "FarfetchCorsPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureAppSettingsOptions(Configuration);
            
            services.AddMvc().AddJsonOptions(options =>
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);


            services
                .AddMvc(options => options.ConfigureMvcOptions(Configuration, services));

            services.AddAutoMapperSetup(Configuration);
            services.ConfigureDbContext(Configuration);
            services.ConfigureDI(Configuration);
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseCors(corsPolicyName);

            app.UseStaticFiles();

            app.UseMigrations(env);

            app.UseMvc();
        }
    }
}