using Farfetch.App.Messages;
using Farfetch.Domain.HttpServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farfetch.App.Services.Contracts
{
    public interface IServiceRotaAppService
    {
        Task<HttpResult<ServiceRotaMessageResponse>> Create(ServiceRotaCreateMessageRequest request);
        Task<HttpResult<List<ServiceRotaMessageResponse>>> GetAll();
        Task<HttpResult<ServiceRotaMessageResponse>> Get(int id);
        Task<HttpResult<ServiceRotaMessageResponse>> Update(int id, ServiceRotaUpdateMessageRequest request);
        Task<HttpResult<ServiceRotaMessageResponse>> Delete(int id);
    }
}
