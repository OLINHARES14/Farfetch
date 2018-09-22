﻿using Farfetch.App.Messages;
using Farfetch.App.Services.Contracts;
using Farfetch.Domain.HttpServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
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

            if (string.IsNullOrWhiteSpace(authorization))
            {
                var retorno = new HttpResult<IActionResult>();
                retorno.SetToUnprocessableEntity();
                context.Result = retorno;
                return;
            }
            else
            {
                var serviceRotaToggle = context.HttpContext.Request.Path.Value;

                var request = context.HttpContext.Request;
                request.Headers.Add("Rota", serviceRotaToggle);

                var response = await AuthorizationFilterAppService.Validate(serviceRotaToggle, authorization);
                if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                    await next();
                else
                    context.Result = response;

                return;
            }
        }
    }
}
