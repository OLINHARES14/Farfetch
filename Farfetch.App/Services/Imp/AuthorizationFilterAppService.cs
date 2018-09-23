using Farfetch.App.Messages;
using Farfetch.App.Services.Contracts;
using Farfetch.Domain.HttpServices;
using Farfetch.Domain.Services.Contracts.Tasks;
using System.Threading.Tasks;

namespace Farfetch.App.Services.Imp
{
    public class AuthorizationFilterAppService : IAuthorizationFilterAppService
    {
        private IAuthorizationFilterServiceTask AuthorizationFilterServiceTask { get; }

        public AuthorizationFilterAppService(IAuthorizationFilterServiceTask authorizationFilterServiceTask)
        {
            AuthorizationFilterServiceTask = authorizationFilterServiceTask;
        }

        public async Task<HttpResult<AuthorizationFilterMessageResponse>> Validate(string rota, string authorization)
        {
            var retorno = new HttpResult<AuthorizationFilterMessageResponse>();

            var retornoTaskValidate = AuthorizationFilterServiceTask.Validate(rota, authorization);

            if (!retornoTaskValidate)
            {
                retorno.SetToUnprocessableEntity("Acesso não permitido");
            }

            return retorno;
        }
    }
}