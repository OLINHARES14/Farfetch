using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Filters
{
    public class AuthenticationFilter : Attribute, IAsyncActionFilter
    {
        //public void OnActionExecuting(ActionExecutingContext context)
        //{
        //    string protocol = ObterOuGerarProtocoloRequisicao(context);
        //}

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

        //private string ObterOuGerarProtocoloRequisicao(ActionExecutingContext context)
        //{
        //    string protocol = context.HttpContext.Request.Headers["Protocol"].ToString();

        //    if (string.IsNullOrWhiteSpace(protocol))
        //    {
        //        protocol = Guid.NewGuid().ToString();
        //        context.HttpContext.Request.Headers.Add("Protocol", protocol);
        //    }

        //    return protocol;
        //}

        /// <summary>
        /// Chamada async antes que o método da action seja executada
        /// </summary>
        /// <param name="context">Contexto da action</param>
        /// <param name="next">Delegate da proxima açãoa ser executada</param>
        /// <returns>Retorna a tarefa async executada</returns>
        //public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        //{
        //    //if (context.Filters != null 
        //    //    && (context.Filters
        //    //        .Where(it => it.GetType() == typeof(IgnoreTokenAndIpAuthorizeFilter)).Any() 
        //    //            || context.Filters.Where(it => it.GetType() == typeof(AllowAnonymousFilter)).Any() 
        //    //            || (!context.Filters.Where(it => it.GetType() == typeof(IgnoreServiceBusAuthorizeFilter)).Any() && context.Filters.Where(it => it.GetType() == typeof(ServiceBusAuthorizeFilter)).Any())))
        //    //{
        //    //    await next();
        //    //    return;
        //    //}

        //    //await RenovaTokenAutorizacao();

        //    //string authorizedToken = context.HttpContext.Request.Headers[ConstHeaders.Authorization].ToString();
        //    //string ip = context.HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString();
        //    //bool ipPermitido = ipRange == null || IpPermitido(ipRange, ip);

        //    //if (authorizedToken != token || !ipPermitido)
        //    //{
        //    //    UnauthorizedMessageRequest request = new UnauthorizedMessageRequest();
        //    //    request.AddHeader(ConstHeaders.Protocolo, Guid.NewGuid().ToString());

        //    //    ResultResponseMessage<UnauthorizedMessageResponse> result = new ResultResponseMessage<UnauthorizedMessageResponse>(request);
        //    //    result.Retorno = new UnauthorizedMessageResponse();
        //    //    result.CreateResponseUnauthorized();

        //    //    if (ipRange != null && !IpPermitido(ipRange, ip))
        //    //        result.Mensagem = string.IsNullOrWhiteSpace(result.Mensagem) ? ip : result.Mensagem + $" (Ip não autorizado: {ip})";

        //    //    context.Result = result;
        //    //    return;
        //    //}

        //    //await next();
        //}
    }
}
