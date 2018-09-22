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
        /// 422 Unprocessable Entity - Invalid bankslip provided.The possible reasons are: A field of the provided bankslip was null or with invalid values        
        /// </summary>
        /// <param name="msg"></param>
        public HttpResult<TResponseMessage> SetToUnprocessableEntity(string msg = "Invalid bankslip provided. The possible reasons are: A field of the provided bankslip was null or with invalid values") => Set((HttpStatusCode)422, msg);

        /// <summary>
        /// 200 OK - Utilizado para sucesso.
        /// </summary>
        public HttpResult<TResponseMessage> SetHttpStatusToOk(string msg = "Ok") => Set(HttpStatusCode.OK, msg);

        /// <summary>
        /// 201 - Bankslip created.</c>
        /// </summary>
        public HttpResult<TResponseMessage> SetHttpStatusToCreated(string msg = "Bankslip created.") => Set(HttpStatusCode.Created, msg);

        /// <summary>
        /// 400 Bad Request - Bankslip not provided in the request body.        
        /// </summary>
        /// <param name="msg"></param>
        public HttpResult<TResponseMessage> SetHttpStatusToBadRequest(string msg = "Bankslip not provided in the request body") => Set(HttpStatusCode.BadRequest, msg);

        /// <summary>
        /// 404 Not Found - Bankslip not found with the specified id.
        /// </summary>
        public HttpResult<TResponseMessage> SetHttpStatusToNotFound(string msg = "Bankslip not found with the specified id.") => Set(HttpStatusCode.NotFound, msg);

        /// <summary>
        /// 204 - No content        
        /// </summary>
        /// <param name="msg"></param>
        public HttpResult<TResponseMessage> SetHttpStatusToNoContent(string msg = "No content") => Set((HttpStatusCode)204, msg);

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
