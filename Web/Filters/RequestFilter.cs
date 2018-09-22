using Farfetch.App.Messages;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class RequestFilter : ActionFilterAttribute
    {

        private readonly List<string> headerKeysToExtract = new List<string> { "Protocol", "Authorization", "Rota" };

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            List<string> keys = context.ActionArguments.Keys.ToList();
            foreach (string key in keys)
            {
                object paramValue = context.ActionArguments[key];

                var paramDescriptor = context.ActionDescriptor.Parameters.Where(it => it.Name == key).FirstOrDefault();

                if (!paramDescriptor.ParameterType.IsSubclassOf(typeof(BaseRequest)))
                    continue;

                if (paramValue == null)
                {
                    paramValue = Activator.CreateInstance(paramDescriptor.ParameterType);
                    context.ActionArguments[key] = paramValue;
                }

                BaseRequest requestMessage = paramValue as BaseRequest;

                if (requestMessage == null)
                    requestMessage = default(BaseRequest);

                if (requestMessage != null)
                {
                    ConfigurarCustomHeaders(context, requestMessage);
                }
            }
        }

        private void Configure(ActionExecutingContext context, BaseRequest requestMessage, string headerKey)
        {
            if (requestMessage == null)
                return;

            string valor = context.HttpContext.Request.Headers[headerKey].ToString();

            if (!string.IsNullOrWhiteSpace(valor))
                requestMessage.AddHeader(headerKey, valor);
        }

        private void ConfigurarCustomHeaders(ActionExecutingContext context, BaseRequest requestMessage)
        {
            foreach (string headerKeyExtract in headerKeysToExtract)
            {
                Configure(context, requestMessage, headerKeyExtract);
            }
        }
    }
}
