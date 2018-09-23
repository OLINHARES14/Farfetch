using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Farfetch.Domain.HttpServices
{
    [DataContract()]
    public class HttpResult<TResponseMessage> : IActionResult where TResponseMessage : class
    {
        public HttpResult() {}

        [DataMember(Name = "retorno")]
        public TResponseMessage Response { get; set; }

        [DataMember(Name = "mensagem")]
        public string Message { get; set; }
        
        public HttpResult<TResponseMessage> Set(HttpStatusCode httpStatusCode, string msg)
        {
            Message = msg;
            HttpStatusCode = httpStatusCode;

            return this;
        }

        #region Padrões de respostas Http

        /// <summary>
        /// 422 Unprocessable Entity - Utilizado para validações de negócio ou alguma informação necessária para uma ação.        
        /// </summary>
        /// <param name="msg"></param>
        public HttpResult<TResponseMessage> SetToUnprocessableEntity(string msg) => Set((HttpStatusCode)422, msg);

        /// <summary>
        /// 200 OK - Utilizado para todas as situações de sucesso.
        /// </summary>
        /// <param name="msg"></param>
        public HttpResult<TResponseMessage> SetHttpStatusToOk(string msg = "Sucesso") => Set(HttpStatusCode.OK, msg);

        /// <summary>
        /// 201 Created - Utilizado para criação de registro no banco
        /// </summary>
        /// <param name="msg"></param>
        public HttpResult<TResponseMessage> SetHttpStatusToCreated(string msg = "Criado com sucesso.") => Set(HttpStatusCode.Created, msg);

        /// <summary>
        /// 202 Accepted - Utilizado para chamadas async ou adicionar algum item em fila de processamento.
        /// </summary>
        /// <param name="msg"></param>
        public HttpResult<TResponseMessage> SetHttpStatusToAccepted(string msg = "Em fila de processamento.") => Set(HttpStatusCode.Accepted, msg);

        /// <summary>
        /// 400 Bad Request - Utilizado para a maioria dos erros de request.
        /// <c>Campos obrigatórios no request ou erro na camada de serviço.</c>
        /// </summary>
        /// <param name="msg"></param>
        public HttpResult<TResponseMessage> SetHttpStatusToBadRequest(string msg = "Request inválido") => Set(HttpStatusCode.BadRequest, msg);

        /// <summary>
        /// 500 Internal Server Error - Utilizado para erros internos no servidor ou exceptions.
        /// </summary>
        /// <param name="msg"></param>
        public HttpResult<TResponseMessage> SetHttpStatusToInternalServerError(string msg = "Erro de comunicação.") => Set(HttpStatusCode.InternalServerError, msg);

        /// <summary>
        /// 403 Forbidden - Utilizado para requisições rejeitadas pelo servidor.        
        /// </summary>
        /// <param name="msg"></param>
        public HttpResult<TResponseMessage> SetHttpStatusToForbidden(string msg = "O servidor recusou a requisição.") => Set(HttpStatusCode.Forbidden, msg);

        /// <summary>
        /// 404 Not Found - Utilizado para informar rota inválida.
        /// </summary>
        /// <param name="msg"></param>
        public HttpResult<TResponseMessage> SetHttpStatusToNotFound(string msg = "Recurso não encontrado no servidor.") => Set(HttpStatusCode.NotFound, msg);

        /// <summary>
        /// 503 Service Unavailable - Utilizado para informar serviço indisponível.        
        /// </summary>
        /// <param name="msg"></param>
        public HttpResult<TResponseMessage> SetHttpStatusToServiceUnavailable(string msg = "Serviço indisponível.") => Set(HttpStatusCode.ServiceUnavailable, msg);

        /// <summary>
        /// 401 Unauthorized - Utilizado para token inválido ou restrição de acesso.
        /// </summary>
        /// <param name="msg"></param>
        public HttpResult<TResponseMessage> SetHttpStatusToUnauthorized(string msg = "Não autorizado o acesso ao recurso.") => Set(HttpStatusCode.Unauthorized, msg);

        /// <summary>
        /// 406 NotAcceptable - Utilizado para informar que existe informações que devem ser passadas no header.         
        /// </summary>    
        /// <param name="msg"></param>
        public HttpResult<TResponseMessage> SetHttpStatusToNotAcceptable(string msg = "Informação Authorization no header é obrigatório.") => Set(HttpStatusCode.NotAcceptable, msg);

        /// <summary>
        ///  408 RequestTimeout
        /// </summary>
        /// <param name="msg"></param>
        public HttpResult<TResponseMessage> SetHttpStatusToRequestTimeout(string msg = "Tempo limite atingido no request.") => Set(HttpStatusCode.RequestTimeout, msg);

        /// <summary>
        ///  504 GatewayTimeout
        /// </summary>
        /// <param name="msg"></param>
        public HttpResult<TResponseMessage> SetHttpStatusToGatewayTimeout(string msg = "Tempo limite atingido.") => Set(HttpStatusCode.GatewayTimeout, msg);

        #endregion Padrões de respostas Http

        [IgnoreDataMember]
        public HttpStatusCode HttpStatusCode { get; private set; } = HttpStatusCode.OK;

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(this) { StatusCode = (int)HttpStatusCode };
            await objectResult.ExecuteResultAsync(context);
        }
    }
}
