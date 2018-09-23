using Farfetch.App.Services.Contracts;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Web.Filters
{
    public class AuthorizationFilter : Attribute, IAsyncActionFilter
    {
        private IAuthorizationFilterAppService AuthorizationFilterAppService { get; }

        public AuthorizationFilter(IServiceCollection service)
        {
            var serviceProvider = service.BuildServiceProvider();
            AuthorizationFilterAppService = serviceProvider.GetService<IAuthorizationFilterAppService>();
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string authorization = context.HttpContext.Request.Headers["Authorization"].ToString();

            if (!string.IsNullOrWhiteSpace(authorization))
            {
                var serviceRotaToggle = context.HttpContext.Request.Path.Value;

                context.HttpContext.Request.Headers.Add("Rota", serviceRotaToggle);

                var response = await AuthorizationFilterAppService.Validate(serviceRotaToggle, authorization);
                if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                {
                    await next();
                }
                else
                {
                    context.Result = response;
                }

                return;
            }

            await next();
        }
    }
}