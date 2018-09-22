using Farfetch.App.Messages;
using Farfetch.Domain.HttpServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farfetch.App.Services.Contracts
{
    public interface IAuthorizationFilterAppService
    {
        Task<HttpResult<AuthorizationFilterMessageResponse>> Validate(string rota, string authorization);        
    }
}
