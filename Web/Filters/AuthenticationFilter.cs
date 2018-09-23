using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace Web.Filters
{
    public class AuthenticationFilter : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string protocol = context.HttpContext.Request.Headers["Protocol"].ToString();

            if (string.IsNullOrWhiteSpace(protocol))
            {
                protocol = Guid.NewGuid().ToString();
                context.HttpContext.Request.Headers.Add("Protocol", protocol);
            }

            await next();
        }
    }
}